using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluejay.Core.Entities
{
    public class CompanyEntityObject
    {
        int _id;
        string _claveEmpresa;
        string _nombreEmpresa;

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Clave
        {
            get
            {
                return _claveEmpresa;
            }

            set
            {
                _claveEmpresa = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _nombreEmpresa;
            }

            set
            {
                _nombreEmpresa = value;
            }
        }
    }
}
