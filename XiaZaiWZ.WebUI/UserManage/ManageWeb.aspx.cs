using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XiaZaiWZ.BLL;

namespace XiaZaiWZ.WebUI.UserManage
{
    public partial class AleterWeb : System.Web.UI.Page
    {
        string sql1 = "select * from Admin";
        string sql2 = "select * from UserInfo";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Repeater1.DataSource = BLl.DBHelper2.GetDataTable(sql);
            //Repeater1.DataBind();

            GridView1.DataSource = BLL.DBHelper2.GetDataTable(sql1);
            GridView1.DataBind();

            GridView2.DataSource = BLL.DBHelper2.GetDataTable(sql2);
            GridView2.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
                int id = Convert.ToInt32(((System.Web.UI.WebControls.LinkButton)e.CommandSource).CommandArgument);

            if (((System.Web.UI.WebControls.LinkButton)e.CommandSource).Text == "删除")
            {
                var sql = $"DELETE FROM Admin WHERE id={id}";
                if (BLL.DBHelper2.ExecuteNonQuery(sql))
                {
                    Response.Write("<script> alert('删除成功')</script>");
                    GridView1.DataSource = BLL.DBHelper2.GetDataTable(sql1);
                    GridView1.DataBind();
                }
            }
            else if (((System.Web.UI.WebControls.LinkButton)e.CommandSource).Text == "删除.")
            {
                var sqll = $"DELETE FROM UserInfo WHERE ID={id}";
                if (BLL.DBHelper2.ExecuteNonQuery(sqll))
                {
                    Response.Write("<script> alert('删除成功')</script>");
                    GridView2.DataSource = BLL.DBHelper2.GetDataTable(sql2);
                    GridView2.DataBind();
                }
            }
            else
            {
                Response.Write("<script> alert('删除失败') </script>");
            }

            } 
        }
    } 