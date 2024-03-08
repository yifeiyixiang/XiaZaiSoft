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
    public partial class AddFile1 : System.Web.UI.Page
    {
        private CategoryService bll = new CategoryService();
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                this.DropDownList1.DataSource = bll.GetAllCategory();
                DropDownList1.DataTextField = "ClassName";
                DropDownList1.DataValueField = "ID"; 
                this.DropDownList1.DataBind();    
            }
            var parentid = int.Parse(DropDownList1.SelectedValue);
            this.DropDownList2.DataSource = bll.GetSecondaryCategory(parentid);
            DropDownList2.DataTextField = "ClassName";
            DropDownList2.DataValueField = "ID";
        }

        protected void Browse_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                //获取上传文件名
                string fileName = FileUpload1.FileName;
                FileUpload1.SaveAs(Server.MapPath("~/Upload/") + fileName);
                this.TextBox5.Text = "~/Upload/" + fileName;

            }
            else
            {
                Response.Write("<script>alert('请选择')</script>");
            }
        }
         
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        { 
           var parentid = int.Parse(DropDownList1.SelectedValue);
            this.DropDownList2.DataSource = bll.GetSecondaryCategory(parentid);
            DropDownList2.DataTextField = "ClassName";
            DropDownList2.DataValueField = "ID";
            this.DropDownList2.DataBind(); 
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if(TextBox5.Text.Length<1)
            {
                Response.Write("<script>alert('请上传文件')</script>");
            }
            else
            { var uptime = DateTime.Now;
                var firstid=DropDownList1.SelectedValue;
                var second = DropDownList2.SelectedValue;
                if (second != null)
                {
                    var sql = $"INSERT INTO [dbo].[View]([Name],[Language],[Size],[SizeNum],[Uptime],[Format],[Content],[DownUrl],[Tong],[Cls1_id],[Cls2_id]) VALUES('{txtFile.Text}','{DropDownList3.SelectedValue}','{TextBox1.Text}','{DropDownList4.SelectedValue}','{uptime}','{DropDownList5.SelectedValue}','{TextBox6.Text}','{TextBox3.Text}','{TextBox2.Text}',{firstid},{second})";
                    if (DBHelper2.ExecuteNonQuery(sql))
                    {
                        Response.Write("<script>alert('添加成功')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('添加失败')</script>");
                    }

                }
                else
                {
                    Response.Write("<script>alert('请选择二级分类')</script>");
                }
              
            }
        }
    }
}