<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="statichtml.aspx.cs" Inherits="XiaZaiWZ.WebUI.WebForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
       <%-- <asp:DataList ID="DataList1" runat="server"><ItemTemplate><%# Eval("LinkName") %></ItemTemplate></asp:DataList>--%>
                    <div style="border:5px solid lightblue;width:1000px;margin:0 auto">
        <p style="width:100%;height:40px;background-color:deepskyblue;text-align:center;font-size:30px;color:white">
                      生成静态SHTML
          </p>
                    <br />
                        <div style="width:33%;margin:0 auto">
                            <asp:Button ID="Button1" runat="server" Text="生成首页" OnClick="Button1_Click" />  
                             <a>生成一级分类 </a>
                             <a>生成二级分类</a>
                             <a>生成文章内容 </a>
                        </div>
    </table>
</asp:Content>
