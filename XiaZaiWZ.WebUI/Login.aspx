<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="XiaZaiWZ.WebUI.Login" %>

<%@ Register Assembly="WebValidates" Namespace="WebValidates" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>用户登录</title>
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
                <label for="txtUserName" class="col-sm-2 control-label">用户名</label> 
                <div class="col-sm-10">
                    <asp:TextBox ID="txtUserName" Font-Names="UserName" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtPassword" class="col-sm-2 control-label">密码</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ToolTip="请输入密码" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtValidateCode" class="col-sm-2 control-label">验证码</label>
                <div class="col-sm-10">
                    <asp:ScriptManager ID="AjaxScriptManager" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdateValidateCode" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtValidateCode" Font-Names="UserName" runat="server" class="form-control"></asp:TextBox>
                            <asp:LinkButton ID="btnRefreshValidateCode" runat="server" ToolTip="刷新验证码" OnClick="btnRefreshValidateCode_Click">
                                <cc1:ValidateCode ID="cclValidateCode" runat="server">
                                </cc1:ValidateCode>
                            </asp:LinkButton>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnRefreshValidateCode" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="chkRememberMe" runat="server" />
                            记住我
                        </label>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    <asp:Button ID="btnLogin" runat="server" class="btn btn-primary" Text="登录" OnClick="btnLogin_Click" />
                </div>
            </div>
        </form>
    </div>
    <script>

        // 用户登录
        $("#login").click(function () {

            var email = $("#inputEmail").val();
            var pwd = $("#inputPassword").val();


            $.ajax({
                async: true,
                type: 'get',
                url: apiUrl + "/Customer/GetAll",
                success: function (result, state) {

                    if (!isEmpty(result)) {

                        showSuccessMsg('登录成功!', function () {
                            //window.location.url = "";//
                        });

                    }
                },

                complete: function () {
                    //
                }
            });

        });

    </script>
</body>
</html>
