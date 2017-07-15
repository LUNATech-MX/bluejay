using DevExpress.Web.ASPxScheduler;
using DevExpress.XtraScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bluejay.Core.Business;
using System.Data;
using DevExpress.Web;

namespace Bluejay.Web
{
    public partial class RegistroAusentismo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Label _title = (Label)Master.FindControl("titlePage");
                _title.Text = "Registro Ausentismos";
            }
        }
        protected void ASPxGridViewEmployees_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            ASPxGridViewEmployees.DataBind();
        }
        protected void ASPxGridViewAusentismos_BeforePerformDataSelect(object sender, EventArgs e)
        {
            HttpContext.Current.Session["ClaveTrabajador"] = (sender as DevExpress.Web.ASPxGridView).GetMasterRowKeyValue();
        }
        protected void ASPxGridViewAusentismos_CustomDataCallback(object sender, DevExpress.Web.ASPxGridViewCustomDataCallbackEventArgs e)
        {
            object ausentismoID = e.Parameters;
            string clave = ausentismoID.ToString().Trim();

            CatalogoBusinessObject _CatalogosBAL = new CatalogoBusinessObject();
            DataTable dt = _CatalogosBAL.GetCatalogoAusentismos();

            DataRow[] rows = dt.Select(string.Format("CLAVE_AUSENTISMO = '{0}'", clave));
            if (rows != null && rows.Length > 0)
                e.Result = new string[] { rows[0]["CLAVE_AUSENTISMO"].ToString(), rows[0]["descripcion"].ToString() };

        }
        protected void ASPxGridViewAusentismos_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;
            if (e.ButtonID == "btnDelete" && !grid.IsNewRowEditing && grid.GetRowValues(e.VisibleIndex, "ClaveAusentismo").ToString().Trim() == "V")
            {
                e.Visible = DevExpress.Utils.DefaultBoolean.False;
            }
        }
        protected void ASPxGridViewAusentismos_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["FechaAusentismo"] = DateTime.Now;
        }
        protected void ASPxGridViewAusentismos_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {

        }
        protected void ASPxGridViewAusentismos_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            e.NewValues["ClaveTrabajador"] = ((ASPxGridView)sender).GetMasterRowKeyValue();
            e.NewValues["Empresa"] = ((ASPxGridView)sender).GetMasterRowFieldValues("Empresa.Clave");
        }

        protected void ASPxGridViewAusentismos_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {
            if (e.Exception == null)            
                ((ASPxGridView)sender).JSProperties["cp_success"] = "true";
            else
                ((ASPxGridView)sender).JSProperties["cp_success"] = "false";
        }
    }
}