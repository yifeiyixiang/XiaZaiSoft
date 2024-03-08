<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddSecondaryCategory.aspx.cs" Inherits="XiaZaiWZ.WebUI.AddSecondaryCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="panel panel-info">
            <div class="panel-heading title">添加文章二级分类：<%= this.ClassName %></div>
            <div class="panel-body">
                <div class="form-group">
                    <label for="txtClassName">分类名称</label>
                    <asp:TextBox class="form-control" ID="txtClassName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="分类名称不能为空" ControlToValidate="txtClassName" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="txtSort">排列顺序</label>
                    <asp:TextBox class="form-control" ID="txtSort" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="排列必须是数字" ControlToValidate="txtSort" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:Button ID="btnAdd" runat="server" class="btn btn-primary" Text="添加" OnClick="btnAdd_Click" />
                    <a class="btn btn-danger" href="CategoryList.aspx">取消</a>
                </div>

            </div>
        </div>
    </div>
 
</asp:Content>
