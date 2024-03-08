<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="WebIDAC.aspx.cs" Inherits="XiaZaiWZ.WebUI.WebIDAC" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/> 
    <asp:DataList ID="DataList1" runat="server"><ItemTemplate> <title><%# Eval("LinkName") %></title></ItemTemplate></asp:DataList>
     <link href="Content/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <div class="header" >
                <video class="fullscreenvideo" playsinline="" autoplay="" muted="" loop="" >
                <source src="images/swim.mp4" type="video/mp4">
            </div>
             <div class="nga">
                 <table class="table table-hover" style="width:80%;margin:0 auto" >
                     <td style="flex:1;text-align:center" ><a href="WebUI.aspx">站点首页</a></td> 
                <asp:Repeater ID="rpCategory" runat="server"> 
                    <ItemTemplate> 
                         <td style="flex:1;text-align:center" ><a href="Category/WebID.aspx?ID=<%# Eval("ID") %>"><%# Eval("ClassName") %></a></td> 
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
                                        <td style="float:left;width:43%;margin:5px;margin-left:8px" >➣<a href='Category/WebID.aspx?ID=<%# Eval("ID") %>'><%# Eval("ClassName") %> </a> </td>  
                                </ItemTemplate>
                            </asp:Repeater>
                         </tr>
                    </ItemTemplate>
                </asp:Repeater>
                        </table>
                    </div>
                <div class="warpright" style="width:80%;float:right">
                        <%--右边变换书籍详细--%>
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
                                                    <p style="width:45%;margin:10px;flex:1" ><a href='WebIDAC.aspx?ID=<%# Eval("id") %>'>·<%# Eval("Name") %> </a> </p> 
                                                    <p style="margin:5px;color:gray;flex:1" ><%# Eval("Uptime") %> </p>
                                                 </div>
                                        </ItemTemplate>
                                         </asp:Repeater> 
                                       </div>
                            </ItemTemplate> 
                        </asp:Repeater>
                    <%--右边变换书籍详细--%>
                     <div style="border:5px solid lightblue;width:60%;">
        <p style="width:100%;height:40px;background-color:deepskyblue;text-align:left;font-size:30px;color:white">
                    正文详细
          </p> 
        <div>
            电子书名称：<asp:TextBox ID="txtFile" runat="server" Width="400px"></asp:TextBox>
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
            下载地址：<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </div>
         <div style="">
             <asp:Button ID="Button1" runat="server" Text=""  style="background:url(images/down.png) 100% 100%;height:89px;width:274px" OnClick="Button1_Click"/>
            </div>

                  详细介绍：
        <div>
            
           <asp:TextBox id="TextBox6" runat="server"  cols="20" rows="2" style="width:400px;height:100px"></asp:TextBox>
        </div>
        <div> 
            <%--as--%>
        </div>

                  </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
