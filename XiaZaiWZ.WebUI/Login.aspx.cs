using XiaZaiWZ.BLL;
using XiaZaiWZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XiaZaiWZ.WebUI
{
    public partial class Login : System.Web.UI.Page
    {
        public static string editname;
        private UserInfoService bll = new UserInfoService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 通过编程的方式将控件注册为异步回发的触发器
                //AjaxScriptManager.RegisterAsyncPostBackControl(btnRefreshValidateCode);

                // 验证码初设置
                this.cclValidateCode.LetterSpacing = 20; // 字符间距
                this.cclValidateCode.MaxLength = 4; // 验证码最大字符数量
                this.cclValidateCode.MinLength = 4; // 验证码最小字符数量
                this.cclValidateCode.Width = new Unit("100px");
                this.cclValidateCode.Height = new Unit("40px");
                this.cclValidateCode.CreateYzm();

                // 首次加载页面的时候，从Cookie中取出用户名
                var userName = this.Request.Cookies["UserName"]?.Value;
                if (!string.IsNullOrWhiteSpace(userName))
                {
                    this.txtUserName.Text = userName;
                }
            }
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        { 
            var msg = "";

            // 验证码
            if (!this.cclValidateCode.CheckYzm(this.txtValidateCode.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "showWarningMsg('验证码无效，请重新输入!', null);", true);
                return;
            }

            // 验证用户
            var user = bll.CheckUser(new UserInfo
            {
                UserName = txtUserName.Text,
                Password = txtPassword.Text
            }, out msg);
            if (user == null)
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "alert", $"showErrorMsg('{msg}', null);", true);
                this.ClientScript.RegisterStartupScript(GetType(), "alert", $"showErrorMsg('{msg}', null);", true);
                //return;
            }

            // 勾选了记住我，将用户名缓存到Cookie中
            if (chkRememberMe.Checked)
            {
                var cookie = new HttpCookie("UserName", Server.UrlEncode(user.UserName));
                cookie.Expires = DateTime.Now.AddDays(3);// 3天后过期
                Response.Cookies.Add(cookie); // 写回浏览器
            }
            else
            {
                Response.Cookies.Remove("UserName"); // 清除
            }

            // 将登录信息放入缓存
            Session["user"] = user;
            Session["UserName"] = user.UserName;
            // 将登录信息放入日志
            var aname = txtUserName.Text;
            editname = aname;
            var localserver = Request.ServerVariables["LOCAL_ADDR"];
            var logname = aname + localserver;
            LogService log = new LogService();
            log.AddLog(logname);
            // 跳转到首页
            //Response.Write("<srcipt>showSuccessMsg('登录成功!', function () { window.location.url = 'Default.aspx'; });</script>");
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", "showSuccessMsg('登录成功!', function () { window.location.href = 'SystemSet/SystemProbe.aspx'; });", true);
            //Response.Redirect("Default.aspx");
            Session["editname"] = user.UserName;
        }

        /// <summary>
        /// 刷新验证码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefreshValidateCode_Click(object sender, EventArgs e)
        {
            this.cclValidateCode.CreateYzm();
        }
    }
}