<%@ Page Title="Incidencia por Concepto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IncidenciasByConcepto.aspx.cs" Inherits="Bluejay.Web.IncidenciasByConcepto" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content0" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        var lastEmployee = null;

        //funciones que permiten actualizar el valor de las celdas del grid al seleccionar trabajador
        function cmbEmployee_SelectedIndexChanged(s, e) {
            grid_nomina.GetValuesOnCustomCallback(s.GetValue(), OnGetValuesOnCustomCallbackComplete);
        }
        function OnGetValuesOnCustomCallbackComplete(values) {
            //alert('Id = ' + values[0] + ';\Codigo = ' + values[1] + ';\Unidades = ' + values[2] + ';\Description = ' + values[3] + ';\Precio = ' + values[4] + '-->[' + values.toString() + ']');            
            grid_nomina.SetEditValue('Nombre', values[1]);            
        }

        function grid_nomina_CustomButtonClick(s, e) {
            alert("guardado");
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
                    ClientInstanceName="cmb_companias" AutoPostBack="false"
                    ValueField="Clave" TextField="Nombre" Enabled="false">
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
            <dx:ASPxGridView ID="ASPxGridViewConceptos" runat="server" ClientInstanceName="grid_conceptos" DataSourceID="ObjectDataSourceConceptos" 
                Width="100%" KeyFieldName="Clave" AutoGenerateColumns="false">
                <Columns>
                    <dx:GridViewDataColumn FieldName="Clave" VisibleIndex="1" Caption="Clave" Width="50px">
                    </dx:GridViewDataColumn>
                    <dx:GridViewDataColumn FieldName="Descripcion" VisibleIndex="2" Caption="Descripción" />
                </Columns>                
                <Settings ShowFooter="false" />
                <SettingsPager PageSize="12" AlwaysShowPager="true"></SettingsPager> 
                <SettingsBehavior ColumnResizeMode="Disabled" />
                <SettingsDetail ShowDetailRow="true" />
                <SettingsSearchPanel CustomEditorID="txtFiltro" />
                <Templates>
                    <DetailRow>
                        <dx:ASPxGridView ID="ASPxGridViewNomina" runat="server" ClientInstanceName="grid_nomina" DataSourceID="ObjectDataSourceNomina" 
                            Width="100%" KeyFieldName="Id" AutoGenerateColumns="false" 
                            OnBeforePerformDataSelect="ASPxGridViewNomina_BeforePerformDataSelect"                         
                            OnRowInserting="ASPxGridViewNomina_RowInserting" 
                            OnCustomDataCallback="ASPxGridViewNomina_CustomDataCallback">
                            <ClientSideEvents CustomButtonClick="grid_nomina_CustomButtonClick" />
                            <Columns>
                                <dx:GridViewDataColumn FieldName="Id" VisibleIndex="0" Caption="ID" Visible="false" />
                                <dx:GridViewDataColumn FieldName="Empresa" VisibleIndex="0" Caption="Empresa" Visible="false" />
                                <dx:GridViewDataColumn FieldName="Periodo" VisibleIndex="0" Caption="Periodo" Visible="false" />                                
                                <dx:GridViewDataColumn FieldName="ClaveConcepto" VisibleIndex="0" Caption="Employee" Visible="false">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataTextColumn FieldName="ClaveTrabajador" VisibleIndex="1" Caption="Clave" Width="60px">
                                    <EditItemTemplate>
                                        <dx:ASPxComboBox ID="cmbEmployee" runat="server" ClientInstanceName="cmbEmployee" DataSourceID="ObjectDataSourceEmployees" 
                                            ValueType="System.String" TextFormatString="{0}" ValueField="Clave" IncrementalFilteringMode="Contains" DropDownStyle="DropDownList">
                                            <ClientSideEvents SelectedIndexChanged="cmbEmployee_SelectedIndexChanged" />
                                            <Columns>
                                                <dx:ListBoxColumn FieldName="Clave" Caption="Clave" Visible="true" Width="70px"/>
                                                <dx:ListBoxColumn FieldName="NombreCompleto" Caption="Nombre" Visible="true" Width="140px" />
                                            </Columns>
                                        </dx:ASPxComboBox>
                                    </EditItemTemplate>
                                </dx:GridViewDataTextColumn>

                                <dx:GridViewDataColumn FieldName="Nombre" VisibleIndex="2" Caption="Trabajador" />
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
        <asp:ObjectDataSource ID="ObjectDataSourceConceptos" runat="server" 
            TypeName="Bluejay.Core.Business.ConceptoBusinessObject" 
            DataObjectTypeName="Bluejay.Core.Entities.ConceptoEntityObject" 
            SelectMethod="GetConceptos">            
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceNomina" runat="server" 
            TypeName="Bluejay.Core.Business.NominaBusinessObject" 
            DataObjectTypeName="Bluejay.Core.Entities.NominaEntityObject" 
            SelectMethod="GetNominaByConcepto" 
            InsertMethod="Save" 
            UpdateMethod="Save" 
            DeleteMethod="Delete">
            <SelectParameters>
                <asp:SessionParameter Name="ClaveConcepto" SessionField="ClaveConcepto" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceEmployees" runat="server" 
            TypeName="Bluejay.Core.Business.EmployeeBusinessObject" 
            DataObjectTypeName="EmployeeEntityObject" 
            SelectMethod="GetEmployees">
        </asp:ObjectDataSource>        
    </div>
</asp:Content>
