using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Bluejay.Core.Entities;

namespace Bluejay.Core.Data
{
    class NominaDataObject:BaseDataObject
    {        
        public int Insert(NominaEntityObject NominaInfo)
        {
            int nRes = 0;

            if (NominaInfo != null)
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandTimeout = 30000;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_CAP_InsertIncidenciaConceptoPorEmpresa_";

                        cmd.Parameters.AddWithValue("@CLAVE_TRABAJADOR", NominaInfo.ClaveTrabajador);
                        cmd.Parameters.AddWithValue("@CLAVE_CONCEPTO", NominaInfo.ClaveConcepto);
                        cmd.Parameters.AddWithValue("@cap1", NominaInfo.Cap1);
                        cmd.Parameters.AddWithValue("@cap2", NominaInfo.Cap2);
                        cmd.Parameters.AddWithValue("@cap3", NominaInfo.Cap3);
                        cmd.Parameters.AddWithValue("@total", NominaInfo.Total);
                        cmd.Parameters.AddWithValue("@exento", NominaInfo.Exento);
                        cmd.Parameters.AddWithValue("@capturado", 1);
                        cmd.Parameters.AddWithValue("@USUARIO", "NASA");
                        cmd.Parameters.AddWithValue("@CVEEMPRESA", NominaInfo.Empresa);
                        cmd.Parameters.AddWithValue("@PERIODO", NominaInfo.Periodo);

                        conn.Open();
                        nRes = Convert.ToInt32( cmd.ExecuteScalar());
                        conn.Close();
                    }
                }                        
            }

            return nRes;
        }
        public int Update(NominaEntityObject NominaInfo)
        {
            int nRes = 0;

            if (NominaInfo != null)
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandTimeout = 30000;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_CAL_SetConceptoTrabajador_";

                        cmd.Parameters.AddWithValue("@CLAVE_TRABAJADOR", NominaInfo.ClaveTrabajador);
                        cmd.Parameters.AddWithValue("@CLAVE_CONCEPTO", NominaInfo.ClaveConcepto);
                        cmd.Parameters.AddWithValue("@cap1", NominaInfo.Cap1);
                        cmd.Parameters.AddWithValue("@cap2", NominaInfo.Cap2);
                        cmd.Parameters.AddWithValue("@cap3", NominaInfo.Cap3);
                        cmd.Parameters.AddWithValue("@total", NominaInfo.Total);
                        cmd.Parameters.AddWithValue("@exento", NominaInfo.Exento);                        
                        cmd.Parameters.AddWithValue("@PERIODO", NominaInfo.Periodo);
                        cmd.Parameters.AddWithValue("@saldo", 0);

                        conn.Open();
                        nRes = Convert.ToInt32(cmd.ExecuteScalar());
                        conn.Close();
                    }
                }                        
            }

            return 0;
        }
        public int Delete(NominaEntityObject NominaInfo)
        {
            int nRes = 0;
            string sql = string.Empty;

            try
            {
                if (NominaInfo != null)
                {
                    sql = string.Format("DELETE FROM dbTRABNOMI_ACT WHERE ID={0};", NominaInfo.Id);
                    nRes = ExecuteNonQuery(sql, null, null);
                }

                return nRes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetNominaTable()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            cmd.Connection = conn;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = @"select n.* 
	                                                  ,c.txt79 as Descripcion
                                                      ,t.txt93 as Nombre ,t.txt91 as Paterno ,t.txt92 as Materno ,RTRIM(t.txt93)+' '+RTRIM(t.txt91)+' '+RTRIM(t.txt92) as nombre_completo
                                               from dbTRABNOMI_ACT n
	                                                  inner join dbENC49 c on n.CLAVE_CONCEPTO = c.cve93
                                                      inner join dbENC77 t on n.CLAVE_TRABAJADOR=t.cve107
                                               where c.NUM_DOC > 0
                                               order by c.num340;";

                            da.Fill(dt);
                        }
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<NominaEntityObject> GetNomina()
        {
            DataTable dt = new DataTable();
            NominaEntityObject _NominaInfo;
            List<NominaEntityObject> _NominaList = new List<NominaEntityObject>();

            try
            {
                dt = GetNominaTable();

                if (dt != null)
                    foreach (DataRow row in dt.Rows)
                    {
                        _NominaInfo = GetEntityObject(row);
                        _NominaList.Add(_NominaInfo);
                    }

                return _NominaList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private NominaEntityObject GetEntityObject(DataRow row)
        {
            NominaEntityObject _NominaInfo = new NominaEntityObject();

            if (row != null)
            {
                _NominaInfo.Id = (row["ID"] != DBNull.Value) ? Convert.ToInt32(row["ID"].ToString()) : 0;
                _NominaInfo.Empresa = row["clave_empresa"].ToString();
                _NominaInfo.Periodo = row["CLAVE_PERIODO"].ToString();
                _NominaInfo.ClaveTrabajador = row["CLAVE_TRABAJADOR"].ToString();
                _NominaInfo.Nombre = row["nombre_completo"].ToString();
                _NominaInfo.ClaveConcepto = row["CLAVE_CONCEPTO"].ToString();
                _NominaInfo.Descripcion = row["Descripcion"].ToString();
                _NominaInfo.Cap1 = (row["cap1"] != DBNull.Value) ? (decimal)row["cap1"] : 0;
                _NominaInfo.Cap2 = (row["cap2"] != DBNull.Value) ? (decimal)row["cap2"] : 0;
                _NominaInfo.Cap3 = (row["cap3"] != DBNull.Value) ? (decimal)row["cap3"] : 0;
                _NominaInfo.Total = (row["total"] != DBNull.Value) ? (decimal)row["total"] : 0;
                _NominaInfo.IsCanculado = (row["total"] != DBNull.Value) ? (bool)row["capturado"] : false;
            }

            return _NominaInfo;
        }
    }
}
