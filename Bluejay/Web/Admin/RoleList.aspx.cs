using Bluejay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bluejay.Web.Admin
{
    public partial class RoleList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GridViewRoles.DataSource = GetRolesList();
                GridViewRoles.DataBind();
            }
        }

        private List<Microsoft.AspNet.Identity.EntityFramework.IdentityRole> GetRolesList()
        {
            List<Microsoft.AspNet.Identity.EntityFramework.IdentityRole> _RolesList; 

            var _db = new ApplicationDbContext();
            _RolesList = _db.Roles.ToList();

            return _RolesList;
        }
    }
}