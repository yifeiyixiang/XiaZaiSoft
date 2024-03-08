using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XiaZaiWZ.BLL;
using XiaZaiWZ.Models;
namespace XiaZaiWZ.WebUI.Category
{
    public partial class EditFile : System.Web.UI.Page
    {
        private viewService view = new viewService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] == null)
                {
                    Response.Write("<script>alert('编辑文章请先选择！');</script>");
                    Response.Redirect("ManagerFile.aspx");
                    return;
                }
                //var sql = $"select * FROM [View] WHERE id={Request.QueryString["ID"]} ";
                //var view = DBHelper2.GetDataTable(sql);
                
                var id = int.Parse(Request.QueryString["ID"]); 
                var views= view.Get(id);
                var sqll = $"select ClassName from Category where ID in(select ParentID from Category where ID={views.Cls2_id})";
                var a = DBHelper2.GetDataTable(sqll);
                //var b= DBHelper2.GetDataReader(sqll);
                var sqll2 = $"select ClassName from Category where  ID={views.Cls2_id}";
                var a2 = DBHelper2.GetDataTable(sqll2);
                if ( DBHelper2.GetDataTable(sqll) != null)
                {
                    this.txtFile.Text = views.Name;
                    if ( a.Rows.Count<1)
                    {
                        Response.Write("<script>alert('还没有一级分类！');</script>"); 
                    }
                    else
                    {
                        DropDownList1.Items.Add(a.Rows[0][0].ToString());//datatable取值
                        DropDownList2.Items.Add(a2.Rows[0][0].ToString());                                           //b[0].ToString();//datareader取值
                        DropDownList3.Items.Add(views.Language);
                        TextBox1.Text = views.Size.ToString();
                        DropDownList4.Items.Add(views.SizeNum);
                        DropDownList5.Items.Add(views.Format);
                        TextBox2.Text = views.Tong;
                        TextBox3.Text = views.DownUrl;
                        TextBox6.Text = views.Content;
                    }

                }
               
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           var views = new Models.View();
            views.id = int.Parse(Request.QueryString["ID"]);
            views.Name = this.txtFile.Text;
            views.Size = Convert.ToInt32(TextBox1.Text);
            views.Tong = TextBox2.Text;
             views.DownUrl=TextBox3.Text;
             views.Content = TextBox6.Text; 
            if (view.Update(views))
            {
                Response.Write("<script>alert('修改成功！');</script>");
            }
            else{
                Response.Write("<script>alert('修改失败！');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Category/ManagerFile");
        }
    }
}