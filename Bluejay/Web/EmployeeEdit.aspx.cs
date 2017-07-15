using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bluejay.Web
{
    public partial class EmployeeEdit : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            //Session["ClaveTrabajador"] = "0001";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Label _title = (Label)Master.FindControl("titlePage");
                _title.Text = "Perfil Empleado";
            }
        }
    }
}