using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bluejay.Core.Data;
using Bluejay.Core.Entities;

namespace Bluejay.Core.Business
{
    public class ConfiguracionBusinessObject
    {
        private ConfiguracionDataObject _ConfiguracionDAO;

        #region Propiedades
        private string _ConnectionString;
        public string ConecctionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }
        #endregion

        #region Metodos
        public ConfiguracionEntityObject GetConfiguracionByRfc(string Rfc)
        {
            _ConfiguracionDAO = new ConfiguracionDataObject();
            return _ConfiguracionDAO.GetConfiguracionByRfc(Rfc);
        }
        #endregion
    }
}
