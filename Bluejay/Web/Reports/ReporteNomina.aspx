<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteNomina.aspx.cs" Inherits="Bluejay.Web.Reports.ReporteNomina" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/Web/Controls/FiltroReporte.ascx" TagPrefix="uc1" TagName="FiltroReporte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="contentPage">
        <dx:ASPxPageControl ID="ASPxPageControl" runat="server" Width="100%">
            <TabPages>
                <dx:TabPage Text="Filtro">
                    <ContentCollection>
                        <dx:ContentControl>                            
                            <uc1:FiltroReporte runat="server" ID="FiltroReporte" />
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
                <dx:TabPage Text="Reporte">
                    <ContentCollection>

                    </ContentCollection>
                </dx:TabPage>
            </TabPages>
        </dx:ASPxPageControl>
    </div>
</asp:Content>
