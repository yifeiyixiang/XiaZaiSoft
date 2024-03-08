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
    public partial class WebUI : System.Web.UI.Page
    {
        private CategoryService bll = new CategoryService(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.rpCategory.DataSource = bll.GetAllCategory();
                this.rpCategory.DataBind();
                this.Repeater1.DataSource = bll.GetAllCategory();
                this.Repeater1.DataBind(); 
                this.Repeater2.DataSource = bll.GetAllview();
                this.Repeater2.DataBind();
               
                //var categories = bll.GetFirstCategory();
                //foreach (var category in categories)
                //{ 
                //    category.SecondaryCategory = bll.GetSecondaryCategory(category.ID);
                //    var sql = $"SELECT id,Name,Uptime,Cls2_id FROM [dbo].[View] where  Cls2_id  in (select ID from Category where ParentID = {category.ID} )";
                //    var actor = BLL.DBHelper2.GetDataTable(sql); 
                //} 
            }


        }
    }
}