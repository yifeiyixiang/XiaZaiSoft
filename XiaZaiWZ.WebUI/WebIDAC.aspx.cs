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
    public partial class WebIDAC : System.Web.UI.Page
    {
        private CategoryService bll = new CategoryService();
        private viewService bll2 = new viewService();
        private viewService view = new viewService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] == null)
                {
                    Response.Write("<script> alert('请先选择ID') </script>");
                    Response.Redirect("WebUI.aspx");
                    return;
                }
                this.rpCategory.DataSource = bll.GetAllCategory();
                this.rpCategory.DataBind();
                this.Repeater1.DataSource = bll.GetAllCategory();
                this.Repeater1.DataBind();
                var ad = Request.QueryString["ID"].ToString();
                var aid = Convert.ToInt32(ad);
                //判断是否是文章 直接换a标签的路径，文章另外网页传值  
                var a1 = bll2.getacid(aid);
                if (a1 != null)
                {
                    var id = aid;
                    var views = view.Get(id);
                    var sqll = $"select ClassName from Category where ID in(select ParentID from Category where ID={views.Cls2_id})";
                    var a = DBHelper2.GetDataTable(sqll);
                    var sqll2 = $"select ClassName from Category where  ID={views.Cls2_id}";
                    var a2 = DBHelper2.GetDataTable(sqll2);
                    if (DBHelper2.GetDataTable(sqll) != null)
                    {
                        this.txtFile.Text = views.Name;
                        if (a.Rows.Count < 1)
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
                    else
                    {
                        Response.Write("<script> alert('此ID没有文章') </script>");
                    }
                    //var sql1 = $"select ClassName,ParentID from Category where ID={ad}";
                    //var a1 = DBHelper2.GetDataTable(sql1);
                    //if (a1.Rows.Count < 1)
                    //{
                    //    Response.Write("<script> alert('请先选择ID') </script>");
                    //}
                    //else
                    //{//对标 
                    //    var parentid = Convert.ToInt32(a1.Rows[0][1]);
                    //    if (parentid == 0)
                    //    {

                    //        var sqlsecond = $"select ID,ClassName from Category where ParentID={ad}";
                    //        //this.Repeater2.DataSource = bll.GetSecondaryCategory(Convert.ToInt32(ad));
                    //        this.Repeater2.DataSource = bll2.adget(Convert.ToInt32(ad));
                    //        this.Repeater2.DataBind();
                    //    }
                    //    else
                    //    {
                    //        var sqll2 = $"select ID,ClassName from Category where ID={ad}";
                    //        var a2 = DBHelper2.GetDataTable(sqll2);
                    //        var secondid = Convert.ToInt32(a2.Rows[0][0]);
                    //        if (aid == secondid)
                    //        {
                    //            //this.Repeater2.DataSource = bll2.adget(Convert.ToInt32(ad));
                    //            //var vie = new Models.View();
                    //            //    vie.Cls2_id = aid;
                    //            this.Repeater2.DataSource = bll2.idGetsecondview(Convert.ToInt32(ad));
                    //            this.Repeater2.DataBind();
                    //        }
                    //        else
                    //        {
                    //            //var sqll3 = $"select ID,ClassName from Category where ID={ad}";
                    //            //var a3 = DBHelper2.GetDataTable(sqll2);
                    //            //var thirdid = Convert.ToInt32(a2.Rows[0][0]);
                    //            this.Repeater2.Visible = true;
                    //            Response.Write("<script> alert('发生了啥？') </script>");
                    //        }

                    //    }


                    //    //var categories = bll.GetFirstCategory();
                    //    //foreach (var category in categories)
                    //    //{ 
                    //    //    category.SecondaryCategory = bll.GetSecondaryCategory(category.ID);
                    //    //    var sql = $"SELECT id,Name,Uptime,Cls2_id FROM [dbo].[View] where  Cls2_id  in (select ID from Category where ParentID = {category.ID} )";
                    //    //    var actor = BLL.DBHelper2.GetDataTable(sql); 
                    //    //} 
                    //}//对标  
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var a2 = TextBox3.Text;
            Response.ContentType = "application/x-zip-compressed";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + a2);
            string filename = Server.MapPath(a2);
            if (System.IO.File.Exists(filename))
            { 
                Response.TransmitFile(filename); 
            }
            else
            {
                Response.Write("<script>alert('请先上传文件到服务器！');</script>");
            }
            

        }
    }
}