using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XiaZaiWZ.BLL;
using XiaZaiWZ.Models;
namespace XiaZaiWZ.WebUI
{
   
    public partial class WebForm : System.Web.UI.Page
    {/// <summary>
     /// 传入URL返回网页的html代码
     /// </summary>
     /// <param name="Url">URL</param>
     /// <returns></returns>
        public static string getUrltoHtml(string Url, string v)
        {
            string errorMsg = "";
            try
            {
                System.Net.WebRequest wReq = System.Net.WebRequest.Create(Url);
                // Get the response instance.
                System.Net.WebResponse wResp = wReq.GetResponse();
                // Read an HTTP-specific property
                //if (wResp.GetType() ==HttpWebResponse)
                //{
                //DateTime updated  =((System.Net.HttpWebResponse)wResp).LastModified;
                //}
                // Get the response stream.
                System.IO.Stream respStream = wResp.GetResponseStream();
                // Dim reader As StreamReader = New StreamReader(respStream)
                System.IO.StreamReader reader = new System.IO.StreamReader(respStream, System.Text.Encoding.GetEncoding("gb2312"));
                return reader.ReadToEnd();

            }
            catch (System.Exception ex)
            {
                errorMsg = ex.Message;
            }
            return "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //生成静态页面
            GetUrltoHtml("http://localhost:64596/WebUI.aspx", Request.MapPath(".") + "/Content/WebUI.html");
        }
        #region//生成被请求URL静态页面

        public static void GetUrltoHtml(string Url, string Path)//Url为动态页面地址，Path为生成的静态页面的物理地址及名称
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





















        //生成HTML页
        public static bool WriteFile(string strText, string strContent, string strAuthor)
        {
            string path = HttpContext.Current.Server.MapPath("/news/");
            Encoding code = Encoding.GetEncoding("gb2312");
            // 读取模板文件
            string temp = HttpContext.Current.Server.MapPath("/news/text.html");
            StreamReader sr = null;
            StreamWriter sw = null;
            string str = "";
            try
            {
                sr = new StreamReader(temp, code);
                str = sr.ReadToEnd(); // 读取文件
            }
            catch (Exception exp)
            {
                HttpContext.Current.Response.Write(exp.Message);
                HttpContext.Current.Response.End();
                sr.Close();
            }
            string htmlfilename = DateTime.Now.ToString("yyyyMMddHHmmss") + ".html";
            // 替换内容
            // 这时,模板文件已经读入到名称为str的变量中了
            str = str.Replace("ShowArticle", strText); //模板页中的ShowArticle
            str = str.Replace("biaoti", strText);
            str = str.Replace("content", strContent);
            str = str.Replace("author", strAuthor);
            // 写文件
            try
            {
                sw = new StreamWriter(path + htmlfilename, false, code);
                sw.Write(str);
                sw.Flush();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
                HttpContext.Current.Response.End();
            }
            finally
            {
                sw.Close();
            }
            return true;
        }
    }
}