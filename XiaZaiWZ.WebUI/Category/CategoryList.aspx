<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="XiaZaiWZ.WebUI.CategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <style>
   a{
    color:black;
   }

 </style>

    <table class="table table-hover" >
        <tr>
            <th style="text-align:center">排列顺序</th>
            <th style="text-align:center">分类名称</th>
            <th>添加二级分类</th>
            <th>生成</th>
            <th>编辑</th>
            <th>删除</th>
        </tr>

        <asp:Repeater ID="rpCategory" runat="server">
            <ItemTemplate>
                <tr style="background-color:lavender;font-weight:bolder;font-size:16px">
                    <td style="text-align:center"><%# Eval("Sort") %></td>
                    <td style="text-align:center" ><%# Eval("ClassName") %></td>
                    <td><a href='AddSecondaryCategory.aspx?ID=<%# Eval("ID") %>'>[添加二级分类]</a></td>
                    <td>[生成]</td>
                    <td><a href='EditFirstCategory.aspx?ID=<%# Eval("ID") %>'>[编辑]</a></td>
                    <td>
                        <asp:LinkButton ID="btnDeleteFirstCategory" runat="server"
                            CommandName="删除一级分类"
                            CommandArgument='<%# Eval("ID") %>'
                            OnClientClick="return confirm('确定删除吗？')"
                            OnCommand="btnDelete_Command">[删除]</asp:LinkButton>
                    </td>
                </tr>

                <asp:Repeater ID="rpSecondaryCategory" runat="server" DataSource='<%# Eval("SecondaryCategory") %>'>
                    <ItemTemplate>
                        <tr>
                            <td style="text-align:center;padding-left:28px;"><%# Eval("Sort") %></td>
                            <td></td>
                            <td><a href='WebID.aspx?ID=<%# Eval("ID") %>'>二级分类：<%# Eval("ClassName") %> </a> </td>
                            <td>[生成]</td>
                            <td><a href='EditSecondaryCategory.aspx?ID=<%# Eval("ID") %>'>[编辑]</a></td>
                            <td>
                                <asp:LinkButton ID="btnDeleteSecondaryCategory" runat="server"
                                    CommandName="删除二级分类"
                                    CommandArgument='<%# Eval("ID") %>'
                                    OnClientClick="return confirm('确定删除吗？')"
                                    OnCommand="btnDelete_Command">[删除]</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </ItemTemplate>
        </asp:Repeater>


    </table>
</asp:Content>
