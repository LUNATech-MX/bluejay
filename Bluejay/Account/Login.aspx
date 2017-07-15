<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Bluejay.Account.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>.::Blackbird Project::.</title>
        <link rel='stylesheet prefetch' href='http://netdna.bootstrapcdn.com/bootstrap/3.0.2/css/bootstrap.min.css' />
        <link href="Content/Login.css" rel="stylesheet" type="text/css"/>
    </head>
    <body>
        <div class="wrapper">
		    <form runat="server" class="form-signin">
			    <h2 class="form-signin-heading">Ingrese sus credenciales</h2>
                <asp:TextBox ID="Email" runat="server" placeHolder="Correo electrónico" CssClass="form-control"></asp:TextBox>
                <asp:TextBox ID="Password" runat="server" TextMode="Password" placeholder="Contraseña" CssClass="form-control"></asp:TextBox>
			    <%--<input type="password" class="form-control" name="password" placeholder="Contraseña" required=""/>--%>
			    <label class="checkbox">
                    <asp:CheckBox ID="RememberMe" runat="server" Text="Recordar mis credenciales." />
                    <%--<input type="checkbox" value="remember-me" id="rememberMe" name="rememberMe" />Recordar mis credenciales.--%>
			    </label>
			    <%--<button class="btn btn-lg btn-primary btn-block" type="submit">Entrar</button>--%>
                <asp:Button ID="btnEntrar" runat="server" Text="Entrar" OnClick="LogIn" CssClass="btn btn-lg btn-primary btn-block" />
		    </form>
        </div>    
    </body>
</html>
