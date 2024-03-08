using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XiaZaiWZ.BLL;
using XiaZaiWZ.Models;
namespace XiaZaiWZ.WebUI
{
    public partial class SiteEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "电子书下载系统"; 
        }
 

        protected void Button1_Click1(object sender, EventArgs e)
        {

            var lname = TextBox1.Text;
            if (BLL.LinkService.UPGet(lname,14))
            {
                Response.Write("<script>alert('站点名称修改成功!')</script>");

            }
            else
            {
                Response.Write("<script>alert('修改失败!')</script>");
            }
           
        }
    }
}