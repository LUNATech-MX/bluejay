using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluejay.Core.Entities
{
    public class PeriodoEntityObject
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
        string _claveNomina;
        public string ClaveNomina
        {
            get
            {
                return _claveNomina;
            }

            set
            {
                _claveNomina = value;
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
        string _clavePeriodo;
        public string ClavePeriodo
        {
            get
            {
                return _clavePeriodo;
            }

            set
            {
                _clavePeriodo = value;
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
        DateTime? _fechaFinal;
        public DateTime? FechaFinal
        {
            get
            {
                return _fechaFinal;
            }

            set
            {
                _fechaFinal = value;
            }
        }
        int _dias;
        public int Dias
        {
            get
            {
                return _dias;
            }

            set
            {
                _dias = value;
            }
        }
        bool _isMesInicio;
        public bool IsMesInicio
        {
            get
            {
                return _isMesInicio;
            }

            set
            {
                _isMesInicio = value;
            }
        }
        bool _isMesFin;
        public bool IsMesFin
        {
            get
            {
                return _isMesFin;
            }

            set
            {
                _isMesFin = value;
            }
        }
        bool _isBimestreInicio;
        public bool IsBimestreInicio
        {
            get
            {
                return _isBimestreInicio;
            }

            set
            {
                _isBimestreInicio = value;
            }
        }
        bool _isBimestreFin;
        public bool IsBimestreFin
        {
            get
            {
                return _isBimestreFin;
            }

            set
            {
                _isBimestreFin = value;
            }
        }
        bool _isAnioInicio;
        public bool IsAnioInicio
        {
            get
            {
                return _isAnioInicio;
            }

            set
            {
                _isAnioInicio = value;
            }
        }
        bool _isAnioFin;
        public bool IsAnioFin
        {
            get
            {
                return _isAnioFin;
            }

            set
            {
                _isAnioFin = value;
            }
        }
        bool _isEspecial;
        public bool IsEspecial
        {
            get
            {
                return _isEspecial;
            }

            set
            {
                _isEspecial = value;
            }
        }
        DateTime? _fechaCorteInicial;
        public DateTime? FechaCorteInicial
        {
            get
            {
                return _fechaCorteInicial;
            }

            set
            {
                _fechaCorteInicial = value;
            }
        }
        DateTime? _fechaCorteFinal;
        public DateTime? FechaCorteFinal
        {
            get
            {
                return _fechaCorteFinal;
            }

            set
            {
                _fechaCorteFinal = value;
            }
        }
        string _mesAcumulacion;
        public string MesAcumulacion
        {
            get
            {
                return _mesAcumulacion;
            }

            set
            {
                _mesAcumulacion = value;
            }
        }

        public PeriodoEntityObject()
        {
            _ID = 0;
            _claveNomina = string.Empty;            
            _descripcion = string.Empty;
            _clavePeriodo = string.Empty;
            _fechaInicial = null;
            _fechaFinal = null;
            _dias = 0;
            _isMesInicio = false;
            _isMesFin = false;
            _isBimestreInicio = false;
            _isBimestreFin = false;
            _isAnioInicio = false;
            _isAnioFin = false;
            _isEspecial = false;
            _fechaCorteInicial = null;
            _fechaCorteFinal = null;
            _mesAcumulacion = string.Empty;
        }
    }
}
