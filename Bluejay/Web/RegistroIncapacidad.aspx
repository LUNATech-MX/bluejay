<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroIncapacidad.aspx.cs" Inherits="Bluejay.Web.RegistroIncapacidad" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function spin_duracion_ValueChanged(s, e) {
            //var fechaI = dtp_fechaInicial.GetDate();
            //dtp_fechaTermino.SetDate(fechaI + 1);
        }

        function grid_incapacidades_BeginCallback(s, e) {
            s.cp_success = 'no';
        }

        function grid_incapacidades_EndCallback(s, e) {
            if (s.cp_success == 'true')
                showNotification('top', 'center', 'success', "Incapacidad registrada <b>Correctamente</b>.", 'ti-thumb-up');
            if (s.cp_success == 'false')
                showNotification('top', 'center', 'danger', "Ocurrio un problema en el registro de Incapacidad. Intente de nuevo por favor.", 'ti-alert');

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
                        <dx:ASPxGridView ID="ASPxGridViewIncapacidades" runat="server" ClientInstanceName="grid_incapacidades" DataSourceID="ObjectDataSourceIncapacidades"
                            Width="100%" KeyFieldName="Id" AutoGenerateColumns="false" 
                            OnBeforePerformDataSelect="ASPxGridViewIncapacidades_BeforePerformDataSelect" 
                            OnCustomDataCallback="ASPxGridViewIncapacidades_CustomDataCallback"
                            OnInitNewRow="ASPxGridViewIncapacidades_InitNewRow"
                            OnRowValidating="ASPxGridViewIncapacidades_RowValidating"
                            OnRowInserting="ASPxGridViewIncapacidades_RowInserting" 
                            OnRowInserted="ASPxGridViewIncapacidades_RowInserted">
                            <ClientSideEvents BeginCallback="grid_incapacidades_BeginCallback" EndCallback="grid_incapacidades_EndCallback" />
                            <Columns>
                                <dx:GridViewDataColumn FieldName="Id" Visible="false" VisibleIndex="0" Caption="Id" Width="60px" />
                                <dx:GridViewDataColumn FieldName="FechaInicial" VisibleIndex="2" Caption="F. Inicio" Width="80px">
                                    <EditFormSettings VisibleIndex="3" />
                                    <%--<PropertiesEdit ClientInstanceName="dtp_fechaInicial"></PropertiesEdit>--%>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataDateColumn  FieldName="FechaTermino" VisibleIndex="4" Caption="F. Termino" Width="80px">
                                    <EditFormSettings VisibleIndex="4" />
                                    <%--<PropertiesDateEdit ClientInstanceName="dtp_fechaTermino"></PropertiesDateEdit>--%>
                                </dx:GridViewDataDateColumn>                            
                                <dx:GridViewDataColumn FieldName="Folio" VisibleIndex="6" Caption="No. Folio" Width="90px">
                                    <EditFormSettings VisibleIndex="1" />
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataSpinEditColumn FieldName="Duracion" VisibleIndex="8" Caption="Dias" Width="40px">
                                    <EditFormSettings VisibleIndex="2" />
                                    <PropertiesSpinEdit Increment="1" MinValue="1" MaxValue="9999" ClientInstanceName="spin_duracion" ClientSideEvents-ValueChanged="spin_duracion_ValueChanged"></PropertiesSpinEdit>                                
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="RamaSeguro" VisibleIndex="10" Caption="Rama" Width="40px">
                                    <PropertiesComboBox DataSourceID="ObjectDataSourceRamas" ValueField="CLAVE_RAMA" TextField="descripcion"></PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="TipoRiesgo" VisibleIndex="12" Caption="Riesgo" Width="40px">
                                    <PropertiesComboBox DataSourceID="ObjectDataSourceRiesgo" ValueField="CLAVE_RIESGO" TextField="descripcion"></PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="Clasificacion" VisibleIndex="14" Caption="Clasificación" Width="70px">
                                    <PropertiesComboBox DataSourceID="ObjectDataSourceSecuela" ValueField="CLAVE_SECUELA" TextField="descripcion"></PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataCheckColumn FieldName="Anticipadas" VisibleIndex="16" Caption="Anticipadas" Width="50px">

                                </dx:GridViewDataCheckColumn>                            
                                <dx:GridViewDataColumn FieldName="PeriodoAplicar" VisibleIndex="18" Caption="Aplica Periodo" Width="60px" />
                                <dx:GridViewCommandColumn Caption=" " VisibleIndex="20" ButtonRenderMode="Image" ShowNewButton="true" ShowEditButton="false" ShowDeleteButton="true" ShowCancelButton="true" ShowUpdateButton="true">
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
                                <UpdateButton RenderMode="Button" Text="Guardar">
                                    <Styles Style-CssClass="btn btn-wd btn-primary"></Styles>
                                </UpdateButton>
                                <CancelButton RenderMode="Button" Text="Cancelar">
                                    <Styles Style-CssClass="btn btn-wd btn-danger"></Styles>
                                </CancelButton>
                            </SettingsCommandButton>
                            <Styles>
                                <CommandColumn Spacing="3px" />
                            </Styles>
                        </dx:ASPxGridView>
                    </DetailRow>
                </Templates>    
            </dx:ASPxGridView>
            <asp:ObjectDataSource ID="ObjectDataSourceEmployees" runat="server" 
                TypeName="Bluejay.Core.Business.EmployeeBusinessObject" 
                DataObjectTypeName="EmployeeEntityObject" 
                SelectMethod="GetEmployeesActive">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ASPxComboBoxEmpresas" Name="ClaveEmpresa" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjectDataSourceIncapacidades" runat="server" 
                TypeName="Bluejay.Core.Business.IncapacidadBusinessObject"
                DataObjectTypeName="Bluejay.Core.Entities.IncapacidadEntityObject"
                SelectMethod="GetIncapacidadesByTrabajador" 
                InsertMethod="Save" 
                UpdateMethod="Save"
                DeleteMethod="Delete">
                <SelectParameters>
                    <asp:SessionParameter Name="ClaveTrabajador" SessionField="ClaveTrabajador" />
                </SelectParameters>
            </asp:ObjectDataSource>

            <asp:ObjectDataSource ID="ObjectDataSourceRamas" runat="server" 
                TypeName="Bluejay.Core.Business.CatalogoBusinessObject" DataObjectTypeName="System.Data.DataTable" SelectMethod="GetCatalogoRamasImss">
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjectDataSourceRiesgo" runat="server" 
                TypeName="Bluejay.Core.Business.CatalogoBusinessObject" DataObjectTypeName="System.Data.DataTable" SelectMethod="GetCatalogoRiesgoTrabajo">
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjectDataSourceSecuela" runat="server" 
                TypeName="Bluejay.Core.Business.CatalogoBusinessObject" DataObjectTypeName="System.Data.DataTable" SelectMethod="GetCatalogoSecuelasIncapacidad">
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
