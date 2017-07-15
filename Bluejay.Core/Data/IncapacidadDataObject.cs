using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluejay.Core.Entities;

namespace Bluejay.Core.Data
{
    class IncapacidadDataObject:BaseDataObject
    {
        public int Insert(IncapacidadEntityObject IncapacidadInfo)
        {
            int nRes = 0;

            if (IncapacidadInfo != null)
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandTimeout = 30000;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_CAP_AddIncapacidad_";

                        cmd.Parameters.AddWithValue("CLAVE_TRABAJADOR", IncapacidadInfo.ClaveTrabajador);
                        cmd.Parameters.AddWithValue("fecha_i", IncapacidadInfo.FechaInicial);
                        cmd.Parameters.AddWithValue("fecha_f", IncapacidadInfo.FechaTermino);
                        cmd.Parameters.AddWithValue("duracion", IncapacidadInfo.Duracion);
                        cmd.Parameters.AddWithValue("tipo", IncapacidadInfo.TipoRiesgo);
                        cmd.Parameters.AddWithValue("clasificacion", IncapacidadInfo.Clasificacion);
                        cmd.Parameters.AddWithValue("nota", IncapacidadInfo.Nota);
                        cmd.Parameters.AddWithValue("folio", IncapacidadInfo.Folio);
                        cmd.Parameters.AddWithValue("CLAVE_RAMA", (IncapacidadInfo.RamaSeguro == null) ? string.Empty : IncapacidadInfo.RamaSeguro);
                        cmd.Parameters.AddWithValue("CLAVE_RIESGO", (IncapacidadInfo.RamaSeguro == null) ? string.Empty : IncapacidadInfo.RamaSeguro);
                        cmd.Parameters.AddWithValue("CLAVE_SECUELA", (IncapacidadInfo.RamaSeguro == null) ? string.Empty : IncapacidadInfo.RamaSeguro);
                        cmd.Parameters.AddWithValue("CLAVE_EMPRESA", IncapacidadInfo.Empresa);
                        cmd.Parameters.AddWithValue("ANTICIPADAS", (IncapacidadInfo.Anticipadas)?"SI":"NO");
                        cmd.Parameters.AddWithValue("PERIODO",(IncapacidadInfo.PeriodoAplicar == null)?string.Empty:IncapacidadInfo.PeriodoAplicar);

                        conn.Open();
                        nRes = cmd.ExecuteNonQuery();
                        conn.Close();                        
                    }
                }
            }

            return nRes;
        }
        public int Update(IncapacidadEntityObject IncapacidadInfo)
        {
            throw new NotImplementedException();
        }
        public int Delete(IncapacidadEntityObject IncapacidadInfo)
        {
            int nRes = 0;
            string sql = string.Empty;

            try
            {
                if (IncapacidadInfo != null)
                {
                    sql = string.Format("DELETE FROM dbTRABINCA WHERE ID={0};", IncapacidadInfo.Id);
                    nRes = ExecuteNonQuery(sql, null, null);
                }

                return nRes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetIncapacidadesByTrabajadorTable(string ClaveTrabajador)
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
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "sp_GRL_GetTrabajadorIncapacidades_";
                            cmd.Parameters.AddWithValue("CLAVE_TRABAJADOR", ClaveTrabajador);
                            
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
        public List<IncapacidadEntityObject> GetIncapacidadesByTrabajador(string ClaveTrabajador)
        {
            DataTable dt;
            IncapacidadEntityObject _IncapacidadInfo;
            List<IncapacidadEntityObject> _IncapacidadList = new List<IncapacidadEntityObject>();

            try
            {
                dt = GetIncapacidadesByTrabajadorTable(ClaveTrabajador);

                if (dt != null)                
                    foreach (DataRow row in dt.Rows)
                    {
                        _IncapacidadInfo = GetIncapacidadObject(row);
                        _IncapacidadList.Add(_IncapacidadInfo);
                    }

                return _IncapacidadList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IncapacidadEntityObject GetIncapcidadById(int IncapacidadId)
        {
            return null;
        }

        private IncapacidadEntityObject GetIncapacidadObject(DataRow row)
        {
            IncapacidadEntityObject _IncapacidadInfo = new IncapacidadEntityObject();

            if (row != null)
            {
                _IncapacidadInfo.Id = (row["ID"] != DBNull.Value) ? Convert.ToInt32(row["ID"].ToString()) : 0;
                _IncapacidadInfo.ClaveTrabajador = row["CLAVE_TRABAJADOR"].ToString();
                _IncapacidadInfo.Folio = row["numero_incapacidad"].ToString();
                if (row["fecha_inicial"] != DBNull.Value) { _IncapacidadInfo.FechaInicial = Convert.ToDateTime(row["fecha_inicial"]); }
                _IncapacidadInfo.Duracion = (row["duracion"] != DBNull.Value) ? Convert.ToInt32(row["duracion"].ToString()) : 0;
                if (row["fecha_final"] != DBNull.Value) { _IncapacidadInfo.FechaTermino = Convert.ToDateTime(row["fecha_final"]); }
                _IncapacidadInfo.RamaSeguro = row["CLAVE_RAMA"].ToString();
                _IncapacidadInfo.Clasificacion = row["clasificacion"].ToString();                
                _IncapacidadInfo.Anticipadas = (row["anticipadas"] != DBNull.Value && row["anticipadas"].ToString() == "SI") ? true : false;
                _IncapacidadInfo.TipoRiesgo = row["tipo"].ToString();
                _IncapacidadInfo.Control = row["CLAVE_SECUELA"].ToString();                
            }

            return _IncapacidadInfo;
        }
    }
}
