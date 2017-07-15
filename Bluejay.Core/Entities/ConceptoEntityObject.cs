using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluejay.Core.Entities
{
    public class ConceptoEntityObject
    {
        #region Properties
        private int _ID;
        private string _clave;
        private string _descripcion;
        private string _categoria;
        private string _tipo;
        private string _cuentaCargo;
        private string _cuentaCredito;
        private bool _activo;

        public int Id
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }
        public string Clave
        {
            get
            {
                return _clave;
            }

            set
            {
                _clave = value;
            }
        }
        public string Descripcion
        {
            get
            {
                return _descripcion;
            }

            set
            {
                _descripcion = value;
            }
        }
        public string Categoria
        {
            get
            {
                return _categoria;
            }

            set
            {
                _categoria = value;
            }
        }
        public string Tipo
        {
            get
            {
                return _tipo;
            }

            set
            {
                _tipo = value;
            }
        }
        public string CuentaCargo
        {
            get
            {
                return _cuentaCargo;
            }

            set
            {
                _cuentaCargo = value;
            }
        }
        public string CuentaCredito
        {
            get
            {
                return _cuentaCredito;
            }

            set
            {
                _cuentaCredito = value;
            }
        }
        public bool Activo
        {
            get
            {
                return _activo;
            }

            set
            {
                _activo = value;
            }
        }
        #endregion

        #region Constructor
        public ConceptoEntityObject()
        {
            _ID = 0;
            _clave = string.Empty;
            _descripcion = string.Empty;
            _categoria = string.Empty;
            _tipo = string.Empty;
            _cuentaCargo = string.Empty;
            _cuentaCredito = string.Empty;
            _activo = false;
        }
        #endregion
    }
}
