<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SiteEdit.aspx.cs" Inherits="XiaZaiWZ.WebUI.SiteEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div style="border:5px solid lightblue;width:1000px;margin:0 auto">
        <p style="width:100%;height:40px;background-color:deepskyblue;text-align:center;font-size:30px;color:white">
                      站点设置
          </p>
                    <br />
            <div style="width:28%;margin:0 auto;">
                <span>站点名称：</span>
            <asp:TextBox ID="TextBox1" runat="server" Text="电子书下载系统"></asp:TextBox>
            <br />
            <span>站点地址：</span>
            <asp:TextBox ID="TextBox2" runat="server" Text="http://localhost" ReadOnly="True"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="修改" OnClick="Button1_Click1" />
                <asp:Button ID="Button2" runat="server" Text="取消" OnClick="Button2_Click" />
            </div> 
            </div>

</asp:Content>
