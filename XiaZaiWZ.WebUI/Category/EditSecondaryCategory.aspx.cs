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
    public partial class EditSecondaryCategory : System.Web.UI.Page
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
            if (!IsPostBack)
            { 
                if (Request.QueryString["ID"] == null)
                {
                    Response.Write("<script>alert('编辑二级分类请先选择上一级分类！');</script>");
                    Response.Redirect("CategoryList.aspx");
                    return;
                }
                var id = int.Parse(Request.QueryString["ID"]);
                var category = bll.Get(id);
                this.ID = category.ID;
                this.ClassName = category.ClassName;
                this.txtClassName.Text = category.ClassName;
                this.txtSort.Text = category.Sort.ToString();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // 获取分类对象
                var category = bll.Get(this.ID);
                category.ClassName = this.txtClassName.Text;
                category.Sort = int.Parse(this.txtSort.Text);

                // 修改分类
                var ok = bll.Update(category);
                if (ok)
                {
                    Response.Write("<script>alert('修改二级分类成功！');</script>");
                }
                else
                {
                    Response.Write("<script>alert('修改二级分类失败！');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('修改二级分类失败！原因：{ex.Message}');</script>");
            }

        }

    }
}