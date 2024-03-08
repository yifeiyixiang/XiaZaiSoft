<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditFile.aspx.cs" Inherits="XiaZaiWZ.WebUI.Category.EditFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="border:5px solid lightblue;width:1000px;margin:0 auto">
        <p style="width:100%;height:40px;background-color:deepskyblue;text-align:center;font-size:30px;color:white">
                      添加文件
          </p> 
        <div>
            文件名称：<asp:TextBox ID="txtFile" runat="server" Width="400px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtFile" runat="server" ErrorMessage="请输入文件名"></asp:RequiredFieldValidator>
        </div>
        <div>
            一级分类：
            <asp:DropDownList ID="DropDownList1" runat="server" Width="150px"> 
            </asp:DropDownList>
             二级分类：<asp:DropDownList ID="DropDownList2" runat="server" Width="150px">
             <%--   <asp:ListItem>NET</asp:ListItem>
                <asp:ListItem>C#</asp:ListItem>--%>
            </asp:DropDownList>
        </div>
        <div>
            文章语言：<asp:DropDownList ID="DropDownList3" runat="server"> 
            </asp:DropDownList>
            文件大小：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><asp:DropDownList ID="DropDownList4" runat="server">
           <%--     <asp:ListItem>KB</asp:ListItem>
                <asp:ListItem>MB</asp:ListItem>--%>
            </asp:DropDownList>
        </div>
        <div>
            文件格式：<asp:DropDownList ID="DropDownList5" runat="server">
          <%--      <asp:ListItem>PDF</asp:ListItem>
                <asp:ListItem>JPG</asp:ListItem>--%>
            </asp:DropDownList>
        </div>
        <div>
            相关下载：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox> 
        </div>
        <div>
             上传文件：<asp:TextBox ID="TextBox5" runat="server" ReadOnly="true"></asp:TextBox>
            <asp:Button ID="Browse" runat="server" Text="浏览" />
            <asp:Button ID="FileUp" runat="server" Text="上传文件" />
        </div>
        <div>
            下载地址：<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </div>
                  详细介绍：
        <div>
            
           <asp:TextBox id="TextBox6" runat="server"  cols="20" rows="2" style="width:400px;height:100px"></asp:TextBox>
        </div>
        <div> 
            <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="取消" OnClick="Button2_Click" />
        </div>

                  </div>
</asp:Content>
