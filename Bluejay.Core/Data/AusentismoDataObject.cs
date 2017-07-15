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
    class AusentismoDataObject:BaseDataObject
    {
        public int Insert(AusentismoEntityObject AusentismoInfo)
        {
            int nRes = 0;

            if (AusentismoInfo != null)
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandTimeout = 30000;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_CAP_InsertTrabajadorAusentismo_";

                        cmd.Parameters.AddWithValue("CLAVE_TRABAJADOR", AusentismoInfo.ClaveTrabajador);
                        cmd.Parameters.AddWithValue("fecha", AusentismoInfo.FechaAusentismo);
                        cmd.Parameters.AddWithValue("CLAVE_AUSENTISMO", AusentismoInfo.ClaveAusentismo);
                        cmd.Parameters.AddWithValue("CLAVE_EMPRESA", AusentismoInfo.Empresa);
                        cmd.Parameters.AddWithValue("USUARIO", "web");
                        
                        conn.Open();
                        nRes = cmd.ExecuteNonQuery();
                        conn.Close();                        
                    }
                }
            }

            return nRes;
        }
        public int Update(AusentismoEntityObject AusentismoInfo)
        {
            throw new NotImplementedException();
        }
        public int Delete(AusentismoEntityObject AusentismoInfo)
        {
            int nRes = 0;

            if (AusentismoInfo != null)
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandTimeout = 30000;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_CAP_DeleteTrabajadorAusentismo_";

                        cmd.Parameters.AddWithValue("ID_AUSENTISMO", AusentismoInfo.Id);
                        cmd.Parameters.AddWithValue("USUARIO", "web");

                        conn.Open();
                        nRes = cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }

            return nRes;
        }

        public DataTable GetAusentismosByTrabajadorTable(string ClaveTrabajador)
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
                            cmd.CommandText = "sp_GRL_GetTrabajadorAusentismos_";
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
        public List<AusentismoEntityObject> GetAusentismosByTrabajador(string ClaveTrabajador)
        {
            DataTable dt;
            AusentismoEntityObject _AusentismoInfo;
            List<AusentismoEntityObject> _AusentismoList = new List<AusentismoEntityObject>();

            try
            {
                dt = GetAusentismosByTrabajadorTable(ClaveTrabajador);

                if (dt != null)                    
                    foreach (DataRow row in dt.Rows)
                    {
                        _AusentismoInfo = GetAusentismoObject(row);
                        _AusentismoList.Add(_AusentismoInfo);
                    }

                return _AusentismoList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public AusentismoEntityObject GetAusentismoById(int AusentismoId)
        {
            throw new NotImplementedException();
        }

        private AusentismoEntityObject GetAusentismoObject(DataRow row)
        {
            AusentismoEntityObject _AusentismoInfo = new AusentismoEntityObject();

            if (row != null)
            {
                _AusentismoInfo.Id = (row["ID"] != DBNull.Value) ? Convert.ToInt32(row["ID"].ToString()) : 0;
                _AusentismoInfo.ClaveTrabajador = row["CLAVE_TRABAJADOR"].ToString();                
                if (row["fecha_ausentismo"] != DBNull.Value) { _AusentismoInfo.FechaAusentismo = Convert.ToDateTime(row["fecha_ausentismo"]); }                
                _AusentismoInfo.ClaveAusentismo = row["tipo_ausentismo"].ToString();
                _AusentismoInfo.Descripcion = row["descripcion"].ToString();                
            }

            return _AusentismoInfo;
        }
    }
}
