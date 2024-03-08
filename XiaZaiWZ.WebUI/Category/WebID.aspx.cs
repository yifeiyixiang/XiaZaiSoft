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
    
    public partial class WebID : System.Web.UI.Page
    {
        private CategoryService bll = new CategoryService();
        private viewService bll2 = new viewService();
        protected void Page_Load(object sender, EventArgs e)
        { if (!IsPostBack)
            {
                if (Request.QueryString["ID"] == null)
                {
                    Response.Write("<script> alert('请先选择ID') </script>");
                    Response.Redirect("../WebUI.aspx");
                    return;
                }
                this.rpCategory.DataSource = bll.GetAllCategory();
                this.rpCategory.DataBind();
                this.Repeater1.DataSource = bll.GetAllCategory();
                this.Repeater1.DataBind();
                var ad = Request.QueryString["ID"].ToString();
                var aid = Convert.ToInt32(ad);
                //判断是否是文章 直接换a标签的路径，文章另外网页传值


                var sql1 = $"select ClassName,ParentID from Category where ID={ad}";
               var a1= DBHelper2.GetDataTable(sql1);
                if (a1.Rows.Count < 1)
                {
                    Response.Write("<script> alert('请先选择ID') </script>");
                }
                else
                {//对标 
                var parentid = Convert.ToInt32(a1.Rows[0][1]);
              if(parentid == 0)
                {
                 
                    var sqlsecond = $"select ID,ClassName from Category where ParentID={ad}";
                    //this.Repeater2.DataSource = bll.GetSecondaryCategory(Convert.ToInt32(ad));
                    this.Repeater2.DataSource = bll2.adget(Convert.ToInt32(ad));
                    this.Repeater2.DataBind();
                }
                else
                {
                    var sqll2 = $"select ID,ClassName from Category where ID={ad}";
                    var a2 = DBHelper2.GetDataTable(sqll2);
                    var secondid= Convert.ToInt32(a2.Rows[0][0]);
                    if (aid == secondid)
                    {
                        //this.Repeater2.DataSource = bll2.adget(Convert.ToInt32(ad));
                        //var vie = new Models.View();
                        //    vie.Cls2_id = aid;
                        this.Repeater2.DataSource = bll2.idGetsecondview(Convert.ToInt32(ad));
                        this.Repeater2.DataBind();
                    }
                    else
                    {
                        //var sqll3 = $"select ID,ClassName from Category where ID={ad}";
                        //var a3 = DBHelper2.GetDataTable(sqll2);
                        //var thirdid = Convert.ToInt32(a2.Rows[0][0]);
                        this.Repeater2.Visible = true;
                        Response.Write("<script> alert('发生了啥？') </script>");
                    }

                }


                    //var categories = bll.GetFirstCategory();
                    //foreach (var category in categories)
                    //{ 
                    //    category.SecondaryCategory = bll.GetSecondaryCategory(category.ID);
                    //    var sql = $"SELECT id,Name,Uptime,Cls2_id FROM [dbo].[View] where  Cls2_id  in (select ID from Category where ParentID = {category.ID} )";
                    //    var actor = BLL.DBHelper2.GetDataTable(sql); 
                    //} 
                }//对标  
            }
        }
    }
}