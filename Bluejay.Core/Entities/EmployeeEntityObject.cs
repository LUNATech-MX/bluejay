using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluejay.Core.Entities
{
    public class EmployeeEntityOnject
    {
        #region Properties

        #region Generales
        Int32 _ID;
        string _CLAVE_TRABAJADOR;
        string _nombre;
        string _apellidoPaterno;
        string _apellidoMaterno;
        DateTime? _fechaAlta;
        DateTime? _fechaIngreso;
        DateTime? _fechaBaja;
        DateTime? _fechaAntiguedad;

        EmpresaEntity _Empresa;
        SucursalEntity _Sucursal;
        CentroCostoEntity _CentroCosto;
        DepartamentoEntity _Departamento;
        PuestoEntity _Puesto;

        decimal _sueldoDiario;
        decimal _sueldoIntegrado;
        decimal _sueldoVariable;
        decimal _sueldoInfonavit;
        decimal _sueldoMensual;
        string _tipoFactor;
        string _categoriaFactor;
        decimal _factorIntegracion;
        bool _activo;
        
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
                return _CLAVE_TRABAJADOR.Trim();
            }

            set
            {
                _CLAVE_TRABAJADOR = value;
            }
        }
        public string Nombre
        {
            get
            {
                return _nombre.Trim();
            }

            set
            {
                _nombre = value;
            }
        }
        public string ApellidoPaterno
        {
            get
            {
                return _apellidoPaterno.Trim();
            }

            set
            {
                _apellidoPaterno = value;
            }
        }
        public string ApellidoMaterno
        {
            get
            {
                return _apellidoMaterno.Trim();
            }

            set
            {
                _apellidoMaterno = value;
            }
        }
        public string NombreCompleto
        {
            get
            {
                string[] values = new string[] { _nombre.Trim(), _apellidoPaterno.Trim(), _apellidoMaterno.Trim() };
                return string.Format("{0} {1} {2}",values).Trim();
            }
        }
        public DateTime? FechaAlta
        {
            get
            {
                return _fechaAlta;
            }

            set
            {
                _fechaAlta = value;
            }
        }
        public DateTime? FechaIngreso
        {
            get
            {
                return _fechaIngreso;
            }

            set
            {
                _fechaIngreso = value;
            }
        }
        public DateTime? FechaBaja
        {
            get
            {
                return _fechaBaja;
            }

            set
            {
                _fechaBaja = value;
            }
        }
        public DateTime? FechaAntiguedad
        {
            get
            {
                return _fechaAntiguedad;
            }

            set
            {
                _fechaAntiguedad = value;
            }
        }

        public EmpresaEntity Empresa
        {
            get
            {
                return _Empresa;
            }

            set
            {
                _Empresa = value;
            }
        }
        public SucursalEntity Sucursal
        {
            get
            {
                return _Sucursal;
            }

            set
            {
                _Sucursal = value;
            }
        }
        public CentroCostoEntity CentroCosto
        {
            get
            {
                return _CentroCosto;
            }

            set
            {
                _CentroCosto = value;
            }
        }
        public DepartamentoEntity Departamento
        {
            get
            {
                return _Departamento;
            }

            set
            {
                _Departamento = value;
            }
        }
        public PuestoEntity Puesto
        {
            get
            {
                return _Puesto;
            }

            set
            {
                _Puesto = value;
            }
        }

        public decimal SueldoDiario
        {
            get
            {
                return _sueldoDiario;
            }

            set
            {
                _sueldoDiario = value;
            }
        }
        public decimal SueldoIntegrado
        {
            get
            {
                return _sueldoIntegrado;
            }

            set
            {
                _sueldoIntegrado = value;
            }
        }
        public decimal SueldoVariable
        {
            get
            {
                return _sueldoVariable;
            }

            set
            {
                _sueldoVariable = value;
            }
        }
        public decimal SueldoInfonavit
        {
            get
            {
                return _sueldoInfonavit;
            }

            set
            {
                _sueldoInfonavit = value;
            }
        }
        public decimal SueldoMensual
        {
            get
            {
                return _sueldoMensual;
            }

            set
            {
                _sueldoMensual = value;
            }
        }

        public string TipoFactor
        {
            get
            {
                return _tipoFactor;
            }

            set
            {
                _tipoFactor = value;
            }
        }
        public string CategoriaFactor
        {
            get
            {
                return _categoriaFactor;
            }

            set
            {
                _categoriaFactor = value;
            }
        }
        public decimal FactorIntegracion
        {
            get
            {
                return _factorIntegracion;
            }

            set
            {
                _factorIntegracion = value;
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

        #region RH
        private string _calle;
        public string Calle
        {
            get { return _calle; }
            set { _calle = value; }
        }

        private string _numero;
        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        private string _colonia;
        public string Colonia
        {
            get { return _colonia; }
            set { _colonia = value; }
        }

        private string _poblacion;
        public string Poblacion
        {
            get { return _poblacion; }
            set { _poblacion = value; }
        }

        private string _estado;
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        private string _localidad;
        public string Localidad
        {
            get { return _localidad; }
            set { _localidad = value; }
        }

        private string _codigoPostal;
        public string CodigoPostal
        {
            get { return _codigoPostal; }
            set { _codigoPostal = value; }
        }

        private string _telefono1;
        public string Telefono1
        {
            get { return _telefono1; }
            set { _telefono1 = value; }
        }

        private string _telefono2;
        public string Telefono2
        {
            get { return _telefono2; }
            set { _telefono2 = value; }
        }

        private string _telefono3;
        public string Telefono3
        {
            get { return _telefono3; }
            set { _telefono3 = value; }
        }

        private string _sexo;
        public string Sexo
        {
            get { return _sexo; }
            set { _sexo = value; }
        }

        private string _escolaridad;
        public string Escolaridad
        {
            get { return _escolaridad; }
            set { _escolaridad = value; }
        }

        private string _carrera;
        public string Carrera
        {
            get { return _carrera; }
            set { _carrera = value; }
        }

        private string _nota;
        public string Nota
        {
            get { return _nota; }
            set { _nota = value; }
        }

        private string _lugar_nacimiento;
        public string LugarNacimiento
        {
            get { return _lugar_nacimiento; }
            set { _lugar_nacimiento = value; }
        }

        private DateTime? _fecha_nacimiento;
        public DateTime? FechaNacimiento
        {
            get { return _fecha_nacimiento; }
            set { _fecha_nacimiento = value; }
        }

        private string _padre;
        public string Padre
        {
            get { return _padre; }
            set { _padre = value; }
        }

        private string _madre;
        public string Madre
        {
            get { return _madre; }
            set { _madre = value; }
        }

        private string _estado_civil;
        public string EstadoCivil
        {
            get { return _estado_civil; }
            set { _estado_civil = value; }
        }

        private string _claveInstituto;
        public string ClaveInstituto
        {
            get { return _claveInstituto; }
            set { _claveInstituto = value; }
        }

        private int _estadoNivel;
        public int EstadoNivel
        {
            get { return _estadoNivel; }
            set { _estadoNivel = value; }
        }
        #endregion

        #region Nomina
        private string _rfc;
        public string Rfc
        {
            get { return _rfc; }
            set { _rfc = value; }
        }

        private string _CLAVE_NOMINA;
        public string ClaveNomina
        {
            get { return _CLAVE_NOMINA; }
            set { _CLAVE_NOMINA = value; }
        }

        private string _CLAVE_TURNO;
        public string ClaveTurno
        {
            get { return _CLAVE_TURNO; }
            set { _CLAVE_TURNO = value; }
        }

        private string _tipo_pago;
        public string TipoPago
        {
            get { return _tipo_pago; }
            set { _tipo_pago = value; }
        }

        private string _ptu;
        public string PTU
        {
            get { return _ptu; }
            set { _ptu = value; }
        }

        private string _extra1;
        public string Extra1
        {
            get { return _extra1; }
            set { _extra1 = value; }
        }

        private string _extra2;
        public string Extra2
        {
            get { return _extra2; }
            set { _extra2 = value; }
        }

        private string _extra3;
        public string Extra3
        {
            get { return _extra3; }
            set { _extra3 = value; }
        }

        private string _descanso1;
        public string Descanso1
        {
            get { return _descanso1; }
            set { _descanso1 = value; }
        }

        private string _descanso2;
        public string Descanso2
        {
            get { return _descanso2; }
            set { _descanso2 = value; }
        }

        private bool _cuota_sindical;
        public bool CuotaSindical
        {
            get { return _cuota_sindical; }
            set { _cuota_sindical = value; }
        }

        private string _control_interno;
        public string ControlInterno
        {
            get { return _control_interno; }
            set { _control_interno = value; }
        }

        private string _cuenta_bancaria;
        public string CuentaBancaria
        {
            get { return _cuenta_bancaria; }
            set { _cuenta_bancaria = value; }
        }

        private string _comisiones;
        public string Comisiones
        {
            get { return _comisiones; }
            set { _comisiones = value; }
        }

        private string _tipo_trabajador;
        public string TipoTrabajador
        {
            get { return _tipo_trabajador; }
            set { _tipo_trabajador = value; }
        }

        private string _clave_banco;
        public string ClaveBanco
        {
            get { return _clave_banco; }
            set { _clave_banco = value; }
        }

        private string _numero_tarjeta;
        public string NumeroTarjeta
        {
            get { return _numero_tarjeta; }
            set { _numero_tarjeta = value; }
        }

        private string _descripcion_tipoNomina;
        public string DescripcionTipoNomina
        {
            get { return _descripcion_tipoNomina; }
            set { _descripcion_tipoNomina = value; }
        }

        private string _CLABE;
        public string CLABE
        {
            get { return _CLABE; }
            set { _CLABE = value; }
        }

        private int _regimen;
        public int Regimen
        {
            get { return _regimen; }
            set { _regimen = value; }
        }

        private string _turno_actual;
        public string TurnoActual
        {
            get { return _turno_actual; }
            set { _turno_actual = value; }
        }
        #endregion

        #region IMSS
        private string _afiliacion;
        public string Afiliacion
        {
            get { return _afiliacion; }
            set { _afiliacion = value; }
        }

        private string _curp;
        public string Curp
        {
            get { return _curp; }
            set { _curp = value; }
        }
        
        private string _afore;
        public string Afore
        {
            get { return _afore; }
            set { _afore = value; }
        }
        
        private string _unidad_medica;
        public string UnidadMedica
        {
            get { return _unidad_medica; }
            set { _unidad_medica = value; }
        }
        
        private decimal _aportacion_voluntaria;
        public decimal AportacionVoluntaria
        {
            get { return _aportacion_voluntaria; }
            set { _aportacion_voluntaria = value; }
        }
        
        private string _tipo_contratacion;
        public string TipoContratacion
        {
            get { return _tipo_contratacion; }
            set { _tipo_contratacion = value; }
        }
        
        private string _semana_reducida;
        public string SemanaReducida
        {
            get { return _semana_reducida; }
            set { _semana_reducida = value; }
        }
        
        private string _tipo_jornada;
        public string TipoJornada
        {
            get { return _tipo_jornada; }
            set { _tipo_jornada = value; }
        }
        #endregion

        #endregion

        public EmployeeEntityOnject()
        {
            //Datos Generales
             _ID = 0;
            _CLAVE_TRABAJADOR = string.Empty;
            _nombre = string.Empty;
            _apellidoPaterno = string.Empty; ;
            _apellidoMaterno = string.Empty;
            _fechaAlta = null;
            _fechaIngreso = null;
            _fechaBaja = null;
            _fechaAntiguedad = null;

            _Empresa = new EmpresaEntity();
            _Sucursal = new SucursalEntity();
            _CentroCosto = new CentroCostoEntity();
            _Departamento = new DepartamentoEntity();
            _Puesto = new PuestoEntity();

            _sueldoDiario = 0;
            _sueldoIntegrado = 0;
            _sueldoVariable = 0;
            _sueldoInfonavit = 0;
            _sueldoMensual = 0;
            _tipoFactor = string.Empty;
            _categoriaFactor = string.Empty;
            _factorIntegracion = 0;
            _activo = false;

            //Datos RH
            _calle = string.Empty;
            _numero = string.Empty;
            _colonia = string.Empty;
            _poblacion = string.Empty;
            _estado = string.Empty;
            _localidad = string.Empty;
            _codigoPostal = string.Empty;
            _telefono1 = string.Empty;
            _telefono2 = string.Empty;
            _telefono3 = string.Empty;
            _sexo = string.Empty;
            _escolaridad = string.Empty;
            _carrera = string.Empty;
            _nota = string.Empty;
            _lugar_nacimiento = string.Empty;
            _fecha_nacimiento = null;
            _padre = string.Empty;
            _madre = string.Empty;
            _estado_civil = string.Empty;
            _claveInstituto = string.Empty;
            _estadoNivel = 0;

            //Datos Nomina
            _rfc = string.Empty;
            _CLAVE_NOMINA = string.Empty;
            _CLAVE_TURNO = string.Empty;
            _tipo_pago = string.Empty;
            _ptu = string.Empty;
            _extra1 = string.Empty;
            _extra2 = string.Empty;
            _extra3 = string.Empty;
            _descanso1 = string.Empty;
            _descanso2 = string.Empty;
            _cuota_sindical = false;
            _control_interno = string.Empty;
            _cuenta_bancaria = string.Empty;
            _comisiones = string.Empty;
            _tipo_trabajador = string.Empty;
            _clave_banco = string.Empty;
            _numero_tarjeta = string.Empty;
            _descripcion_tipoNomina = string.Empty;
            _CLABE = string.Empty;
            _regimen = 0;
            _turno_actual = string.Empty;

            //Datos IMSS
            _afiliacion = string.Empty;
            _curp = string.Empty;
            _afore = string.Empty;
            _unidad_medica = string.Empty;
            _aportacion_voluntaria = 0;
            _tipo_contratacion = string.Empty;
            _semana_reducida = string.Empty;
            _tipo_jornada = string.Empty;
        }
    }
}
