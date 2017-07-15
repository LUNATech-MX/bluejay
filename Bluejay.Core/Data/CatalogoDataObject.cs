using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluejay.Core.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Bluejay.Core.Data
{
    class CatalogoDataObject:BaseDataObject
    {
        public DataTable GetCatalogoAusentismos()
        {
            return GetCatalogoTable("sp_CLS_CATALOGOS_GetCatalogoAusentismos_");            
        }
        public DataTable GetCatalogoRamasImss()
        {
            return GetCatalogoTable("sp_CLS_CATALOGOS_GetCatalogoRamasImss_");
        }
        public DataTable GetCatalogoRiesgoTrabajo()
        {
            return GetCatalogoTable("sp_CLS_CATALOGOS_GetCatalogoRiesgoTrabajo_");
        }
        public DataTable GetCatalogoSecuelasIncapacidad()
        {
            return GetCatalogoTable("sp_CLS_CATALOGOS_GetCatalogoSecuelasIncapacidad_");
        }
        
        private DataTable GetCatalogoTable(string StoreProcedureName)
        {
            DataTable dt;

            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            cmd.Connection = conn;
                            cmd.CommandTimeout = 30000;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = StoreProcedureName;

                            dt = new DataTable();
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
    }
}
