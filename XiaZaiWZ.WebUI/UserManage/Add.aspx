<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="XiaZaiWZ.WebUI.Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
              <div style="border:5px solid lightblue;width:1000px;margin:0 auto">
        <p style="width:100%;height:40px;background-color:deepskyblue;text-align:center;font-size:30px;color:white">
                      添加用户
          </p> 
                  <div style="width:26%;margin:0 auto">
                        <div>
                            用户名称：<asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            用户密码：<asp:TextBox ID="txtPwd" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            用户确认：<asp:TextBox ID="txtUserOK" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" />
                            <asp:Button ID="Button2" runat="server" Text="取消" OnClick="Button2_Click" />
                        </div>
                      </div>
        </div>
        </div>
</asp:Content>
