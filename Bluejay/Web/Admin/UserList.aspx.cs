using Bluejay.Models;
using DevExpress.Web;
using DevExpress.Web.Data; 
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bluejay.Web.Admin
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetUserList();
                                
                Label _title = (Label)Master.FindControl("titlePage");
                _title.Text = "Usuarios";                
            }
        }
        protected void ASPxGridViewUsers_DataBinding(object sender, EventArgs e)
        {
            List<ApplicationUser> _UsersList = (List<ApplicationUser>)Session["UsersList"];
            ASPxGridViewUsers.DataSource = _UsersList;
        }
        protected void ASPxGridViewUsers_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridViewColumnDataEventArgs e)
        {
            if (e.Column.Caption == "Grupo")
            {                
                e.Value = "Administrador";
            }
        }
        protected void ASPxGridViewUsers_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;

            if (e.Column.FieldName == "Company" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString();
            }
            if (e.Column.Name == "Grupo")
            {
                object obj = ((ASPxGridView)sender).GetRowValues(e.VisibleIndex, new string[] { "Id" });
                string userId = obj.ToString();

                ApplicationDbContext dbc = new ApplicationDbContext();                
                ApplicationUser user = dbc.Users.ToList().Find(x => x.Id == userId);
                
                if (user != null)
                {
                    var claims = user.Claims;
                    //var roles = claims.Where(c => c.ClaimType == ClaimTypes.Role).ToList();
                    var roles = claims.Where(c => c.ClaimType == "role").ToList();
                    if (roles != null && roles.Count > 0)
                    {
                        e.Value = roles[0].ClaimValue;
                        e.DisplayText = roles[0].ClaimValue;
                    }
                }
            }
        }        
        protected void ASPxGridViewUsers_BeforeGetCallbackResult(object sender, EventArgs e)
        {
            //ASPxGridView grid = (ASPxGridView)sender;
            //grid.DataColumns["Confirmar"].EditFormSettings.Visible = grid.IsNewRowEditing ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;            
        }
        protected void ASPxGridViewUsers_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;
            if (e.Column.FieldName == "UserName" && !grid.IsNewRowEditing)            
                e.Editor.ReadOnly = true;

            if (e.Column.Name == "Password" || e.Column.Name == "Confirmar")
                e.Editor.ReadOnly = false;
        }
        protected void ASPxGridViewUsers_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;

            foreach (GridViewColumn column in grid.Columns)
            {
                GridViewDataColumn dataColumn = column as GridViewDataColumn;
                if (dataColumn == null) continue;
                if (e.NewValues[dataColumn.FieldName] == null && dataColumn.Name != "Companies")
                    e.Errors[dataColumn] = string.Format("Favor de especificar el dato [{0}]", dataColumn.Caption);
            }

            //Se valida que no exista otro usuario con el mismo correo
            if (!ValidUserName(e.NewValues["UserName"].ToString()))
                AddError(e.Errors, grid.Columns["UserName"], "[Usuario/Email] ya se encuentra registrado.");

            //Se valida que el nombre sea correcto
            if (e.NewValues["Name"] != null && e.NewValues["Name"].ToString().Length < 2)
                AddError(e.Errors, grid.Columns["Name"], "Nombre debe contener por lo menos 2 caracteres.");

            //Se valida que el nombre sea correcto
            if (e.NewValues["PasswordHash"] != null)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                System.Threading.Tasks.Task<IdentityResult> valid = manager.PasswordValidator.ValidateAsync(e.NewValues["PasswordHash"].ToString());
                if (valid != null && valid.Result != null && valid.Result.Errors != null)
                {
                    string msg = string.Join("", valid.Result.Errors.ToArray());
                    if (msg != null && msg.Trim() != string.Empty)
                        AddError(e.Errors, grid.Columns["Name"], msg);
                }                    
            }
            
            if (string.IsNullOrEmpty(e.RowError) && e.Errors.Count > 0)
                e.RowError = "Favor de corregir todos los errores.";

        }
        protected void ASPxGridViewUsers_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            if (IsValid)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = new ApplicationUser() { Name = e.NewValues["Name"].ToString() , UserName = e.NewValues["UserName"].ToString(), Email = e.NewValues["UserName"].ToString(), TypeUser = e.NewValues["TypeUser"].ToString() };                
                IdentityResult result = manager.Create(user, e.NewValues["PasswordHash"].ToString());
                if (result.Succeeded)
                {
                    // Para obtener más información sobre cómo habilitar la confirmación de cuentas y el restablecimiento de contraseña, visite http://go.microsoft.com/fwlink/?LinkID=320771
                    //string code = manager.GenerateEmailConfirmationToken(user.Id);
                    //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                    //manager.SendEmail(user.Id, "Confirmar cuenta", "Para confirmar la cuenta, haga clic <a href=\"" + callbackUrl + "\">aquí</a>.");

                    //se obtiene el valor del rol seleccionado
                    //ASPxComboBox editor = (ASPxComboBox)ASPxGridViewUsers.FindEditFormTemplateControl("cmbUserType");
                    //string grupo = editor.Text;

                    string[] x = GetLookupCompanies();

                    //se valida si existe el rol de usuario
                    var _context = new ApplicationDbContext();
                    var roleStore = new RoleStore<IdentityRole>(_context);
                    var roleManager = new RoleManager<IdentityRole>(roleStore);
                    if (!roleManager.RoleExists(e.NewValues["TypeUser"].ToString()))
                        _context.Roles.Add(new IdentityRole(e.NewValues["TypeUser"].ToString()));

                    //se agrega el usuario al Rol seleccionado                    
                    manager.AddToRole(user.Id, e.NewValues["TypeUser"].ToString());

                    ASPxGridViewUsers.JSProperties.Add("cp_success", "true");
                }
                else
                {                    
                    ASPxGridViewUsers.JSProperties.Add("cp_success", "false");
                }
            }

            e.Cancel = true;
            ASPxGridViewUsers.CancelEdit();
            GetUserList();
        }
        protected void ASPxGridViewUsers_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            e.Cancel = false;
            ASPxGridViewUsers.CancelEdit();
            ASPxGridViewUsers.DataBind();
        }

        protected void ASPxGridLookupCompanias_Init(object sender, EventArgs e)
        {
            var lookup = (ASPxGridLookup)sender;
            var container = (GridViewEditItemTemplateContainer)lookup.NamingContainer;

            if (container.Grid.IsNewRowEditing)
                return;

            var tagIDs = (string[])container.Grid.GetRowValues(container.VisibleIndex, container.Column.FieldName);
            if (tagIDs != null)
            {
                foreach (var tagID in tagIDs)
                    lookup.GridView.Selection.SelectRowByKey(tagID);
            }
        }

        #region Functions
        private void GetUserList()
        {
            List<ApplicationUser> _UsersList;

            var _db = new ApplicationDbContext();
            _UsersList = _db.Users.ToList();
            Session["UsersList"] = _UsersList;

            ASPxGridViewUsers.DataBind();
        }
        private string[] GetLookupCompanies()
        {
            var column = (GridViewDataColumn)ASPxGridViewUsers.Columns ["Company"];
            var lookup = (ASPxGridLookup)ASPxGridViewUsers.FindEditRowCellTemplateControl(column, "ASPxGridLookupCompanias");
            var tags = lookup.GridView.GetSelectedFieldValues(lookup.KeyFieldName) as List<object>;

            return tags.Select(t => (string)t).ToArray();
        }
        void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn column, string errorText)
        {
            if (errors.ContainsKey(column)) return;
            errors[column] = errorText;
        }
        private bool ValidUserName(string UserName)
        {
            bool result = true;

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByEmail(UserName);
            if (user != null)
                result = false;

            return result;
        }
        private bool ValidPassword(string Password)
        {
            string msg;

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            System.Threading.Tasks.Task<IdentityResult> valid = manager.PasswordValidator.ValidateAsync(Password);

            if (valid != null && valid.Result != null && valid.Result.Errors != null)
                msg = string.Join("", valid.Result.Errors.ToArray());
            return false;
        }

        #endregion
                
    }
}