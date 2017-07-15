using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bluejay.Web
{
    public partial class RegistroIncapacidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Label _title = (Label)Master.FindControl("titlePage");
                _title.Text = "Registro Incapacidades";
            }
        }

        protected void ASPxGridViewIncapacidades_BeforePerformDataSelect(object sender, EventArgs e)
        {
            HttpContext.Current.Session["ClaveTrabajador"] = (sender as DevExpress.Web.ASPxGridView).GetMasterRowKeyValue();
        }
        protected void ASPxGridViewIncapacidades_CustomDataCallback(object sender, DevExpress.Web.ASPxGridViewCustomDataCallbackEventArgs e)
        {

        }
        protected void ASPxGridViewIncapacidades_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["FechaInicial"] = DateTime.Now;
            e.NewValues["Duracion"] = 1;
            e.NewValues["FechaTermino"] = DateTime.Now.AddDays(1);
        }
        protected void ASPxGridViewIncapacidades_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {

        }
        protected void ASPxGridViewIncapacidades_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {            
            e.NewValues["ClaveTrabajador"] = ((ASPxGridView)sender).GetMasterRowKeyValue();
            e.NewValues["Empresa"] = ((ASPxGridView)sender).GetMasterRowFieldValues("Empresa.Clave");
        }

        protected void ASPxGridViewEmployees_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            ASPxGridViewEmployees.DataBind();
        }

        protected void ASPxGridViewIncapacidades_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {
            if (e.Exception == null)
                ((ASPxGridView)sender).JSProperties["cp_success"] = "true";
            else
                ((ASPxGridView)sender).JSProperties["cp_success"] = "false";
        }
    }
}