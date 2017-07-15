using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Bluejay.Models;
using System.Security.Principal;
using System.Collections;
using System.Collections.Generic;

namespace Bluejay.Models
{
    // Para agregar datos del usuario, agregue más propiedades a su clase de usuario. Visite http://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string TypeUser { get; set; }

        //Se agrega relacion N-N con la clase ApplictionCompanies, un usuario puede administrar muchas Companias.
        public virtual ICollection<ApplicationCompany> Companies { get; set; }

        public ClaimsIdentity GenerateUserIdentity(ApplicationUserManager manager)
        {            
            // Tenga en cuenta que authenticationType debe coincidir con el valor definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar reclamaciones de usuario personalizadas aquí
            userIdentity.AddClaim(new Claim("Name", this.Name));
            userIdentity.AddClaim(new Claim("Type", this.TypeUser));

            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    //public static partial class IdentityExtensions
    //{
    //    public static string GetName(this IIdentity identity)
    //    {
    //        var user = HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>().FindById(identity.GetUserId());
    //        return (user != null) ? user.Name : string.Empty;
    //    }
    //    public static string GetCompany(this IIdentity identity)
    //    {
    //        var user = HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>().FindById(identity.GetUserId());
    //        return (user != null) ? user.Company : string.Empty;
    //    }
    //}
}

#region Aplicaciones auxiliares
namespace Bluejay
{
    public static class IdentityHelper
    {
        // Se utilizan para XSRF al vincular inicios de sesión externos
        public const string XsrfKey = "XsrfId";

        public const string ProviderNameKey = "providerName";
        public static string GetProviderNameFromRequest(HttpRequest request)
        {
            return request.QueryString[ProviderNameKey];
        }

        public const string CodeKey = "code";
        public static string GetCodeFromRequest(HttpRequest request)
        {
            return request.QueryString[CodeKey];
        }

        public const string UserIdKey = "userId";
        public static string GetUserIdFromRequest(HttpRequest request)
        {
            return HttpUtility.UrlDecode(request.QueryString[UserIdKey]);
        }

        public static string GetResetPasswordRedirectUrl(string code, HttpRequest request)
        {
            var absoluteUri = "/Account/ResetPassword?" + CodeKey + "=" + HttpUtility.UrlEncode(code);
            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
        }

        public static string GetUserConfirmationRedirectUrl(string code, string userId, HttpRequest request)
        {
            var absoluteUri = "/Account/Confirm?" + CodeKey + "=" + HttpUtility.UrlEncode(code) + "&" + UserIdKey + "=" + HttpUtility.UrlEncode(userId);
            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
        }

        private static bool IsLocalUrl(string url)
        {
            return !string.IsNullOrEmpty(url) && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
        }

        public static void RedirectToReturnUrl(string returnUrl, HttpResponse response)
        {
            if (!String.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
            {
                response.Redirect(returnUrl);
            }
            else
            {
                response.Redirect("~/");
            }
        }
    }
}
#endregion
