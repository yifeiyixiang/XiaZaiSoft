<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mnager.aspx.cs" Inherits="XiaZaiWZ.WebUI.Mnager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <script src="Scripts/jquery-3.4.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/sweetalert2/sweetalert2.js"></script>
    <script src="Scripts/common.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Scripts/sweetalert2/sweetalert2.css" rel="stylesheet" />
    <link href="Content/login.css" rel="stylesheet" />
</head>
<body class="container">
    <div class="box">

        <form id="form1" runat="server" class="form-horizontal">
            <div class="form-group">
                <label for="txtUserName" class="col-sm-2 control-label">用户名:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtUserName" Font-Names="UserName" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtPassword" class="col-sm-2 control-label">密码:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ToolTip="请输入密码" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtPassword" class="col-sm-2 control-label">确认密码:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtPasswordOK" runat="server" TextMode="Password" ToolTip="请再次输入相同的密码" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    <asp:Button ID="btnLogin" runat="server" class="btn btn-primary" Text="登录"  />
                    <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="取消" />
                </div>
            </div>
        </form>
    </div>
</body>
</html>
