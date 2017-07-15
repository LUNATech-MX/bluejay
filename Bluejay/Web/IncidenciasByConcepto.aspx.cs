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
    public partial class IncidenciasByConcepto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {                
                Label _title = (Label)Master.FindControl("titlePage");
                _title.Text = "Incidencias por Concepto";
            }
        }

        protected void ASPxGridViewNomina_BeforePerformDataSelect(object sender, EventArgs e)
        {
            HttpContext.Current.Session["ClaveConcepto"] = (sender as DevExpress.Web.ASPxGridView).GetMasterRowKeyValue();
        }
        
        protected void ASPxGridViewNomina_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;
            ASPxComboBox cmb = (ASPxComboBox) grid.FindEditRowCellTemplateControl((GridViewDataColumn)grid.Columns["ClaveTrabajador"], "cmbEmployee");
            e.NewValues["ClaveTrabajador"] = cmb.Text;
            e.NewValues["ClaveConcepto"] = ((ASPxGridView)sender).GetMasterRowKeyValue();

            //se obtiene la empresa del trabajador seleccionado
            EmployeeBusinessObject _EmployeeBAL = new EmployeeBusinessObject();
            EmployeeEntityOnject _EmployeeInfo = _EmployeeBAL.GetEmployee(e.NewValues["ClaveTrabajador"].ToString());

            PeriodoBusinessObject _PeriodoBAL = new PeriodoBusinessObject();
            PeriodoEntityObject _PeriodoInfo = _PeriodoBAL.GetPeriodoActualByNominaEmpresa(_EmployeeInfo.ClaveNomina, _EmployeeInfo.Empresa.Clave);

            e.NewValues["Empresa"] = _EmployeeInfo.Empresa.Clave;
            e.NewValues["Periodo"] = _PeriodoInfo.ClavePeriodo;
        }

        protected void ASPxGridViewNomina_CustomDataCallback(object sender, ASPxGridViewCustomDataCallbackEventArgs e)
        {
            DevExpress.Web.ASPxGridView grid = (DevExpress.Web.ASPxGridView)sender;
            object employeeID = e.Parameters;
            string clave = employeeID.ToString().Trim();

            //se obtiene el empleado mediante el ID            
            EmployeeBusinessObject _EmployeeBAL = new EmployeeBusinessObject();
            EmployeeEntityOnject _EmployeeInfo = _EmployeeBAL.GetEmployee(clave);
            
            if (_EmployeeInfo != null)
            {                
                e.Result = new string[] { _EmployeeInfo.Clave, _EmployeeInfo.NombreCompleto };
            }
            
        }
    }
}