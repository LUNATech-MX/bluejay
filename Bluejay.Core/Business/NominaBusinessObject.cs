using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Bluejay.Core.Data;
using Bluejay.Core.Entities;

namespace Bluejay.Core.Business
{
    public class NominaBusinessObject:BaseBusinessObject
    {
        #region Properties
        private NominaDataObject _NominaDAO;

        public string ConnectionString
        {
            get { return _ConnectionString; }
            set
            {
                _ConnectionString = value;
                if (_NominaDAO != null)
                    _NominaDAO.ConnectionString = this.ConnectionString;
            }
        }
        #endregion

        #region Constructor
        public NominaBusinessObject()
        {
            _NominaDAO = new NominaDataObject();

            if (this._ConnectionString != null && this._ConnectionString != string.Empty)
                _NominaDAO.ConnectionString = this.ConnectionString;
        }
        #endregion

        #region Methods
        public int Save(Bluejay.Core.Entities.NominaEntityObject NominaInfo)
        {
            if(!Exists(NominaInfo))
                return _NominaDAO.Insert(NominaInfo);
            else
               return _NominaDAO.Update(NominaInfo);
        }
        public int Delete(Bluejay.Core.Entities.NominaEntityObject NominaInfo)
        {
            return _NominaDAO.Delete(NominaInfo);
        }
        public DataTable GetNominaTable()
        {
            return _NominaDAO.GetNominaTable();
        }
        public List<NominaEntityObject> GetNomina()
        {
            return _NominaDAO.GetNomina();
        }
        public List<NominaEntityObject> GetNominaByConcepto(string ClaveConcepto)
        {
            List<NominaEntityObject> _NominaList = GetNomina();
            return _NominaList.FindAll(x => x.ClaveConcepto.Trim() == ClaveConcepto.Trim());
        }
        public List<NominaEntityObject> GetNominaByEmployee(string ClaveTrabajador)
        {
            List<NominaEntityObject> _NominaList = GetNomina();
            return _NominaList.FindAll(x => x.ClaveTrabajador.Trim() == ClaveTrabajador.Trim());
        }
        #endregion

        #region Functions
        private bool Exists(NominaEntityObject NominaInfo)
        {            
            if (NominaInfo != null && NominaInfo.Id > 0)
                return true;
            else
                return false;            
        }
        #endregion
    }
}
