<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManageWeb.aspx.cs" Inherits="XiaZaiWZ.WebUI.UserManage.AleterWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
              <div style="border:5px solid lightblue;width:1000px;margin:0 auto">
        <p style="width:100%;height:40px;background-color:deepskyblue;text-align:center;font-size:30px;color:white">
                      用户管理
          </p> 
               
<%--                       <tr > 
                                <td style="padding-left:2%">用户名称</td> 
                                <td >上次登陆时间</th> 
                                 <td >上次登录ip</th> 
                                     <td >创建者</th> 
                                         <td >删除</th> 
                            </tr> --%>
                   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="950px" CellPadding="0" GridLines ="None" BorderWidth="0px" OnRowCommand="GridView1_RowCommand">
                       <Columns >
                           <asp:BoundField DataField="AdminName" HeaderText="用户名称" />
                           <asp:BoundField DataField="LoginTime" HeaderText="上次登陆时间" />
                           <asp:BoundField DataField="Ip" HeaderText="上次登录ip" />
                           <asp:BoundField DataField="Adder" HeaderText="创建者" />
                           <asp:TemplateField HeaderText="删除">
                               <ItemTemplate>
                                   <asp:LinkButton ID="LinkButton1"  runat="server" CommandArgument='<%# Eval("id") %>'>删除</asp:LinkButton>
                               </ItemTemplate>
                           </asp:TemplateField>
                       </Columns>

                   </asp:GridView>
 
                   
                <br />

                  <%--用户--%>
                                     <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="950px" CellPadding="0" GridLines ="None" BorderWidth="0px" OnRowCommand="GridView1_RowCommand">
                       <Columns >
                           <asp:BoundField DataField="UserName" HeaderText="用户名称" />
                           <asp:BoundField DataField="Password" HeaderText="用户密码" />
                           <asp:BoundField DataField="UserCode" HeaderText="用户确认" /> 
                           <asp:TemplateField HeaderText="删除">
                               <ItemTemplate>
                                   <asp:LinkButton ID="LinkButton1"  runat="server" CommandArgument='<%# Eval("ID") %>'>删除.</asp:LinkButton>
                               </ItemTemplate>
                           </asp:TemplateField>
                       </Columns>

                   </asp:GridView>
                <div style="width:24%;margin:0 auto">
                    
                <%--<input type="button" name="Submit" value="统计" onclick="getCheck()"/>--%> 
                </div>
                    
         
            </div>  
</asp:Content>
