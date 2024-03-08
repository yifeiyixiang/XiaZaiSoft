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
    public partial class AddCategory : System.Web.UI.Page
    {
        private CategoryService bll = new CategoryService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // 创建分类对象
                var category = new Models.Category();
                category.ClassName = this.txtClassName.Text;
                category.Sort = int.Parse(this.txtSort.Text);
                category.ParentID = 0;

                // 添加分类
                var ok = bll.Add(category);
                if (ok)
                {
                    Response.Write("<script>alert('添加一级分类成功！');</script>");
                }
                else
                {
                    Response.Write("<script>alert('添加一级分类失败！');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('添加一级分类失败！原因：{ex.Message}');</script>");
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoryList.aspx");
        }
    }
}