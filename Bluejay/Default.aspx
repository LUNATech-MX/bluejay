<%@ Page Title=".:Bluejay:." Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Bluejay._Default" %>

<asp:Content ID="Content0" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        <!-- Javascript -->
        $('#chartDashboardDoc, #chartOrdersDoc').easyPieChart({
	        lineWidth: 6,
	        size: 160,
	        scaleColor: false,
	        trackColor: "rgba(255,255,255,.25)",
	        barColor: "#FFFFFF",
	        animate: ({duration: 5000, enabled: true})

        });
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <strong>Bienvenido</strong>
    <br />
    <br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Web/Reports/ReporteNomina.aspx">Reporte</asp:HyperLink>
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Default2.aspx">Master 2</asp:HyperLink>
</asp:Content>
