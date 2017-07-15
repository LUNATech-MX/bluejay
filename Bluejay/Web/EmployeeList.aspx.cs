using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bluejay.Web
{
    public partial class EmployeeList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Label _title = (Label)Master.FindControl("titlePage");
                _title.Text = "Trabajadores";
            }
        }

        protected string GetIconImageEstatus(GridViewDataItemTemplateContainer container)
        {            
                Bluejay.Core.Entities.EmployeeEntityOnject _EmployeInfo = (Bluejay.Core.Entities.EmployeeEntityOnject)ASPxGridViewEmployees.GetRow(container.VisibleIndex);
                if (_EmployeInfo != null && _EmployeInfo.Activo)
                    return  Bluejay.Core.Utilities.GeneralConfig.ServerPath("Content/Images/employee_up_32x32.png");
                else
                    return Bluejay.Core.Utilities.GeneralConfig.ServerPath("Content/Images/employee_down_32x32.png");
        }

        protected void ASPxGridViewEmployees_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            string clave;
            ASPxGridView grid;            
            string url;

            if (e.ButtonID == "btnNuevo")
            {
                //se obtiene el grid que genero el evento
                grid = (ASPxGridView)sender;
                clave = grid.GetRowValues(e.VisibleIndex, new string[] { "Clave" }).ToString();
                Session["ClaveTrabajador"] = "0";

                url = String.Format("EmployeeEdit.aspx{0}", "");
                DevExpress.Web.ASPxWebControl.RedirectOnCallback(url);
            }
            if (e.ButtonID == "btnEditar")
            {
                //se obtiene el grid que genero el evento
                grid = (ASPxGridView)sender;
                clave = grid.GetRowValues(e.VisibleIndex, new string[] { "Clave" }).ToString();
                Session["ClaveTrabajador"] = clave;

                url = String.Format("EmployeeEdit.aspx{0}", "");
                DevExpress.Web.ASPxWebControl.RedirectOnCallback(url);                
            }
        }
   
        protected void ASPxGridViewEmployees_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            ASPxGridViewEmployees.DataBind();
        }
    }
}