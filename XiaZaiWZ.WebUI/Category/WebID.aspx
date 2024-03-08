<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebID.aspx.cs" Inherits="XiaZaiWZ.WebUI.WebID" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/> 
    <asp:DataList ID="DataList1" runat="server"><ItemTemplate> <title><%# Eval("LinkName") %></title></ItemTemplate></asp:DataList>
     <link href="../Content/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <div class="header" >
                <video class="fullscreenvideo" playsinline="" autoplay="" muted="" loop="" >
                <source src="../images/swim.mp4" type="video/mp4">
            </div>
             <div class="nga">
                 <table class="table table-hover" style="width:80%;margin:0 auto" >
                     <td style="flex:1;text-align:center" ><a href="../WebUI.aspx">站点首页</a></td> 
                <asp:Repeater ID="rpCategory" runat="server"> 
                    <ItemTemplate> 
                         <td style="flex:1;text-align:center" ><a href=WebID.aspx?ID=<%# Eval("ID") %>><%# Eval("ClassName") %></a></td> 
                    </ItemTemplate>
                </asp:Repeater>
                     </table>
            </div>
           
            <div class="main" >
                <div class="warp" style="width:20%;float:left">
                        <table style="border:1px solid gray">
                          <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate> 
                        <tr style="background-color:ghostwhite;font-weight:bolder;font-size:16px; "> 
                            <td style="text-align:left;border:2px solid gray" ><%# Eval("ClassName") %></td> 
                        </tr> 
                        
                        <tr style="background-color:aliceblue;">
                            <asp:Repeater ID="rpSecondaryCategory" runat="server" DataSource='<%# Eval("SecondaryCategory") %>'>
                                <ItemTemplate>  
                                        <td style="float:left;width:43%;margin:5px;margin-left:8px" >➣<a href='WebID.aspx?ID=<%# Eval("ID") %>'><%# Eval("ClassName") %> </a> </td>  
                                </ItemTemplate>
                            </asp:Repeater>
                         </tr>
                    </ItemTemplate>
                </asp:Repeater>
                        </table>
                    </div>
                <div class="warpright" style="width:80%;float:right">
                         <asp:Repeater ID="Repeater2" runat="server"> 
                            <ItemTemplate>  
                                <div style="width:49%;float:left;border:1px solid gray;margin:2px;">
                                <div style="background-color:ghostwhite;font-weight:bolder;font-size:16px;"> 
                                    <p style="text-align:left;border:2px solid gray" ><%# Eval("ClassName") %>
                                           <span style="float:right;color:lightgray;font-size:10px" > ▹MORE  </span>
                                    </p>  
                                </div>  
                                <asp:Repeater ID="Repeater3" runat="server" DataSource='<%# Eval("SecondaryCategoryac") %>'>
                                        <ItemTemplate>  
                                                <div style="background-color:azure;display:flex">
                                                    <p style="width:45%;margin:10px;flex:1" ><a href='../WebIDAC.aspx?ID=<%# Eval("id") %>'>·<%# Eval("Name") %> </a> </p> 
                                                    <p style="margin:5px;color:gray;flex:1" ><%# Eval("Uptime") %> </p>
                                                 </div>
                                        </ItemTemplate>
                                         </asp:Repeater> 
                                       </div>
                            </ItemTemplate> 
                        </asp:Repeater>
<%--                             <table>
                                  <asp:Repeater ID="Repeater2" runat="server">
                            <ItemTemplate>  
                                <tr style="background-color:ghostwhite;font-weight:bolder;font-size:16px;"> 
                                    <td style="text-align:left;border:2px solid gray" ><%# Eval("ClassName") %>
                                           <span style="float:right;color:lightgray;font-size:10px" > ▹MORE  </span>
                                    </td>  
                                </tr>  
                                <asp:Repeater ID="Repeater3" runat="server" DataSource='<%# Eval("SecondaryCategoryac") %>'>
                                        <ItemTemplate>  
                                                <tr style="background-color:azure;">
                                                    <td style="float:left;width:45%;margin:10px" ><a href='WebUI.aspx?ID=<%# Eval("id") %>'>·<%# Eval("Name") %> </a> </td> 
                                                    <td style="float:right;margin:5px;color:gray" ><%# Eval("Uptime") %> </td>
                                                 </tr>
                                        </ItemTemplate>
                                         </asp:Repeater> 
                            </ItemTemplate>
                        </asp:Repeater>
                                </table>--%>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
