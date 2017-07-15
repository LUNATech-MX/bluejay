using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluejay.Core.Data;
using Bluejay.Core.Entities;

namespace Bluejay.Core.Business
{
    public class AusentismoBusinessObject:BaseBusinessObject
    {
        #region Properties
        private AusentismoDataObject _AusentismodDAO;

        public string ConnectionString
        {
            get { return _ConnectionString; }
            set
            {
                _ConnectionString = value;
                if (_AusentismodDAO != null)
                    _AusentismodDAO.ConnectionString = this.ConnectionString;
            }
        }
        #endregion

        #region Constructor
        public AusentismoBusinessObject()
        {
            _AusentismodDAO = new AusentismoDataObject();

            if (this.ConnectionString != null && this._ConnectionString != string.Empty)
                _AusentismodDAO.ConnectionString = this.ConnectionString;
        }
        #endregion

        #region Methods
        public int Save(AusentismoEntityObject AusentismoInfo)
        {
            if (!Exists(AusentismoInfo))
                return _AusentismodDAO.Insert(AusentismoInfo);
            else
                return _AusentismodDAO.Update(AusentismoInfo);
        }
        public int Delete(AusentismoEntityObject AusentismoInfo)
        {
            return _AusentismodDAO.Delete(AusentismoInfo);
        }        
        public List<AusentismoEntityObject> GetAusentismosByTrabajador(string ClaveTrabajador)
        {
            return _AusentismodDAO.GetAusentismosByTrabajador(ClaveTrabajador);
        }
        #endregion

        #region Functions
        private bool Exists(AusentismoEntityObject AusentismoInfo)
        {
            if (AusentismoInfo != null && AusentismoInfo.Id > 0)
                return true;
            else
                return false;
        }
        #endregion
    }
}
