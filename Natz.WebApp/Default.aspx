<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Natz.WebApp.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="scripts/plugin/jquery/jquery-1.11.2.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <script type="text/javascript">
            $.ajax({
                type: "POST",
                url: "Default.aspx/GetData",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    //alert();
                }
            });
        </script>
    </form>
</body>
</html>