using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluejay.Core.Entities
{
    public class IncapacidadEntityObject
    {
        #region Properties
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
            get { return _claveEmpresa; }
            set { _claveEmpresa = value; }
        }
        string _folio;
        public string Folio
        {
            get
            {
                return _folio;
            }

            set
            {
                _folio = value;
            }
        }
        DateTime? _fechaInicial;
        public DateTime? FechaInicial
        {
            get
            {
                return _fechaInicial;
            }

            set
            {
                _fechaInicial = value;
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
        DateTime? _fechaTermino;
        public DateTime? FechaTermino
        {
            get
            {
                return _fechaTermino;
            }

            set
            {
                _fechaTermino = value;
            }
        }
        string _ramaSeguro;
        public string RamaSeguro
        {
            get
            {
                return _ramaSeguro;
            }

            set
            {
                _ramaSeguro = value;
            }
        }
        string _clasificacion;
        public string Clasificacion
        {
            get
            {
                return _clasificacion;
            }

            set
            {
                _clasificacion = value;
            }
        }
        bool _anticipadas;
        public bool Anticipadas
        {
            get
            {
                return _anticipadas;
            }

            set
            {
                _anticipadas = value;
            }
        }
        string _periodoAplicar;
        public string PeriodoAplicar
        {
            get
            {
                return _periodoAplicar;
            }

            set
            {
                _periodoAplicar = value;
            }
        }
        string _tipoRiesgo;
        public string TipoRiesgo
        {
            get
            {
                return _tipoRiesgo;
            }

            set
            {
                _tipoRiesgo = value;
            }
        }
        string _control;
        public string Control
        {
            get
            {
                return _control;
            }

            set
            {
                _control = value;
            }
        }
        string _nota;
        public string Nota
        {
            get { return _nota; }
            set { _nota = value; }
        }
        #endregion

        public IncapacidadEntityObject()
        {
            _ID = 0;
            _claveTrabajador = string.Empty;
            _claveEmpresa = string.Empty;
            _folio = string.Empty;
            _fechaInicial = null;
            _duracion = 0;
            _fechaTermino = null;
            _ramaSeguro = string.Empty;
            _clasificacion = string.Empty;
            _anticipadas = false;
            _periodoAplicar = string.Empty;
            _tipoRiesgo = string.Empty;
            _control = string.Empty;
            _nota = string.Empty;
        }
    }
}
