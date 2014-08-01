<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="wfSircc.login" %>

<!DOCTYPE html>

<html lang="es">
<head runat="server">

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>SIRCC &reg</title>

    <script type="text/javascript" src="jqscripts/jquery-1.10.1.min.js"></script>
    <link href="Content/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="Content/login/login.css" rel="stylesheet" />

    <!-- Just for debugging purposes. Don't actually copy this line! -->
    <!--[if lt IE 9]><script src="/jqscripts///ie8-responsive-file-warning.js"></script><![endif]-->

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="/jqscripts//html5shiv.js"></script>
      <script src="/jqscripts//respond.min.js"></script>
    <![endif]-->


</head>
<body>
    <div class="form-signin-img">
        <h3> SIRCC &reg</h3>
        <%--<img src="Images/imagesLogin/sircc.png" alt="Usuario"
            style="margin: 0px;" />--%>
    </div>
    <form id="form1" runat="server" class="form-signin">
        <div class="container">
            <h2>Inicie sesión</h2>
            <input type="text" runat="server" class="form-control" id="txtUserName" placeholder="Identificación" required autofocus>
            <br />
            <input type="password" runat="server" class="form-control" id="txtPassword" placeholder="Contraseña" required>
            <asp:Label ID="lbMsg" runat="server" Text=""></asp:Label>
            <label class="checkbox">
                <input type="checkbox" value="remember-me">
                Mantener la sesión iniciada
            </label>
            <asp:Button ID="BtnIniciar" runat="server" Text="Iniciar Sesión" CssClass="btn btn-lg btn-primary btn-block"
                 OnClick="BtnIniciar_Click1" />
        </div>


    </form>

    <div class="container">
        admin-fc2014.
    </div>
    <!-- /container -->


    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    
</body>
</html>
