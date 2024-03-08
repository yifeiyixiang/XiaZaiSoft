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
     

    public partial class CategoryList : System.Web.UI.Page
    {
        private CategoryService bll = new CategoryService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.rpCategory.DataSource = bll.GetAllCategory();
                this.rpCategory.DataBind();
            }
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            try
            {
                // 获取分类ID
                var id = int.Parse(e.CommandArgument.ToString());

                // 删除分类
                if (e.CommandName == "删除一级分类")
                {
                    var categories = bll.GetSecondaryCategory(id);
                    if (categories.Count > 0)
                    {
                        Response.Write("<script>alert('当前分类下面有二级分类，不允许删除！');</script>");
                    }
                    else
                    {
                        var ok = bll.Delete(id); // 删除一级分类
                        if (ok)
                        {
                            Response.Write("<script>alert('删除一级分类成功！');</script>");
                            this.rpCategory.DataSource = bll.GetAllCategory();
                            this.rpCategory.DataBind();
                        }
                        else
                        {
                            Response.Write("<script>alert('删除一级分类失败！');</script>");
                        }
                    }
                }
                else
                {
                    var ok = bll.Delete(id); // 删除二级分类
                    if (ok)
                    {
                        Response.Write("<script>alert('删除二级分类成功！');</script>");
                        this.rpCategory.DataSource = bll.GetAllCategory();
                        this.rpCategory.DataBind();
                    }
                    else
                    {
                        Response.Write("<script>alert('删除二级分类失败！');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('删除分类失败！原因：{ex.Message}');</script>");
            }
        }
    }
}