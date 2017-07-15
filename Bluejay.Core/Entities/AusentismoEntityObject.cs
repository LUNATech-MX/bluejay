using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluejay.Core.Entities
{
    public class AusentismoEntityObject
    {
        int _ID;
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
        string _claveTrabajador;
        public string ClaveTrabajador
        {
            get
            {
                return _claveTrabajador;
            }

            set
            {
                _claveTrabajador = value;
            }
        }
        string _claveEmpresa;
        public string Empresa
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
        DateTime? _fechaAusentismo;
        public DateTime? FechaAusentismo
        {
            get
            {
                return _fechaAusentismo;
            }

            set
            {
                _fechaAusentismo = value;
            }
        }
        string _claveAusentismo;
        public string ClaveAusentismo
        {
            get
            {
                return _claveAusentismo;
            }

            set
            {
                _claveAusentismo = value;
            }
        }
        string _descripcion;
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
        int _duracion;
        public int Duracion
        {
            get
            {
                return _duracion;
            }

            set
            {
                _duracion = value;
            }
        }
        string _claveCausa;
        public string ClaveCausa
        {
            get
            {
                return _claveCausa;
            }

            set
            {
                _claveCausa = value;
            }
        }
        string _usuario;
        public string Usuario
        {
            get
            {
                return _usuario;
            }

            set
            {
                _usuario = value;
            }
        }
        DateTime? _fechaCaptura;
        public DateTime? FechaCaptura
        {
            get
            {
                return _fechaCaptura;
            }

            set
            {
                _fechaCaptura = value;
            }
        }
        int _book;
        public int Book
        {
            get
            {
                return _book;
            }

            set
            {
                _book = value;
            }
        }

        public AusentismoEntityObject()
        {
            _ID = 0;
            _claveTrabajador = string.Empty;
            _claveEmpresa = string.Empty;
            _fechaAusentismo = null;
            _claveAusentismo = string.Empty;
            _descripcion = string.Empty;
            _duracion = 1;
            _claveCausa = string.Empty;
            _usuario = string.Empty;
            _fechaCaptura = DateTime.Now;
            _book = 0;
        }
    }
}
