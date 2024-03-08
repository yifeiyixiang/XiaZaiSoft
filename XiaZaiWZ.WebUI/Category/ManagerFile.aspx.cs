using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XiaZaiWZ.WebUI.Category
{
    public partial class ManagerFile : System.Web.UI.Page
    {
        string sql1 = "select * from [View]";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = BLL.DBHelper2.GetDataTable(sql1);
                GridView1.DataBind();
            }
        
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(((System.Web.UI.WebControls.LinkButton)e.CommandSource).CommandArgument);

            if (((System.Web.UI.WebControls.LinkButton)e.CommandSource).Text == "删除")
            {
                var sql = $"DELETE FROM [View] WHERE id={id}";
                if (BLL.DBHelper2.ExecuteNonQuery(sql))
                {
                    Response.Write("<script> alert('删除成功')</script>");
                    GridView1.DataSource = BLL.DBHelper2.GetDataTable(sql1);
                    GridView1.DataBind();
                }
            } 
            else
            {
                Response.Write("<script> alert('删除失败') </script>");
            }

        }

 
    } 
}