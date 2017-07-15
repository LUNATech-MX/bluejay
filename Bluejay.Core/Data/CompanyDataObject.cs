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
    class CompanyDataObject:BaseDataObject
    {
        public int Insert(CompanyEntityObject CompaniaInfo)
        {
            throw new NotImplementedException();
        }
        public int Update(CompanyEntityObject CompaniaInfo)
        {
            throw new NotImplementedException();
        }
        public int Delete(CompanyEntityObject CompaniaInfo)
        {
            throw new NotImplementedException();
        }

        public DataTable GetCompaniasTable()
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
                            cmd.CommandText = "sp_CLS_CATALOGOS_GetCatalogoCompanias_";

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
        public List<CompanyEntityObject> GetCompanias()
        {
            DataTable dt;
            CompanyEntityObject _CompaniaInfo;
            List<CompanyEntityObject> _CompaniasList = new List<CompanyEntityObject>();

            try
            {
                dt = GetCompaniasTable();

                if (dt != null)
                    foreach (DataRow row in dt.Rows)
                    {
                        _CompaniaInfo = GetCompanyObject(row);
                        _CompaniasList.Add(_CompaniaInfo);
                    }

                return _CompaniasList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CompanyEntityObject GetCompany(string ClaveCompania)
        {
            DataTable dt;
            DataRow[] rows;
            CompanyEntityObject _CompmpanyInfo = null;

            try
            {
                dt = GetCompaniasTable();
                rows = dt.Select(string.Format(@"CLAVE_COMPANIA='{0}'", ClaveCompania));

                if (rows != null && rows.Length > 0)
                {
                    _CompmpanyInfo = GetCompanyObject(rows[0]);
                }

                return _CompmpanyInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private CompanyEntityObject GetCompanyObject(DataRow row)
        {
            CompanyEntityObject _CompanyInfo = null;

            if (row != null)
            {
                _CompanyInfo = new CompanyEntityObject();
                _CompanyInfo.Clave = row["CLAVE_COMPANIA"].ToString().Trim();
                _CompanyInfo.Nombre = row["nombre_compania"].ToString().Trim();
                //_ConceptoInfo.Activo = (row["activo"] != DBNull.Value && row["activo"].ToString().ToUpper().Trim() == "SI") ? true : false;
            }

            return _CompanyInfo;
        }


        #region IdentityCompany
        public int InsertIdentity(CompanyDataObject CompanyInfo)
        { return 0; }
        public int UpdateIdentity(CompanyDataObject CompanyInfo)
        { return 0; }
        #endregion
    }
}
