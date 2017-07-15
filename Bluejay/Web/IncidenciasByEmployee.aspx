<%@ Page Title="Incidencia por Trabajador" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IncidenciasByEmployee.aspx.cs" Inherits="Bluejay.Web.IncidenciasByEmployee" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content0" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        var lastConcepto = null;

        //funciones que permiten actualizar el valor de las celdas del grid al seleccionar trabajador
        function cmbConcepto_SelectedIndexChanged(s, e) {
            grid_nomina.GetValuesOnCustomCallback(s.GetValue(), OnGetValuesOnCustomCallbackComplete);
        }
        function OnGetValuesOnCustomCallbackComplete(values) {
            //alert('Id = ' + values[0] + ';\Codigo = ' + values[1] + ';\Unidades = ' + values[2] + ';\Description = ' + values[3] + ';\Precio = ' + values[4] + '-->[' + values.toString() + ']');            
            grid_nomina.SetEditValue('Descripcion', values[1]);            
        }

        function grid_nomina_BeginCallback(s, e) {
            s.cp_success = 'no';
        }

        function grid_nomina_EndCallback(s, e) {
            if (s.cp_success == 'true')
                showNotification('top', 'center', 'success', "Incidencia registrada <b>Correctamente</b>.", 'ti-thumb-up');
            if (s.cp_success == 'false')
                showNotification('top', 'center', 'danger', "Ocurrio un problema en el registro de Incidencia. Intente de nuevo por favor.", 'ti-alert');

            s.cp_success = '';
        }
    </script>
    <style type="text/css">
        .invisible {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
                        <dx:ASPxGridView ID="ASPxGridViewNomina" runat="server" ClientInstanceName="grid_nomina" DataSourceID="ObjectDataSourceNomina" 
                            Width="100%" KeyFieldName="Id" AutoGenerateColumns="false" 
                            OnBeforePerformDataSelect="ASPxGridViewNomina_BeforePerformDataSelect"
                            OnCustomDataCallback="ASPxGridViewNomina_CustomDataCallback" 
                            OnStartRowEditing="ASPxGridViewNomina_StartRowEditing" 
                            OnRowValidating="ASPxGridViewNomina_RowValidating"
                            OnRowInserting="ASPxGridViewNomina_RowInserting" 
                            OnRowInserted="ASPxGridViewNomina_RowInserted">
                            <ClientSideEvents BeginCallback="grid_nomina_BeginCallback" EndCallback="grid_nomina_EndCallback" />
                            <Columns>
                                <dx:GridViewDataColumn FieldName="Empresa" VisibleIndex="0" Caption="Empresa" Visible="false" />
                                <dx:GridViewDataColumn FieldName="Periodo" VisibleIndex="0" Caption="Periodo" Visible="false" />                                
                                <dx:GridViewDataColumn FieldName="ClaveTrabajador" VisibleIndex="0" Caption="Employee" Visible="false">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataTextColumn FieldName="ClaveConcepto" VisibleIndex="1" Caption="Clave" Width="60px">
                                    <EditItemTemplate>
                                        <dx:ASPxComboBox ID="cmbConcepto" runat="server" ClientInstanceName="cmbConcepto" DataSourceID="ObjectDataSourceConceptos" 
                                            ValueType="System.String" TextFormatString="{0}" ValueField="Clave" IncrementalFilteringMode="Contains" DropDownStyle="DropDownList">
                                            <ClientSideEvents SelectedIndexChanged="cmbConcepto_SelectedIndexChanged" />
                                            <Columns>
                                                <dx:ListBoxColumn FieldName="Clave" Caption="Clave" Visible="true" Width="70px"/>
                                                <dx:ListBoxColumn FieldName="Descripcion" Caption="Descripcion" Visible="true" Width="140px" />
                                            </Columns>                                        
                                        </dx:ASPxComboBox>
                                    </EditItemTemplate>
                                </dx:GridViewDataTextColumn>

                                <dx:GridViewDataColumn FieldName="Descripcion" VisibleIndex="2" Caption="Concepto" />
                                <dx:GridViewDataSpinEditColumn FieldName="Cap1" VisibleIndex="5" Caption="Dias" Width="100px">
                                    <HeaderStyle HorizontalAlign="Center" />                                
                                </dx:GridViewDataSpinEditColumn>                            
                                <dx:GridViewDataSpinEditColumn FieldName="Cap2" VisibleIndex="6" Caption="Horas" Width="100px">
                                    <HeaderStyle HorizontalAlign="Center" />                              
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="Cap3" VisibleIndex="7" Caption="Importe" Width="100px">
                                    <HeaderStyle HorizontalAlign="Center" />                                
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="Total" VisibleIndex="8" Caption="Total" Width="100px">
                                    <PropertiesSpinEdit Style-CssClass="invisible" />
                                    <EditFormSettings Visible="False" />
                                    <HeaderStyle HorizontalAlign="Center" />                                
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewCommandColumn Caption=" " VisibleIndex="15" ButtonRenderMode="Image" ShowNewButton="true" ShowEditButton="false" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true">
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
                                    <Image IconID="actions_delete_16x16devav"></Image>
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
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceEmployees" runat="server" 
            TypeName="Bluejay.Core.Business.EmployeeBusinessObject" 
            DataObjectTypeName="EmployeeEntityObject" 
            SelectMethod="GetEmployees">
            <SelectParameters>
                <asp:ControlParameter ControlID="ASPxComboBoxEmpresas" Name="ClaveEmpresa" PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceNomina" runat="server" 
            TypeName="Bluejay.Core.Business.NominaBusinessObject" 
            DataObjectTypeName="Bluejay.Core.Entities.NominaEntityObject" 
            SelectMethod="GetNominaByEmployee" 
            InsertMethod="Save" 
            UpdateMethod="Save" 
            DeleteMethod="Delete">
            <SelectParameters>
                <asp:SessionParameter Name="ClaveTrabajador" SessionField="ClaveTrabajador" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceConceptos" runat="server" 
            TypeName="Bluejay.Core.Business.ConceptoBusinessObject" 
            DataObjectTypeName="Bluejay.Core.Entities.ConceptoEntityObject" 
            SelectMethod="GetConceptos">
        </asp:ObjectDataSource>
    </div>
</asp:Content>

