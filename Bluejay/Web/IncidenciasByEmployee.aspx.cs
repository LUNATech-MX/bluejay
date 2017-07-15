using Bluejay.Core.Business;
using Bluejay.Core.Entities;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bluejay.Web
{
    public partial class IncidenciasByEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Label _title = (Label)Master.FindControl("titlePage");
                _title.Text = "Incidencias por Trabajador";
            }
        }

        protected void ASPxGridViewEmployees_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            ASPxGridViewEmployees.DataBind();
        }

        protected void ASPxGridViewNomina_BeforePerformDataSelect(object sender, EventArgs e)
        {
            HttpContext.Current.Session["ClaveTrabajador"] = (sender as DevExpress.Web.ASPxGridView).GetMasterRowKeyValue();
        }        
        protected void ASPxGridViewNomina_CustomDataCallback(object sender, ASPxGridViewCustomDataCallbackEventArgs e)
        {
            DevExpress.Web.ASPxGridView grid = (DevExpress.Web.ASPxGridView)sender;
            object conceptoID = e.Parameters;
            string clave = conceptoID.ToString().Trim();

            //se obtiene el empleado mediante el ID            
            ConceptoBusinessObject _ConceptoBAL = new ConceptoBusinessObject();
            ConceptoEntityObject _ConceptoInfo = _ConceptoBAL.GetConcepto(clave);

            if (_ConceptoInfo != null)
            {
                e.Result = new string[] { _ConceptoInfo.Clave, _ConceptoInfo.Descripcion };
            }
        }
        protected void ASPxGridViewNomina_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
           
        }
        protected void ASPxGridViewNomina_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {

        }
        protected void ASPxGridViewNomina_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;
            ASPxComboBox cmb = (ASPxComboBox)grid.FindEditRowCellTemplateControl((GridViewDataColumn)grid.Columns["ClaveConcepto"], "cmbConcepto");
            e.NewValues["ClaveConcepto"] = cmb.Text;
            e.NewValues["ClaveTrabajador"] = ((ASPxGridView)sender).GetMasterRowKeyValue();

            //se obtiene la empresa del trabajador seleccionado
            EmployeeBusinessObject _EmployeeBAL = new EmployeeBusinessObject();
            EmployeeEntityOnject _EmployeeInfo = _EmployeeBAL.GetEmployee(e.NewValues["ClaveTrabajador"].ToString());

            PeriodoBusinessObject _PeriodoBAL = new PeriodoBusinessObject();
            PeriodoEntityObject _PeriodoInfo = _PeriodoBAL.GetPeriodoActualByNominaEmpresa(_EmployeeInfo.ClaveNomina, _EmployeeInfo.Empresa.Clave);

            e.NewValues["Empresa"] = _EmployeeInfo.Empresa.Clave;
            e.NewValues["Periodo"] = _PeriodoInfo.ClavePeriodo;
        }
        protected void ASPxGridViewNomina_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {
            if (e.Exception == null)
                ((ASPxGridView)sender).JSProperties["cp_success"] = "true";
            else
                ((ASPxGridView)sender).JSProperties["cp_success"] = "false";
        }

        
    }
}