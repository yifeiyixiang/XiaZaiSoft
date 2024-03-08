<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="editfriend.aspx.cs" Inherits="XiaZaiWZ.WebUI.Friendship.editfriend" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div style="border:5px solid lightblue;width:1000px;margin:0 auto">
        <p style="width:100%;height:40px;background-color:deepskyblue;text-align:center;font-size:30px;color:white">
                      编辑友情链接
          </p> 
                  <div style="width:26%;margin:0 auto"> 
                        <div>
                            站点名称：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            站点类型：<asp:RadioButton ID="RadioButton1" runat="server" GroupName="A" /> 图片链接<asp:RadioButton ID="RadioButton2" runat="server" GroupName="A" />文字链接
                        </div>
                        <div>
                            站点图标：<asp:TextBox ID="txtlogo" runat="server"></asp:TextBox>
                        </div>
                        <div>
                             站点地址：<asp:TextBox ID="txturl" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Button ID="Button2" runat="server" Text="提交"  OnClick="Button2_Click" />
                            <asp:Button ID="Button3" runat="server" Text="取消"  OnClick="Button3_Click"  />
                        </div>
                      </div>
        </div>
</asp:Content>
