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
    public class ConceptoBusinessObject:BaseBusinessObject
    {
        private ConceptoDataObject _ConceptoDAO;

        public string ConnectionString
        {
            get { return _ConnectionString; }
            set
            {
                _ConnectionString = value;
                if (_ConceptoDAO != null)
                    _ConceptoDAO.ConnectionString = this.ConnectionString;
            }
        }

        public ConceptoBusinessObject()
        {
            _ConceptoDAO = new ConceptoDataObject();

            if (this.ConnectionString != null && this._ConnectionString != string.Empty)
                _ConceptoDAO.ConnectionString = this.ConnectionString;
        }

        public DataTable GetConceptosTable()
        {
            return _ConceptoDAO.GetConceptosTable();
        }
        public List<ConceptoEntityObject> GetConceptos()
        {
            return _ConceptoDAO.GetConceptos();
        }        
        public ConceptoEntityObject GetConcepto(string ClaveConcepto)
        {
            return _ConceptoDAO.GetConcepto(ClaveConcepto);
        }        
    }
}
