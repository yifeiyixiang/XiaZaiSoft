using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XiaZaiWZ.WebUI
{
    public partial class SystemProbe : System.Web.UI.Page
    { 
      
        protected void Page_Load(object sender, EventArgs e)
        {
            //begin = DateTime.Now;    
            Session["UserName"] = "admin";
            //     <%= Environment.GetLogicalDrives().ToString().Length %>
            //当前电脑有{0}个逻辑驱动器
            var numlog = Environment.GetLogicalDrives().Length;
            //Label34.Text = numlog.ToString();
            //foreach (string drive in Environment.GetLogicalDrives())
            //{
            //    //Label34.Text = drive;只能显示一个？？？
            //}
            String[] drives = Environment.GetLogicalDrives();
            Label34.Text = String.Join(", ", drives);
            //获取Cpu名字、类型
            string CPUName = "";
            ManagementObjectSearcher mos = new ManagementObjectSearcher("Select * from Win32_Processor");//Win32_Processor  CPU处理器
           
            foreach (ManagementObject mo in mos.Get())
            {
                CPUName = mo["Name"].ToString();
            }
            mos.Dispose();
            Label37.Text = CPUName;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Label32.Text = DateTime.Now.Second.ToString()+"秒";
        }
    }
}