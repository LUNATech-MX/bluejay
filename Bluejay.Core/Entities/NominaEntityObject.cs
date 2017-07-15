using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bluejay.Core.Entities
{
    public class NominaEntityObject
    {
        #region Properties
        private Int32 _ID;
        public Int32 Id
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _claveEmpresa;
        public string Empresa
        {
            get { return _claveEmpresa; }
            set { _claveEmpresa = value; }
        }

        private string _clavePeriodo;
        public string Periodo
        {
            get { return _clavePeriodo; }
            set { _clavePeriodo = value; }
        }
        
        private string _claveTrabajador;
        public string ClaveTrabajador
        {
            get { return _claveTrabajador; }
            set { _claveTrabajador = value; }
        }

        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _claveConcepto;
        public string ClaveConcepto
        {
            get { return _claveConcepto; }
            set { _claveConcepto = value; }
        }

        private string _descripcion;
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
                
        private decimal _cap1;
        public decimal Cap1
        {
            get { return _cap1; }
            set { _cap1 = value; }
        }
        
        private decimal _cap2;
        public decimal Cap2
        {
            get { return _cap2; }
            set { _cap2 = value; }
        }
        
        private decimal _cap3;
        public decimal Cap3
        {
            get { return _cap3; }
            set { _cap3 = value; }
        }
        
        private decimal _total;
        public decimal Total
        {
            get { return _total; }
            set { _total = value; }
        }
        
        private decimal _exento;
        public decimal Exento
        {
            get { return _exento; }
            set { _exento = value; }
        }
        
        private decimal _gravado;
        public decimal Gravado
        {
            get { return _gravado; }
            set { _gravado = value; }
        }
        
        private bool _capturado;
        public bool Capturado
        {
            get { return _capturado; }
            set { _capturado = value; }
        }
        
        private bool _isCanculado;
        public bool IsCanculado
        {
            get { return _isCanculado; }
            set { _isCanculado = value; }
        }
        #endregion

        public NominaEntityObject()
        {
            _ID = 0;
            _claveEmpresa = string.Empty;
            _clavePeriodo = string.Empty;
            _claveTrabajador = string.Empty;
            _nombre = string.Empty;
            _claveConcepto = string.Empty;
            _descripcion = string.Empty;
            _cap1 = 0;
            _cap2 = 0;
            _cap3 = 0;
            _total = 0;
            _exento = 0;
            _gravado = 0;
            _capturado = false;
            _isCanculado = false;
        }
    }
}
