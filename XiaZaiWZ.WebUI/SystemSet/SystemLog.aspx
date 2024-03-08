<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SystemLog.aspx.cs" Inherits="XiaZaiWZ.WebUI.SystemLog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div style="border:5px solid lightblue;width:1000px;margin:0 auto">
        <p style="width:100%;height:40px;background-color:deepskyblue;text-align:center;font-size:30px;color:white">
                      日志管理
          </p>
                    <br />
               <table style="width: 100%;">
                       <tr > 
                                <td style="padding-left:2%">事件</td> 
                                <td >时间</th> 
                                 <td >删除</th> 
                            </tr> 
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate> 
                        
                            <tr>
                                <td ><%# Eval("LogName") %></td>
                                <td><%# Eval("Time") %></td>
                                <td> 
                                    <%--value='<%# Eval("Time") %>'--%>  
                                     <input type="checkbox" name="chk" class="chk" value='<%# Eval("ID") %>' />  删除   
                                </td>
                            </tr>
                       
                    </ItemTemplate>
                </asp:Repeater> 
                 </table>  
                <br />
                <div style="width:24%;margin:0 auto">
                    
                <%--<input type="button" name="Submit" value="统计" onclick="getCheck()"/>--%>
                <asp:Button ID="Button1" runat="server" Text="删除" OnClick="Button1_Click"   />
                <asp:Button ID="Button2" runat="server" Text="取消"  />
                <asp:Button ID="Button3" runat="server" Text="删除所有日志（慎用）" OnClick="Button3_Click"  />
                </div>
                    
        <script language="javascript">
            function getCheck() {
                debugger;
                var chkcount = 0;
                var sss = "";
                var alllength = document.getElementsByClassName("chk").length;//所有Checkbox1的数量 把Checkbox name属性都写成一样 （id也设置成value值一样）
                for (var i = 0; i < alllength; i++) {
                    if (document.getElementsByName("chkname").item(i).checked == true) {
                        /* sss = sss + "," + document.getElementsByName("chkname").item(i).value;*/
                        alert('请选择一个');
                    }
                }
            }
          
        </script>
            </div>  
</asp:Content>
