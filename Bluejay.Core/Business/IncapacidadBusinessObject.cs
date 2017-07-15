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
    public class IncapacidadBusinessObject:BaseBusinessObject
    {
        #region Properties
        private IncapacidadDataObject _IncapacidadDAO;

        public string ConnectionString
        {
            get { return _ConnectionString; }
            set
            {
                _ConnectionString = value;
                if (_IncapacidadDAO != null)
                    _IncapacidadDAO.ConnectionString = this.ConnectionString;
            }
        }
        #endregion

        #region Constructor
        public IncapacidadBusinessObject()
        {
            _IncapacidadDAO = new IncapacidadDataObject();

            if (this.ConnectionString != null && this._ConnectionString != string.Empty)
                _IncapacidadDAO.ConnectionString = this.ConnectionString;
        }
        #endregion

        #region Methods
        public int Save(Bluejay.Core.Entities.IncapacidadEntityObject IncapacidadInfo)
        {
            if (!Exists(IncapacidadInfo))
                return _IncapacidadDAO.Insert(IncapacidadInfo);
            else
                return _IncapacidadDAO.Update(IncapacidadInfo);
        }
        public int Delete(Bluejay.Core.Entities.IncapacidadEntityObject IncapacidadInfo)
        {
            return _IncapacidadDAO.Delete(IncapacidadInfo);
        }        
        public List<IncapacidadEntityObject> GetIncapacidadesByTrabajador(string ClaveTrabajador)
        {
            return _IncapacidadDAO.GetIncapacidadesByTrabajador(ClaveTrabajador);
        }
        #endregion

        #region Functions
        private bool Exists(IncapacidadEntityObject IncapacidadInfo)
        {
            if (IncapacidadInfo != null && IncapacidadInfo.Id > 0)
                return true;
            else
                return false;
        }
        #endregion
    }
}
