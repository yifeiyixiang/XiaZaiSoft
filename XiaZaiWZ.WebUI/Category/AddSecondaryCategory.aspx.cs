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
    public partial class AddSecondaryCategory : System.Web.UI.Page
    {

        private CategoryService bll = new CategoryService();

        /// <summary>
        /// 分类ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string ClassName { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Request.QueryString["ID"] == null)
                {
                    Response.Write("<script>alert('添加二级分类请先选择上一级分类！');</script>");
                    Response.Redirect("CategoryList.aspx");
                    return;
                }
                var id = int.Parse(Request.QueryString["ID"]);
                
                var category = bll.Get(id);
                this.ID = category.ID;
                this.ClassName = category.ClassName;
            }
          
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // 创建分类对象

                Models.Category category = new Models.Category();
                category.ClassName = this.txtClassName.Text;
                category.Sort = int.Parse(this.txtSort.Text);
                category.ParentID = this.ID;

                // 添加分类
                var ok = bll.Add(category);
                if (ok)
                {
                    Response.Write("<script>alert('添加二级分类成功！');</script>");
                }
                else
                {
                    Response.Write("<script>alert('添加二级分类失败！');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('添加二级分类失败！原因：{ex.Message}');</script>");
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoryList.aspx");
        }

    }
}