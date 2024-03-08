<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManagerFile.aspx.cs" Inherits="XiaZaiWZ.WebUI.Category.ManagerFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                  <div style="border:5px solid lightblue;width:1000px;margin:0 auto">
        <p style="width:100%;height:40px;background-color:deepskyblue;text-align:center;font-size:30px;color:white">
                      文章管理
          </p> 

                         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="950px" CellPadding="0" GridLines ="None" BorderWidth="0px" OnRowCommand="GridView1_RowCommand">
                       <Columns >
                           <asp:BoundField DataField="id" HeaderText="ID" />
                           <asp:BoundField DataField="Name" HeaderText="文章名称" />
                           <asp:BoundField DataField="Uptime" HeaderText="添加时间" />
                                <asp:TemplateField HeaderText="[生成]">
                               <ItemTemplate> 
                                   <asp:LinkButton ID="LinkButton3"  runat="server" ><a >[生成]</a></asp:LinkButton>
                               </ItemTemplate>
                           </asp:TemplateField>
                            <asp:TemplateField HeaderText="[编辑]">
                               <ItemTemplate> 
                                   <asp:LinkButton ID="LinkButton1"  runat="server" CommandArgument='<%# Eval("id") %>'><a href='EditFile.aspx?ID=<%# Eval("ID") %>'>[编辑]</a></asp:LinkButton>
                               </ItemTemplate>
                           </asp:TemplateField>
                            
                           <asp:TemplateField HeaderText="删除">
                               <ItemTemplate>
                                   <asp:LinkButton ID="LinkButton2"  runat="server" CommandArgument='<%# Eval("id") %>'>删除</asp:LinkButton>
                               </ItemTemplate>
                           </asp:TemplateField>
                       </Columns>

                   </asp:GridView>
 
                   
                <br />
        </div>
</asp:Content>
