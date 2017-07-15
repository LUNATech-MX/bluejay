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
    public class CompanyBusinessObject:BaseBusinessObject
    {
        private CompanyDataObject _CompanyDAO;

        public string ConnectionString
        {
            get { return _ConnectionString; }
            set
            {
                _ConnectionString = value;
                if (_CompanyDAO != null)
                    _CompanyDAO.ConnectionString = this.ConnectionString;
            }
        }

        public CompanyBusinessObject()
        {
            _CompanyDAO = new CompanyDataObject();

            if (this.ConnectionString != null && this._ConnectionString != string.Empty)
                _CompanyDAO.ConnectionString = this.ConnectionString;
        }

        public DataTable GetCompaniasTable()
        {
            return _CompanyDAO.GetCompaniasTable();
        }
        public List<CompanyEntityObject> GetCompanias()
        {
            return _CompanyDAO.GetCompanias();
        }
        public CompanyEntityObject GetCompania(string ClaveCompania)
        {
            return _CompanyDAO.GetCompany(ClaveCompania);
        }
    }
}
