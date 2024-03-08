using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XiaZaiWZ.BLL;
using XiaZaiWZ.Models;

namespace XiaZaiWZ.WebUI.Friendship
{
    public partial class editfriend : System.Web.UI.Page
    {
        private LinkService links = new LinkService();
        public static int sid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] == null)
                {
                    Response.Write("<script>alert('编辑链接请先选择！');</script>");
                    Response.Redirect("managerfriend.aspx");
                    return;
                }
                var id = int.Parse(Request.QueryString["ID"]);
                sid = id;
                var link = links.idGetLink(id);
                TextBox1.Text = link.LinkName;
               var a= link.LinkType == 1 ? RadioButton1.Checked =true: RadioButton2.Checked=true;
                txtlogo.Text = link.LinkLogo;
                txturl.Text = link.LinkUrl;

          
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Link link = new Link();
            link.LinkName = TextBox1.Text;
            link.LinkType = RadioButton1.Checked ? 1 : 2;
            link.LinkUrl = txturl.Text;
            link.LinkLogo = txtlogo.Text;
            link.id = sid;

            LinkService links = new LinkService();
            if (links.UPdate(link))
            {
                Response.Write("<script> alert('编辑成功')</script>");
            }
            else
            {
                Response.Write("<script> alert('失败')</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("managerfriend.aspx");
        }
    }
}