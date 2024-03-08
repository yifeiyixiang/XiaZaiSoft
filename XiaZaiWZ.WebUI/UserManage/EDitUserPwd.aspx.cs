using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XiaZaiWZ.Models;
using XiaZaiWZ.BLL;

namespace XiaZaiWZ.WebUI.UserManage
{
    public partial class AddUserWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //var needname = Session["editname"].ToString();正式运行就解开
            UserInfo us = new UserInfo();
            us.UserName = "Admin";//needname
            us.Password = txtold.Text;
            us.UserCode = txtUserOK.Text;
            var sql = $"select UserName,Password from UserInfo where UserName='{us.UserName}' and Password={us.Password}";
            var ok = BLL.DBHelper2.GetDataTable(sql).Rows;
            if ( ok.Count<1)
            {
                Response.Write("<script>alert('密码输入错误!')</script>");
            }
            else
            {
                var sqll = $"UPDATE UserInfo SET UserCode ={us.UserCode},Password={txtnew.Text} WHERE UserName='{us.UserName}'";
                if (BLL.DBHelper2.ExecuteNonQuery(sqll))
                    {
                    Response.Write("<script>alert('密码修改成功!')</script>");
                }
                else
                {
                    Response.Write("<script>alert('密码修改失败!')</script>");
                }
                
            } 
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}