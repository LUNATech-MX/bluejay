<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FiltroReporte.ascx.cs" Inherits="Bluejay.Web.Controls.FiltroReporte" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<div id="contentControl">
    <div id="companyFilter">
        <dx:ASPxComboBox ID="ASPxComboBoxCompany" runat="server" ValueType="System.String" Native="true" Width="100%" CssClass="btn dropdown-toggle" 
            ClientInstanceName="cmb_companias" DataSourceID="ObjectDataSourceCompanias" AutoPostBack="false" 
            ValueField="Clave" TextField="Nombre">
        </dx:ASPxComboBox>
    </div>
    <div id="periodoFilter">
    </div>

    <asp:ObjectDataSource ID="ObjectDataSourceCompanias" runat="server" 
        TypeName="Bluejay.Core.Business.CompanyBusinessObject" 
        DataObjectTypeName="CompanyEntityObject" 
        SelectMethod="GetCompanias">
    </asp:ObjectDataSource>
</div>