using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bluejay.Core.Data;
using Bluejay.Core.Entities;

namespace Bluejay.Core.Business
{
    public class UsuarioBusinessObject:BaseBusinessObject 
    {
        private UsuarioDataObject _UsuarioDAO;

        #region Metodos
        public int Save(UsuarioEntityObject UsuarioInfo)
        {
            _UsuarioDAO = new UsuarioDataObject();

            if (!ExistsUser(UsuarioInfo))
                return _UsuarioDAO.Insert(UsuarioInfo);
            else
                return _UsuarioDAO.Update(UsuarioInfo);                   
        }
        public UsuarioEntityObject GetUsuario(string User, string Password)
        {
            _UsuarioDAO = new UsuarioDataObject();
            return _UsuarioDAO.GetUsuario(User, Password);            
        }
        public List<UsuarioEntityObject> GetUsuarios()
        {
            _UsuarioDAO = new UsuarioDataObject();
            return _UsuarioDAO.GetUsuarios();
        }
        public UsuarioEntityObject GetCurrentUsuario()
        {
            UsuarioEntityObject _CurrentUser = null;

            UsuarioEntityObject _UsuarioInfo = null;
            System.Web.HttpContext httpContext = System.Web.HttpContext.Current;
            if (httpContext.ApplicationInstance.Session.Count > 0)
                _UsuarioInfo = (UsuarioEntityObject)httpContext.ApplicationInstance.Session["Usuario"];

            if (_UsuarioInfo != null)
            { 
                _UsuarioDAO = new UsuarioDataObject();
                _CurrentUser = _UsuarioDAO.GetUsuario(_UsuarioInfo.Login, _UsuarioInfo.Password);
            }

            return _CurrentUser;
        }

        public static bool IsUserAuthorized(string User, string Password)
        {
            if (User == "DATAWEB" && Password == "n@p0l3on")
                return true;
            else
                return false;
        }        
        #endregion

        #region Functions
        private bool ExistsUser(UsuarioEntityObject UserInfo)
        {
            UsuarioEntityObject _UserInfo;

            _UsuarioDAO = new UsuarioDataObject();
            _UserInfo = _UsuarioDAO.GetUsuario(UserInfo.Login, UserInfo.Password);

            if (_UserInfo == null)
                return false;
            else
                return true;
        }
        #endregion
    }
}
