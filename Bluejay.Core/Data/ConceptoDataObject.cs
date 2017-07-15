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
    class ConceptoDataObject:BaseDataObject
    {
        public int Insert(ConceptoEntityObject ConceptoInfo)
        {
            throw new NotImplementedException();
        }
        public int Update(ConceptoEntityObject ConceptoInfo)
        {
            throw new NotImplementedException();
        }
        public int Delete(ConceptoEntityObject ConceptoInfo)
        {
            throw new NotImplementedException();
        }
        public DataTable GetConceptosTable()
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
                            cmd.CommandText = "sp_CLS_CATALOGOS_GetCatalogoConceptos_";

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
        public List<ConceptoEntityObject> GetConceptos()
        {
            DataTable dt;
            ConceptoEntityObject _ConceptoInfo;
            List<ConceptoEntityObject> _ConceptosList = new List<ConceptoEntityObject>();

            try
            {
                dt = GetConceptosTable();

                if (dt != null)
                    foreach (DataRow row in dt.Rows)
                    {
                        _ConceptoInfo = GetConceptoObject(row);
                        _ConceptosList.Add(_ConceptoInfo);
                    }

                return _ConceptosList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }     
        public ConceptoEntityObject GetConcepto(string ClaveConcepto)
        {
            DataTable dt;
            DataRow[] rows;
            ConceptoEntityObject _ConceptoInfo = null;

            try
            {
                dt = GetConceptosTable();
                rows = dt.Select(string.Format(@"CLAVE_CONCEPTO='{0}'", ClaveConcepto.Trim()));

                if (rows != null && rows.Length > 0)
                {
                    _ConceptoInfo = GetConceptoObject(rows[0]);
                }

                return _ConceptoInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ConceptoEntityObject GetConceptoObject(DataRow row)
        {
            ConceptoEntityObject _ConceptoInfo = null;

            if (row != null)
            {
                _ConceptoInfo = new ConceptoEntityObject();
                _ConceptoInfo.Clave = row["CLAVE_CONCEPTO"].ToString();
                _ConceptoInfo.Descripcion = row["descripcion"].ToString();                
                //_ConceptoInfo.Activo = (row["activo"] != DBNull.Value && row["activo"].ToString().ToUpper().Trim() == "SI") ? true : false;
            }

            return _ConceptoInfo;
        }

    }
}
