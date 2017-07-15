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
    public class PeriodoBusinessObject:BaseBusinessObject
    {
        private PeriodoDataObject _PeriodoDAO;

        public string ConnectionString
        {
            get { return _ConnectionString; }
            set
            {
                _ConnectionString = value;
                if (_PeriodoDAO != null)
                    _PeriodoDAO.ConnectionString = this.ConnectionString;
            }
        }

        public PeriodoBusinessObject()
        {
            _PeriodoDAO = new PeriodoDataObject();

            if (this.ConnectionString != null && this._ConnectionString != string.Empty)
                _PeriodoDAO.ConnectionString = this.ConnectionString;
        }
        public PeriodoEntityObject GetPeriodoActualByNominaEmpresa(string ClaveNomina, string Empresa)
        {
            return _PeriodoDAO.GetPeriodoActualByNominaEmpresa(ClaveNomina, Empresa);
        }
    }
}
