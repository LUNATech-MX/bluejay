<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroAusentismo.aspx.cs" Inherits="Bluejay.Web.RegistroAusentismo" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v16.1, Version=16.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        var lastConcepto = null;

        //funciones que permiten actualizar el valor de las celdas del grid al seleccionar trabajador
        function cmbClave_SelectedIndexChanged(s, e) {
            grid_ausentismos.GetValuesOnCustomCallback(s.GetValue(), OnGetValuesOnCustomCallbackComplete);
        }
        function OnGetValuesOnCustomCallbackComplete(values) {
            //alert('Id = ' + values[0] + ';\Codigo = ' + values[1] + ';\Unidades = ' + values[2] + ';\Description = ' + values[3] + ';\Precio = ' + values[4] + '-->[' + values.toString() + ']');            
            grid_ausentismos.SetEditValue('Descripcion', values[1]);
        }

        function grid_ausentismos_BeginCallback(s, e) {
            s.cp_success = 'no';
        }

        function grid_ausentismos_EndCallback(s, e) {
            if (s.cp_success == 'true')
                showNotification('top', 'center', 'success', "Ausentismo registrado <b>Correctamente</b>.", 'ti-thumb-up');
            if (s.cp_success == 'false')
                showNotification('top', 'center', 'danger', "Ocurrio un problema en el registro del ausentismo. Intente de nuevo por favor.", 'ti-alert');

            s.cp_success = '';
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="contentPage">
        <div id="panelFilter" style="width:100%;">
            <div style="width:80%; float:left; margin-right:10px;">
                <dx:ASPxComboBox ID="ASPxComboBoxEmpresas" runat="server" ValueType="System.String" Native="true" Width="100%" CssClass="btn dropdown-toggle"
                    ClientInstanceName="cmb_companias" DataSourceID="ObjectDataSourceCompanias" AutoPostBack="false"
                    ValueField="Clave" TextField="Nombre">
                    <ClientSideEvents SelectedIndexChanged="function(s,e){ grid_employees.PerformCallback();}" />
                </dx:ASPxComboBox>     
            </div>       
            <div style="width:19%; float:left;">
                <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-search"></i></span>
                    <dx:ASPxTextBox ID="txtFiltro" runat="server" Text="" ClientInstanceName="txtFiltro" Native="true" CssClass="form-control" Width="100%" NullText="Buscar..." AutoPostBack="false">                        
                    </dx:ASPxTextBox>
                </div>           
            </div>

            <asp:ObjectDataSource ID="ObjectDataSourceCompanias" runat="server" 
                TypeName="Bluejay.Core.Business.CompanyBusinessObject" 
                DataObjectTypeName="CompanyEntityObject" 
                SelectMethod="GetCompanias">
            </asp:ObjectDataSource>                     
        </div>
        <div id="grid">
            <dx:ASPxGridView ID="ASPxGridViewEmployees" runat="server" ClientInstanceName="grid_employees" DataSourceID="ObjectDataSourceEmployees" 
                Width="100%" KeyFieldName="Clave" AutoGenerateColumns="false" EnableRowsCache="false" 
                OnCustomCallback="ASPxGridViewEmployees_CustomCallback">
                <SettingsCommandButton>
                    <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>
                    <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
                </SettingsCommandButton>
                <Columns>
                    <dx:GridViewDataColumn FieldName="Clave" VisibleIndex="1" Caption="Clave" Width="60px" />
                    <dx:GridViewDataColumn FieldName="NombreCompleto" VisibleIndex="2" Caption="Nombre" />
                    <dx:GridViewDataColumn FieldName="Empresa.Clave" VisibleIndex="3" Caption="Empresa" Width="90px" />
                </Columns>
                <Settings ShowFooter="false" />
                <SettingsPager PageSize="12" AlwaysShowPager="true"></SettingsPager> 
                <SettingsBehavior ColumnResizeMode="Control" />
                <SettingsDetail ShowDetailRow="true" />
                <SettingsSearchPanel CustomEditorID="txtFiltro" />
                <Templates>
                    <DetailRow>
                        <dx:ASPxGridView ID="ASPxGridViewAusentismos" runat="server" ClientInstanceName="grid_ausentismos" DataSourceID="ObjectDataSourceAusentismos"
                            Width="100%" KeyFieldName="Id" AutoGenerateColumns="false" 
                            OnBeforePerformDataSelect="ASPxGridViewAusentismos_BeforePerformDataSelect" 
                            OnCustomDataCallback="ASPxGridViewAusentismos_CustomDataCallback"
                            OnCustomButtonInitialize="ASPxGridViewAusentismos_CustomButtonInitialize" 
                            OnInitNewRow="ASPxGridViewAusentismos_InitNewRow"
                            OnRowValidating="ASPxGridViewAusentismos_RowValidating"
                            OnRowInserting="ASPxGridViewAusentismos_RowInserting" 
                            OnRowInserted="ASPxGridViewAusentismos_RowInserted">
                            <ClientSideEvents BeginCallback="grid_ausentismos_BeginCallback" EndCallback="grid_ausentismos_EndCallback" />
                            <Columns>
                                <dx:GridViewDataColumn FieldName="Id" Visible="false" VisibleIndex="0" Caption="Id" Width="60px" />                                
                                <dx:GridViewDataDateColumn FieldName="FechaAusentismo" VisibleIndex="1" Caption="F. Ausentismo" Width="100px" SortOrder="Descending">
                                    <EditFormSettings VisibleIndex="3" />
                                    <HeaderStyle HorizontalAlign="Center" />                                    
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="ClaveAusentismo" VisibleIndex="2" Caption="Tipo" Width="140px">
                                    <PropertiesComboBox ValueField="CLAVE_AUSENTISMO" TextField="CLAVE_DESCRIPCION" ClientInstanceName="cmbClave" DataSourceID="ObjectDataSourceAusentismosTable">
                                        <ClientSideEvents SelectedIndexChanged="cmbClave_SelectedIndexChanged" />
                                    </PropertiesComboBox>
                                    <EditFormSettings VisibleIndex="1" />
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataColumn FieldName="Descripcion" VisibleIndex="3" Caption="Descripción">
                                    <EditFormSettings VisibleIndex="2" />
                                </dx:GridViewDataColumn>
                                <dx:GridViewCommandColumn Caption=" " VisibleIndex="20" Width="80px" ButtonRenderMode="Image" ShowNewButton="true" ShowEditButton="false" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true">
                                    <%--<CustomButtons>
                                        <dx:GridViewCommandColumnCustomButton ID="btnDelete">
                                            <Image IconID="edit_delete_16x16office2013" ToolTip="Eliminar"></Image>
                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>--%>
                                </dx:GridViewCommandColumn>
                            </Columns>
                            <SettingsCommandButton>
                                <NewButton>
                                    <Image IconID="actions_newopportunities_16x16devav"></Image>
                                </NewButton>
                                <EditButton>
                                    <Image IconID="actions_edit_16x16devav"></Image>
                                </EditButton>
                                <DeleteButton>
                                    <Image IconID="edit_delete_16x16office2013"></Image>
                                </DeleteButton>
                                <UpdateButton>
                                    <Image IconID="actions_save_16x16devav"></Image>
                                </UpdateButton>
                                <CancelButton>
                                    <Image IconID="actions_cancel_16x16"></Image>
                                </CancelButton>
                            </SettingsCommandButton>
                            <SettingsEditing Mode="Inline"></SettingsEditing>
                            <Styles>
                                <CommandColumn Spacing="3px" />
                            </Styles>
                        </dx:ASPxGridView>
                    </DetailRow>
                </Templates>    
            </dx:ASPxGridView>
            <asp:ObjectDataSource ID="ObjectDataSourceEmployees" runat="server" 
                TypeName="Bluejay.Core.Business.EmployeeBusinessObject" 
                DataObjectTypeName="Bluejay.Core.Entities.EmployeeEntityOnject" 
                SelectMethod="GetEmployeesActive">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ASPxComboBoxEmpresas" Name="ClaveEmpresa" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjectDataSourceAusentismos" runat="server" 
                TypeName="Bluejay.Core.Business.AusentismoBusinessObject"
                DataObjectTypeName="Bluejay.Core.Entities.AusentismoEntityObject"
                SelectMethod="GetAusentismosByTrabajador" 
                InsertMethod="Save" 
                UpdateMethod="Save" 
                DeleteMethod="Delete">
                <SelectParameters>
                    <asp:SessionParameter Name="ClaveTrabajador" SessionField="ClaveTrabajador" />
                </SelectParameters>
            </asp:ObjectDataSource>

            <asp:ObjectDataSource ID="ObjectDataSourceAusentismosTable" runat="server" 
                TypeName="Bluejay.Core.Business.CatalogoBusinessObject" DataObjectTypeName="System.Data.DataTable" SelectMethod="GetCatalogoAusentismos">
            </asp:ObjectDataSource>
        </div>
    </div>    
</asp:Content>
