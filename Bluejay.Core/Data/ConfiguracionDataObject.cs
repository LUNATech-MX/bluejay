using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Bluejay.Core.Entities;

namespace Bluejay.Core.Data
{
    public class ConfiguracionDataObject:BaseDataObject
    {

        #region Propiedades
        #endregion

        #region Constructor
        public ConfiguracionDataObject()
        {
            _ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PasswordServiceCustom"].ConnectionString;
        }
        #endregion

        #region Metodos
        public ConfiguracionEntityObject GetConfiguracionByRfc(string Rfc)
        {
            string sql;
            DataTable dt;
            DataRow row;
            ConfiguracionEntityObject _ConfiguracionInfo;

            try
            {
                _ConfiguracionInfo = null;

                sql = string.Format("select emp.* from Empresas emp where rfc='{0}';", Rfc);
                dt = ExecuteDataTable(sql, null, null);

                if (dt != null && dt.Rows.Count > 0)
                {
                    row = dt.Rows[0];

                    _ConfiguracionInfo = new ConfiguracionEntityObject();
                    _ConfiguracionInfo.SystemDatabase = row["db_sistema"].ToString();
                    _ConfiguracionInfo.EstuderDatabase = row["db_estuder"].ToString();
                }

                return _ConfiguracionInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
