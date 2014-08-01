<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <script>
        function abrir() {
            window.open("index.html", "mywindow", "width=1000,height=600");
        }
    </script>
    <form id="form1" runat="server">
    <div>asdasdas
        <a href="#" onclick="javascript:abrir();" >Carga de Archivos</a>
        <%--<object type="text/html" data="index.html" width="100%" height="1000px"> </object>--%>
        
    </div>
    </form>
</body>
</html>
