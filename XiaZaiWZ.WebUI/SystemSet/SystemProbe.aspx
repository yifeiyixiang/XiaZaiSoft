<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SystemProbe.aspx.cs" Inherits="XiaZaiWZ.WebUI.SystemProbe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="border:5px solid lightblue;width:1000px;margin:0 auto">
        <p style="width:100%;height:40px;background-color:deepskyblue;text-align:center;font-size:30px;color:white">
                       系统探针
                    </p>
                    <br />
                    <p style="width: 571px">
                        <asp:Label ID="Label6" runat="server" Text="管理员名称："></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label22" runat="server" Text='3'><span style="color:red"><%=Session["UserName"].ToString() %></span></asp:Label>
                    </p>
                    <p style="width: 571px">
                        <asp:Label ID="Label7" runat="server" Text="服务器名称："></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label23" runat="server" Text="HUTR"><span style="color:red"><%= Server.MachineName.ToString() %></span></asp:Label>
                    </p>
                    <p style="width: 571px">
                        <asp:Label ID="Label8" runat="server" Text="服务器IP地址"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label24" runat="server" Text="this is::1"><span style="color:red"><%=Request.ServerVariables["LOCAL_ADDR"]  %></span></asp:Label>
                        &nbsp;&nbsp;&nbsp;
                    </p>
                    <p style="width: 571px">
                        <asp:Label ID="Label9" runat="server" Text="服务器域名："></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label25" runat="server" Text="localhost"><span style="color:red"><%=Request.ServerVariables["SERVER_NAME"]  %></span></asp:Label>
                    </p>
                    <p style="width: 571px">
                        <asp:Label ID="Label10" runat="server" Text="服务器端口："></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label28" runat="server" Text="Label"><span style="color:red"><%=Request.ServerVariables["SERVER_PORT"] %></span></asp:Label>
                    </p>
                    <p style="width: 571px">
                        <asp:Label ID="Label11" runat="server" Text="服务器IIS版本："></asp:Label>
                        <asp:Label ID="Label29" runat="server" Text="2566"><span style="color:red"><%=Request.ServerVariables["SERVER_SOFTWARE"] %></span></asp:Label>
                    </p>
                    <p style="width: 571px">
                        <asp:Label ID="Label12" runat="server" Text="程序所在目录："></asp:Label>
                        <asp:Label ID="Label30" runat="server" Text="Microsoft-ISS/8.0">  <span style="color:red">相对路径：<%=Request.ServerVariables["PATH_INFO"] %> <br/>物理路径：<%=Request.ServerVariables["APPL_PHYSICAL_PATH"] %></span></asp:Label>
                    </p>
                    <p style="width: 571px">
                        <asp:Label ID="Label13" runat="server" Text="服务器操作系统："></asp:Label>
                        <asp:Label ID="Label4" runat="server" Text="Mirosoft Windows NT 6.2.9200.0"><span style="color:red"><%=Environment.OSVersion %></span> </asp:Label>
                    </p>
                    <p style="width: 571px">
                          <asp:Label ID="Label1" runat="server" Text="服务器脚本超时："></asp:Label>
                        <asp:Label ID="Label5" runat="server" Text="1秒"><span style="color:red"><%=Server.ScriptTimeout %></span> </asp:Label>
                    </p>
                    <p style="width: 571px">
                        <asp:Label ID="Label16" runat="server" Text=".NET Framework 版本："></asp:Label>
                        <asp:Label ID="Label15" runat="server" Text="4.0.30319.0"><span style="color:red" ><%=System.Environment.Version %></span></asp:Label>
                    </p>
                    <p style="width: 571px;">
                        <asp:Label ID="Label26" runat="server" Text="服务器当前时间："></asp:Label>
                        <asp:Label ID="Label31" runat="server" Text="" ><span style="color:red"><%=DateTime.Now %></span></asp:Label>
                    </p>
                    <p style="width: 571px">
                        
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server"> 
                            <ContentTemplate>
                                <asp:Label ID="Label17" runat="server" Text="服务器已运行时间："></asp:Label>
                            <span style="color:red"> <asp:Label ID="Label32" runat="server" ></asp:Label></span>
                        <asp:Timer ID="Timer1" runat="server" Interval="1000"  OnTick="Timer1_Tick">
                        </asp:Timer>
                                  </ContentTemplate>
                            </asp:UpdatePanel>
                        
                    </p>
                    <p style="width: 571px">
                        <asp:Label ID="Label18" runat="server" Text="Asp.net所占内存："></asp:Label>
                        <asp:Label ID="Label33" runat="server" Text="65.92M"><span style="color:red"><%= System.Diagnostics.Process.GetCurrentProcess().WorkingSet64/1048576+"MB" %></span> </asp:Label>
                    </p>
                    <p style="width: 571px">
                        <asp:Label ID="Label19" runat="server" Text="逻辑驱动器数："></asp:Label>
                     <span style="color:red">   <asp:Label ID="Label34" runat="server" Text="C:\D:\E"></asp:Label></span>
                    </p>
                    <p style="width: 571px">
                        <asp:Label ID="Label20" runat="server" Text="当前Session数量："></asp:Label>
                        <asp:Label ID="Label35" runat="server" Text="9"><span style="color:red"><%=Session.Contents.Count.ToString()%></span></asp:Label>
                    </p>
                    <p style="width: 571px">
                        <asp:Label ID="Label21" runat="server" Text="CPU总数："></asp:Label>
                        <asp:Label ID="Label36" runat="server" Text="8"><span style="color:red"><%=Environment.ProcessorCount %></span></asp:Label>
                    </p>
                    <p style="width: 571px">
                        <asp:Label ID="Label27" runat="server" Text="CPU类型："></asp:Label>
                      <span style="color:red">  <asp:Label ID="Label37" runat="server" Text="Intel64 Family 6 Modles Stepping 3,GenuineIntel"></asp:Label></span>
                    </p>
        </div>
</asp:Content>
