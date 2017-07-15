using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluejay.Core.Data;
using Bluejay.Core.Entities;
using System.Data;

namespace Bluejay.Core.Business
{
    public class CatalogoBusinessObject:BaseBusinessObject
    {
        CatalogoDataObject _CatalogoDAO;

        public string ConnectionString
        {
            get { return _ConnectionString; }
            set
            {
                _ConnectionString = value;
                if (_CatalogoDAO != null)
                    _CatalogoDAO.ConnectionString = this.ConnectionString;
            }
        }

        public CatalogoBusinessObject()
        {
            _CatalogoDAO = new CatalogoDataObject();

            if (this.ConnectionString != null && this._ConnectionString != string.Empty)
                _CatalogoDAO.ConnectionString = this.ConnectionString;
        }

        public DataTable GetCatalogoAusentismos()
        {
            return  _CatalogoDAO.GetCatalogoAusentismos();            
        }
        public DataTable GetCatalogoRamasImss()
        {
            return _CatalogoDAO.GetCatalogoRamasImss();
        }
        public DataTable GetCatalogoRiesgoTrabajo()
        {
            return _CatalogoDAO.GetCatalogoRiesgoTrabajo();
        }
        public DataTable GetCatalogoSecuelasIncapacidad()
        {
            return _CatalogoDAO.GetCatalogoSecuelasIncapacidad();
        }
    }
}
