using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XiaZaiWZ.Models;
using XiaZaiWZ.BLL;
namespace XiaZaiWZ.WebUI
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UserInfo user = new UserInfo();
            user.UserName = txtUser.Text;
            user.Password = txtPwd.Text;
            user.UserCode = txtUserOK.Text;
            UserInfoService uss = new UserInfoService();
            var ok = uss.AddUser(user);
           if (ok)
            {
                Response.Write("<script>alert('添加用户成功!')</script>");
            }
            else
            {
                Response.Write("<script>alert('添加用户失败!')</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //取消

        }
    }
}