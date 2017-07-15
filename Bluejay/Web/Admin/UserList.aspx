<%@ Page Title="Lista de usuarios" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="Bluejay.Web.Admin.UserList" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content0" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function grid_users_CustomButtonClick(s, e) {
            var btn = e.buttonID;

            switch (btn)
            {
                case 'btnEditar':
                    //showNotification('top','right');
                    s.StartEditRow(e.visibleIndex);
                    break;
            }
        }
        function grid_users_BeginCallback(s, e) {
            s.cp_success = 'no';
        }

        function grid_users_EndCallback(s, e) {
            if (s.cp_success == 'true')
                showNotification('top', 'center', 'success', "Usuario registrado <b>Correctamente</b>.", 'ti-thumb-up');            
            if (s.cp_success == 'false')
                showNotification('top', 'center', 'danger', "Ocurrio un problema en el registro del usuario. Intente de nuevo por favor.", 'ti-alert');

            s.cp_success = '';            
        }
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="contentPage">
        <dx:ASPxGridView ID="ASPxGridViewUsers" runat="server" ClientInstanceName="grid_users"
            Width="100%" KeyFieldName="Id" AutoGenerateColumns="true" 
            OnDataBinding="ASPxGridViewUsers_DataBinding" 
            OnCustomUnboundColumnData="ASPxGridViewUsers_CustomUnboundColumnData" 
            OnBeforeGetCallbackResult="ASPxGridViewUsers_BeforeGetCallbackResult" 
            OnCellEditorInitialize="ASPxGridViewUsers_CellEditorInitialize" 
            OnCustomColumnDisplayText="ASPxGridViewUsers_CustomColumnDisplayText"  
            OnRowValidating="ASPxGridViewUsers_RowValidating" 
            OnRowInserting="ASPxGridViewUsers_RowInserting" 
            OnRowUpdating="ASPxGridViewUsers_RowUpdating">
            <ClientSideEvents CustomButtonClick="grid_users_CustomButtonClick" BeginCallback="grid_users_BeginCallback" EndCallback="grid_users_EndCallback" />
            <Columns>                
                <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="1" Caption="Nombre">
                    <EditFormSettings Visible="True" VisibleIndex="4" ColumnSpan="2" />
                    <PropertiesTextEdit MaxLength="50"></PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataColumn Name="UserName" FieldName="UserName" VisibleIndex="2" Caption="Usuario" Width="180px">
                    <EditFormSettings Visible="True" VisibleIndex="1" ColumnSpan="2" Caption="Usuario [Email]:" />
                </dx:GridViewDataColumn>

                <dx:GridViewDataTextColumn Name="Password" FieldName="PasswordHash" Visible="false" VisibleIndex="3" Caption="Contraseña" Width="180px">
                    <PropertiesTextEdit Password="True" ClientInstanceName="psweditor" />
                    <EditFormSettings Visible="True" VisibleIndex="2" ColumnSpan="1" />
                    <EditItemTemplate>
                        <dx:ASPxTextBox ID="pswtextbox" runat="server" Text='<%# Bind("PasswordHash") %>'
                            Visible='<%# ASPxGridViewUsers.IsNewRowEditing %>' Password="True">
                            <%--<ClientSideEvents Validation="function(s,e){e.isValid = s.GetText()>5;}" />--%>
                        </dx:ASPxTextBox>
                        <asp:LinkButton ID="LinkButton1" runat="server" Visible='<%#!ASPxGridViewUsers.IsNewRowEditing%>'>Restablecer Contraseña</asp:LinkButton>
                    </EditItemTemplate>
                </dx:GridViewDataTextColumn>
                
                <dx:GridViewDataComboBoxColumn Name="Companies" Visible="false" VisibleIndex="6" Caption="Compañia" Width="70px" UnboundType="String">
                    <EditFormSettings Visible="True" Caption="Compañia" VisibleIndex="8" ColumnSpan="2" />
                    <EditItemTemplate>
                        <dx:ASPxGridLookup ID="ASPxGridLookupCompanias" runat="server" ClientInstanceName="lookupCompanias" 
                            DataSourceID="ObjectDataSourceCompanias" SelectionMode="Multiple" KeyFieldName="Clave" TextFormatString="{0}" 
                            MultiTextSeparator=", " Caption=" " Width="100%" OnInit="ASPxGridLookupCompanias_Init">
                            <Columns>
                                <dx:GridViewCommandColumn ShowSelectCheckbox="True" />
                                <dx:GridViewDataColumn FieldName="Clave" />
                                <dx:GridViewDataColumn FieldName="Nombre" Settings-AllowAutoFilter="False" />
                            </Columns>
                        </dx:ASPxGridLookup>
                    </EditItemTemplate>
                </dx:GridViewDataComboBoxColumn>

                <dx:GridViewDataComboBoxColumn FieldName="TypeUser" VisibleIndex="7" Caption="Grupo" Width="110px">
                    <PropertiesComboBox>
                        <Items>
                            <dx:ListEditItem Text="Administrador" Value="Administrador" />
                            <dx:ListEditItem Text="Supervisor" Value="Supervisor" />
                            <dx:ListEditItem Text="Usuario" Value="Usuario" Selected="true"/>
                        </Items>
                    </PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>                
                <dx:GridViewCommandColumn Caption=" " ButtonRenderMode="Image" VisibleIndex="10" Width="70px" 
                    ShowNewButton="true" 
                    ShowEditButton="false" 
                    ShowDeleteButton="false" 
                    ShowUpdateButton="true" 
                    ShowCancelButton="true">
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnEditar" Image-IconID="actions_edit_16x16devav" Image-ToolTip="Editar"></dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>                    
                </dx:GridViewCommandColumn>
            </Columns>            
            <SettingsCommandButton>
                <NewButton>
                    <Image IconID="actions_newemployee_16x16devav"></Image>
                </NewButton>
                <EditButton>
                    <Image IconID="mail_editcontact_16x16office2013"></Image>
                </EditButton>
                <DeleteButton>
                    <Image IconID="edit_delete_16x16office2013"></Image>
                </DeleteButton>
                <UpdateButton RenderMode="Button">
                    <Styles Style-CssClass="btn btn-wd btn-success"></Styles>
                </UpdateButton>
                <CancelButton RenderMode="Button">
                    <Styles Style-CssClass="btn btn-wd btn-danger"></Styles>
                </CancelButton>
            </SettingsCommandButton>
            <SettingsEditing Mode="PopupEditForm" EditFormColumnCount="2"></SettingsEditing>
            <SettingsText PopupEditFormCaption="Registro de Usuario" />
            <SettingsPopup>
                <EditForm Width="600px" Modal="true" VerticalAlign="Middle" HorizontalAlign="Center" />
            </SettingsPopup>
            <Templates>
                <EditForm>
                    <div style="padding: 4px 4px 3px 4px;">
                        <dx:ASPxGridViewTemplateReplacement ID="Editors" ReplacementType="EditFormEditors" runat="server" />
                    </div>
                    <div style="text-align: right; padding: 2px 5px 10px 2px;">
                        <dx:ASPxGridViewTemplateReplacement id="UpdateButton" ReplacementType="EditFormUpdateButton" runat="server" />
                        <dx:ASPxGridViewTemplateReplacement ID="CancelButton" ReplacementType="EditFormCancelButton" runat="server" />
                    </div>
                </EditForm>
            </Templates>
        </dx:ASPxGridView>
        <asp:ObjectDataSource ID="ObjectDataSourceCompanias" runat="server" 
            TypeName="Bluejay.Core.Business.CompanyBusinessObject" 
            DataObjectTypeName="Bluejay.Core.Entities.CompanyEntityObject" 
            SelectMethod="GetCompanias">
        </asp:ObjectDataSource>
    </div>
</asp:Content>
