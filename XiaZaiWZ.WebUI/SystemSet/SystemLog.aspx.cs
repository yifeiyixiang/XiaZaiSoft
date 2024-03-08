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
    public partial class SystemLog : System.Web.UI.Page
    {
        string sql = "select * from Log";
        protected void Page_Load(object sender, EventArgs e)
        { 

            Repeater1.DataSource = BLL.DBHelper2.GetDataTable(sql);
            Repeater1.DataBind(); 
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
          
        }

        public string val;

        protected void Button1_Click(object sender, EventArgs e)
        {
              

            if (Request.Form["chk"] != null)
            {
               int a = Request.Form["chk"].Length;//a 是个数 193三个
                 
                if (a > 3)
                {
                    Response.Write("<script> alert('只能选一个删除') </script>");
                }
                else { 
                //Response.Write("<script> alert('选中') </script>");

                foreach (var item in Request.Form["chk"])
                { 
                    item.ToString();//第一个1第二个9第三个3    
                    val += item.ToString().Substring(item.ToString().Length-1);
                }
                //Response.Write(val);  
                //Console.WriteLine(val);
                LogService log = new LogService();
                log.DelID(int.Parse(val));
                Response.Write("<script> alert('删除选中日志') </script>");
                Repeater1.DataSource = BLL.DBHelper2.GetDataTable(sql);
                Repeater1.DataBind();
                }
            }


            else
            {
                Response.Write("<script> alert('未选中') </script>");

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            LogService log = new LogService();
            log.DelallLog();
            Repeater1.DataSource = BLL.DBHelper2.GetDataTable(sql);
            Repeater1.DataBind();

        }
    }
     
    } 