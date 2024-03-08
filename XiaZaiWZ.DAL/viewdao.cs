using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaZaiWZ.Models; 
namespace XiaZaiWZ.DAL
{
  public  class viewdao
    {
        /// <summary>
    /// obj view 更新
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
        public bool Update(View obj)
        {
            var sql = $"UPDATE [dbo].[View] set Name='{ obj.Name}',Size={obj.Size},Content='{obj.Content}',DownUrl='{obj.DownUrl}',Tong='{obj.Tong}' where id = {obj.id}";
            return dbhelper1.ExecuteNonQuery(sql);
            //var sql= $"UPDATE [dbo].[View] set Name=@Name,Uptime=@Uptime,Content=@Content,DownUrl=@DownUrl,Tong=@Tong where id = @ID";
            //Cls1_id = @Cls1_id,Cls2_id = @Cls2_id,Language=@Language,Size=@Size,SizeNum=@SizeNum,Format=@Format,
            //return DBHelper.Execute(sql, new SqlParameter[]
            //{ new SqlParameter("@ID", obj.id),
            //    new SqlParameter("@Name", obj.Name),
            //    //new SqlParameter("@Language", obj.Language),
            //    //new SqlParameter("@Size", obj.Size),
            //    //new SqlParameter("@SizeNum", obj.SizeNum),
            //      new SqlParameter("@Uptime", obj.Uptime),
            //       //new SqlParameter("@Format", obj.Format),
            //        new SqlParameter("@Content", obj.Content),
            //         new SqlParameter("@DownUrl", obj.DownUrl), 
            //     new SqlParameter("@Tong", obj.Tong),
            //     //new SqlParameter("@Cls1_id", obj.Cls1_id),
            //     //new SqlParameter("@Cls2_id", obj.Cls2_id),
            //}) > 0;
        }
        /// <summary>
        /// view id 修改 view 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public View Set(int id)
        {
            View category = null;

            var sql = "UPDATE [dbo].[View] id,Name,Language,Size,SizeNum,Uptime,Format,Content,DownUrl,Tong,Cls1_id,Cls2_id where ID = @ID";
            
            return category;
        }

        /// <summary>
        /// id获取view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public View Getacid(int id)
        {
            View category = null;

            var sql = "SELECT id,Name,Language,Size,SizeNum,Uptime,Format,Content,DownUrl,Tong,Cls1_id,Cls2_id FROM [dbo].[View] where id= @ID";
            var reader = DBHelper.ExecuteReader(sql, new SqlParameter[]
            {
                new SqlParameter("@ID", id)
            });

            using (reader)
            {
                while (reader.Read())
                {
                    category = new View()
                    {
                        id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Language = reader.GetString(2),
                        Size = reader.GetInt32(3),
                        SizeNum = reader.GetString(4),
                        Uptime = reader.GetString(5),
                        Format = reader.GetString(6),
                        Content = reader.GetString(7),
                        DownUrl = reader.GetString(8),
                        Tong = reader.GetString(9),
                        Cls1_id = reader.GetInt32(10),
                        Cls2_id = reader.GetInt32(11),
                    };
                }
            }

            return category;
        }
        public View Get(int id)
        {
            View category = null;

            var sql = "SELECT id,Name,Language,Size,SizeNum,Uptime,Format,Content,DownUrl,Tong,Cls1_id,Cls2_id  FROM [dbo].[View] where id = @ID";
            var reader = DBHelper.ExecuteReader(sql, new SqlParameter[]
            {
                new SqlParameter("@ID", id)
            });

            using (reader)
            {
                while (reader.Read())
                {
                    category = new View()
                    {
                        id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Language = reader.GetString(2),
                        Size = reader.GetInt32(3),
                        SizeNum = reader.GetString(4),
                        Uptime = reader.GetString(5),
                        Format = reader.GetString(6),
                        Content = reader.GetString(7),
                        DownUrl = reader.GetString(8),
                        Tong = reader.GetString(9),
                        Cls1_id = reader.GetInt32(10),
                        Cls2_id = reader.GetInt32(11),
                    };
                }
            }

            return category;
        }
        /// <summary>
        /// 一级 id 获取二级文章
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public List<View> adget(int id)
        {
            List<View> categoriesac = null;
            var sql = $"SELECT id,Name,Language,Size,SizeNum,Uptime,Format,Content,DownUrl,Tong,Cls1_id,Cls2_id  FROM [dbo].[View] where Cls2_id in (select ID from Category where ParentID ={id} )";
            //var sql = $"SELECT id,Name,Uptime,Cls2_id FROM [dbo].[View] where  Cls2_id  in (select ID from Category where ParentID = {parentID} )";
            using (var reader = DBHelper.ExecuteReader(sql))
            {
                categoriesac = new List<View>();
                while (reader.Read())
                {
                    var category = new View
                    {
                        id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Language = reader.GetString(2),
                        Size = reader.GetInt32(3),
                        SizeNum = reader.GetString(4),
                        Uptime = reader.GetString(5),
                        Format = reader.GetString(6),
                        Content = reader.GetString(7),
                        DownUrl = reader.GetString(8),
                        Tong = reader.GetString(9),
                        Cls1_id = reader.GetInt32(10),
                        Cls2_id = reader.GetInt32(11),
                    };
                    categoriesac.Add(category);
                }
            }

            return categoriesac;
        }
        public List<Category> adgetGetAllview(int id)
        {
            //var categories = dao.GetFirstCategory();
            //如果是一级get ，classname优先一级拿不到二级classname，由于有一级id直接拿二级classname
            var categories = dao.GetSecondaryCategory(id);
            foreach (var category in categories)
            {
                //category.SecondaryCategory = dao.GetSecondaryCategory(category.ID);
                category.SecondaryCategoryac = dao.GetViewACsecond(category.ID);
                //var sedcategory = this.GetSecondaryCategory(category.ID);
                //foreach (var view in sedcategory)
                //{
                //    acviewac.SecondaryCategoryac= GetViewAC(view.ID);
                //    //acview.SecondaryCategoryac = GetViewAC(view.ID);
                //    //acview3.Add(acview);
                //    categories.Add(acviewac);
                //}
            }
             
            return categories;

        }
        private CategoryDao dao = new CategoryDao();

        public List<Category> idGetsecondview(int id)
        {
            
            List<Category> categories = null; 
            var sql = $"select ID, ClassName from Category where ID = {id} ";
            using (var reader = DBHelper.ExecuteReader(sql))
            {
                categories = new List<Category>();
                while (reader.Read())
                {
                    var category = new Category
                    {
                        ID = reader.GetInt32(0),
                        ClassName = reader.GetString(1), 
                    };
                    categories.Add(category);
                }
            }
            foreach (var category in categories)
            {
                category.SecondaryCategoryac = dao.GetViewACsecond(id);
            }
                return categories; 
        }
    }
}
