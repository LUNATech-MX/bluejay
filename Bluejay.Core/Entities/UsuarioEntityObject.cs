using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bluejay.Core.Entities
{
    public class UsuarioEntityObject
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

        string _Nombre;
        public string Nombre
        {
            get
            {
                return _Nombre;
            }
            set
            {
                _Nombre = value;
            }
        }

        string _Login;
        public string Login
        {
            get
            {
                return _Login;
            }
            set
            {
                _Login = value;
            }
        }

        string _Password;
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }

        string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        
        string _db_sistema;
        public string DbSistema
        {
            get
            {
                return _db_sistema;
            }
            set
            {
                _db_sistema = value;
            }
        }

        string _apaterno;
        public string Paterno
        {
            get { return _apaterno; }
            set { _apaterno = value; }
        }
        string _amaterno;
        public string Materno
        {
            get { return _amaterno; }
            set { _amaterno = value; }
        }
        string _telefono;
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
        string _NewPassword;
        public string NewPassword
        {
            get { return _NewPassword; }
            set { _NewPassword = value; }
        }

        ConfiguracionEntityObject _ConfiguracionInfo;
        public ConfiguracionEntityObject Configuracion
        {
            get
            {
                return _ConfiguracionInfo;
            }
            set
            {
                _ConfiguracionInfo = value;
            }
        }
        #endregion

        #region Constructor
        public UsuarioEntityObject()
        {
            _ID = 0;
            _Nombre = "";
            _Login = "";
            _Password = "";
            _NewPassword = "";
            _db_sistema = "";
            _ConfiguracionInfo = new ConfiguracionEntityObject();
        }
        #endregion
    }
}
