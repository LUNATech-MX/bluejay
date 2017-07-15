using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Bluejay.Core.Entities;

namespace Bluejay.Core.Data
{
    class UsuarioDataObject:BaseDataObject
    {
        #region Properties
        #endregion

        #region Constructor
        public UsuarioDataObject()
        {
            _ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PasswordServiceCustom"].ConnectionString;
        }
        #endregion

        #region Methods
        public int Insert(UsuarioEntityObject UsuarioInfo)
        {
            int nRes;
            string sql;
            string[] parameters;
            object[] values;

            try
            {
                sql = string.Format("insert into {0} (nombre,paterno,materno,login,password,email,telefono) values(@nombre,@apaterno,@amaterno,@login,@password,@email,@telefono);", Fields.DbTableName);

                parameters = new string[] { "@" + Fields.Nombre, "@" + Fields.Paterno, "@" + Fields.Materno, "@" + Fields.Login, "@" + Fields.Password, "@" + Fields.Email, "@" + Fields.Telefono };
                values = new string[] { UsuarioInfo.Nombre, UsuarioInfo.Paterno, UsuarioInfo.Materno, UsuarioInfo.Login, UsuarioInfo.Password, UsuarioInfo.Email, UsuarioInfo.Telefono };

                nRes = ExecuteNonQuery(sql, parameters, values);

                return nRes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(UsuarioEntityObject UsuarioInfo)
        {
            int nRes;
            string sql;
            string[] parameters;
            object[] values;

            try
            {
                sql = string.Format("update {0} set nombre=@nombre, paterno=@paterno, materno=@materno,login=@login, password=@password, email=@email, telefono=@telefono WHERE ({1}={2});", Fields.DbTableName, Fields.Id, UsuarioInfo.Id);

                parameters = new string[] { "@" + Fields.Nombre, "@" + Fields.Paterno, "@" + Fields.Materno, "@" + Fields.Login, "@" + Fields.Password, "@" + Fields.Email, "@" + Fields.Telefono };
                values = new string[] { UsuarioInfo.Nombre, UsuarioInfo.Paterno, UsuarioInfo.Materno, UsuarioInfo.Login, UsuarioInfo.NewPassword, UsuarioInfo.Email, UsuarioInfo.Telefono };

                nRes = ExecuteNonQuery(sql, parameters, values);

                return nRes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete(UsuarioEntityObject UsuarioInfo)
        {
            throw new NotImplementedException();
        }
        public DataTable GetUsuariosTable()
        {
            DataTable dt = null;
            return dt;
        }
        public List<UsuarioEntityObject> GetUsuarios()
        {
            List<UsuarioEntityObject> _UsuariosList = new List<UsuarioEntityObject>();
            return _UsuariosList;
        }
        public UsuarioEntityObject GetUsuario(string User, string Password)
        {
            string sql;
            DataTable dt;            
            UsuarioEntityObject _UserInfo;

            try
            {
                _UserInfo = null;

                sql = string.Format("select usr.*, emp.* from {0} usr inner join Empresas emp on usr.IdEmpresa = emp.IdEmpresa where login='{1}' and password ='{2}';", Fields.DbTableName, User, Password);
                dt = ExecuteDataTable(sql, null, null);

                if (dt != null && dt.Rows.Count > 0)                
                    _UserInfo = GetEntityObject(dt.Rows[0]);
                
                return _UserInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private UsuarioEntityObject GetEntityObject(DataRow row)
        {
            UsuarioEntityObject _UsuarioInfo = new UsuarioEntityObject();

            if (row != null)
            {
                _UsuarioInfo = new UsuarioEntityObject();
                _UsuarioInfo.Id = Convert.ToInt32(row[Fields.Id]);
                _UsuarioInfo.Nombre = row[Fields.Nombre].ToString();
                _UsuarioInfo.Paterno = row[Fields.Paterno].ToString();
                _UsuarioInfo.Materno = row[Fields.Materno].ToString();
                _UsuarioInfo.Login = row[Fields.Login].ToString();
                _UsuarioInfo.Password = row[Fields.Password].ToString();
                _UsuarioInfo.Email = row[Fields.Email].ToString();
                _UsuarioInfo.Telefono = row[Fields.Telefono].ToString();
                _UsuarioInfo.NewPassword = row[Fields.Password].ToString();
                _UsuarioInfo.Configuracion.SystemDatabase = row["db_sistema"].ToString();
                _UsuarioInfo.Configuracion.EstuderDatabase = row["db_estuder"].ToString();
            }

            return _UsuarioInfo;
        }
        #endregion        

        #region Fields
        public class Fields
        {
            public const string DbTableName = "[Users]";
            public const string Id = "IdUser";
            public const string Nombre = "nombre";
            public const string Paterno = "paterno";
            public const string Materno = "materno";
            public const string Login = "login";
            public const string Password = "password";
            public const string Email = "email";
            public const string Telefono = "telefono";
            public const string IdEmpresa = "IdEmpresa";
        }
        #endregion
    }
}
