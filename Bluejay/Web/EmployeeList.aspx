<%@ Page Title="Trabajadores" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="Bluejay.Web.EmployeeList" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content0" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function grid_employees_CustomButtonClick(s, e) {
            if (e.buttonID == "btnEditar") {
                alert("Hola 1");
                grid_employees.GetSelectedFieldValues('Clave', OnGetSelectedFieldValues);
                e.processOnServer = false;
            }
        }

        function OnGetSelectedFieldValues(selectedValues) {            
            if (selectedValues.length == 0) return;            
            switch (btn) {
                case 'btnEditar':
                    alert("Hola");
                    '<% Session["ClaveTrabajador"] = "' + userName + '"; %>';
                    var url = 'PreInvoiceEdit.aspx?docId=' + selectedValues[0][1].toString() + '&bookId=' + selectedValues[0][0].toString() + '&serie=' + selectedValues[0][2].toString();
                    window.location.assign(url);
                    break;                
                default:
                    break;
            }
        }
    </script>
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
                Width="100%" KeyFieldName="Id" AutoGenerateColumns="false" EnableRowsCache="false" 
                OnCustomCallback="ASPxGridViewEmployees_CustomCallback" 
                OnCustomButtonCallback="ASPxGridViewEmployees_CustomButtonCallback">
                <%--<ClientSideEvents CustomButtonClick="grid_employees_CustomButtonClick" />--%>
                <Columns>
                    <dx:GridViewDataColumn FieldName="Clave" VisibleIndex="1" Caption="Id" Width="50px" />
                    <dx:GridViewDataColumn FieldName="NombreCompleto" VisibleIndex="5" Caption="Nombre" />
                    <dx:GridViewDataColumn FieldName="FechaIngreso" VisibleIndex="10" Caption="F. Ingreso" Width="80px">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center" />
                    </dx:GridViewDataColumn>
                    <dx:GridViewDataColumn FieldName="FechaBaja" VisibleIndex="15" Caption="F. Baja" Width="80px">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center" />
                    </dx:GridViewDataColumn>
                    <dx:GridViewDataTextColumn FieldName="Activo" VisibleIndex="20" Caption="Estatus" Width="40px">
                        <DataItemTemplate>
                            <dx:ASPxImage runat="server" ID="icon" ImageUrl="<%# GetIconImageEstatus(Container) %>"
                                Visible="true" Width="18px" Height="18px" />
                        </DataItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewCommandColumn VisibleIndex="22" Caption=" " ButtonRenderMode="Image" ShowNewButton="false" ShowEditButton="false" Width="30px">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CustomButtons>
                            <dx:GridViewCommandColumnCustomButton ID="btnEditar" Image-IconID="actions_edit_16x16devav" Image-ToolTip="Editar"></dx:GridViewCommandColumnCustomButton>
                            <dx:GridViewCommandColumnCustomButton ID="btnNuevo" Image-IconID="actions_newitem_16x16devav" Image-ToolTip="Nuevo"></dx:GridViewCommandColumnCustomButton>
                        </CustomButtons>
                    </dx:GridViewCommandColumn>                
                </Columns>
                <SettingsCommandButton>
                    <EditButton>
                        <Image IconID="actions_edit_16x16devav"></Image>
                    </EditButton>
                    <NewButton>
                        <Image IconID="actions_newcustomers_32x32devav">   </Image>
                    </NewButton>
                </SettingsCommandButton>
                <SettingsSearchPanel CustomEditorID="txtFiltro" />                
            </dx:ASPxGridView>
            <asp:ObjectDataSource ID="ObjectDataSourceEmployees" runat="server" 
                TypeName="Bluejay.Core.Business.EmployeeBusinessObject" 
                DataObjectTypeName="Bluejay.Core.Entities.EmployeeEntityOnject" 
                SelectMethod="GetEmployees">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ASPxComboBoxEmpresas" Name="ClaveEmpresa" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>