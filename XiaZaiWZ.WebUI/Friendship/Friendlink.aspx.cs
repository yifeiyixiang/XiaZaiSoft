using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XiaZaiWZ.BLL;
using XiaZaiWZ.Models;
namespace XiaZaiWZ.WebUI
{
    public partial class Friendlink : System.Web.UI.Page
    {
        public static void Make(string source, string direction)
        {
            string fullPath = System.Web.HttpContext.Current.Request.Url.Authority;
            string url = "http://" + fullPath + source;
            Uri uri = new Uri(url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream resStream = response.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(resStream, Encoding.GetEncoding("gb2312")))
                {
                    string result = sr.ReadToEnd();
                    using (StreamWriter sw = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath(direction), false, Encoding.GetEncoding("gb2312")))
                    {
                        sw.Write(result);
                    }
                }
            }
        } 

            protected void Page_Load(object sender, EventArgs e)
        { 
             

            //StringWriter wr = new StringWriter();
            //Server.Execute("Friendlink.aspx", wr);
            //File.WriteAllText(Server.MapPath("abc.html"), wr.ToString());


        }
        #region//生成被请求URL静态页面

        public static void getUrltoHtml(string Url, string Path)//Url为动态页面地址，Path为生成的静态页面的物理地址及名称
        { 
            try
            { 
                System.Net.WebRequest wReq = System.Net.WebRequest.Create(Url);

                // Get the response instance.

                System.Net.WebResponse wResp = wReq.GetResponse();

                // Get the response stream.

                System.IO.Stream respStream = wResp.GetResponseStream();

                // Dim reader As StreamReader = New StreamReader(respStream)

                System.IO.StreamReader reader = new System.IO.StreamReader(respStream, System.Text.Encoding.GetEncoding("gb2312"));

                string str = reader.ReadToEnd();

                System.IO.StreamWriter sw = new System.IO.StreamWriter(Path, false, System.Text.Encoding.GetEncoding("gb2312"));

                sw.Write(str);

                sw.Flush();

                sw.Close();

                // System.Web.HttpContext.Current.Response.Write(" ");

            }

            catch (System.Exception ex)
            {

                System.Web.HttpContext.Current.Response.Write(ex);

            }

        }

        #endregion
        protected void Button1_Click(object sender, EventArgs e)
        {
            Link link = new Link();
            link.LinkName = TextBox1.Text;
            link.LinkType = RadioButton1.Checked?1:2;
            link.LinkUrl = txtlinkurl.Text;
            link.LinkLogo = txtlinklogo.Text;
            LinkService links = new LinkService();
            if (links.Add(link))
            {
                Response.Write("<script> alert('添加成功')</script>");
            }
            else
            {
                Response.Write("<script> alert('失败')</script>");
            }
            //生成静态页面
            //getUrltoHtml("http://localhost:64596/Friendlink.aspx", Request.MapPath(".") + "/Content/way1.html");
        }
    }
}