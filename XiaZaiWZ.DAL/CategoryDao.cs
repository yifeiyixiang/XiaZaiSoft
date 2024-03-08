using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaZaiWZ.Models;

namespace XiaZaiWZ.DAL
{
    /// <summary>
    /// 分类Dao
    /// </summary>
    public class CategoryDao
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Add(Category obj)
        {
            var sql = "insert into Category(ClassName, Sort,ParentID) values(@ClassName, @Sort, @ParentID)";
            return DBHelper.Execute(sql, new SqlParameter[]
            {
                new SqlParameter("@ClassName", obj.ClassName),
                new SqlParameter("@Sort", obj.Sort),
                new SqlParameter("@ParentID", obj.ParentID)
            }) > 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update(Category obj)
        {
            var sql = "update Category set ClassName=@ClassName, Sort=@Sort, ParentID=@ParentID where ID=@ID";
            return DBHelper.Execute(sql, new SqlParameter[]
            {
                new SqlParameter("@ClassName", obj.ClassName),
                new SqlParameter("@Sort", obj.Sort),
                new SqlParameter("@ParentID", obj.ParentID),
                new SqlParameter("@ID", obj.ID)
            }) > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            var sql = "delete from Category where ID = " + id;
            return DBHelper.Execute(sql) > 0;
        }

        /// <summary>
        /// 获取分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Category Get(int id)
        {
            Category category = null;

            var sql = "select ID, ClassName, Sort, ParentID from Category where ID = @ID";
            var reader = DBHelper.ExecuteReader(sql, new SqlParameter[]
            {
                new SqlParameter("@ID", id)
            });

            using (reader)
            {
                while (reader.Read())
                {
                    category = new Category()
                    {
                        ID = reader.GetInt32(0),
                        ClassName = reader.GetString(1),
                        Sort = reader.GetInt32(2),
                        ParentID = reader.GetInt32(3)
                    };
                }
            }

            return category;
        }


        /// <summary>
        /// 获取主页一级分类下二级分类的文章
        /// </summary>
        public List<Category> GetActor()
        {
            var categories = this.GetFirstCategory();
            foreach (var category in categories)
            {
                //var sql = $"SELECT id,Name,Uptime,Cls2_id FROM [dbo].[View] where  Cls2_id  in (select ID from Category where ParentID = {category.ID} )";
                category.SecondaryCategory = this.GetSecondaryCategory(category.ID);
                var sql = $"SELECT id,Name,Uptime,Cls2_id FROM [dbo].[View] where  Cls2_id  in (select ID from Category where ParentID = {category.ID} )";
                var actor = DBHelper.ExecuteQuery(sql);
            }
           
            return categories;
        }
        /// <summary>
        /// 获取所有分类
        /// </summary>
        public List<Category> GetAllCategory()
        {
            var categories = this.GetFirstCategory(); 
            foreach (var category in categories)
            {
                category.SecondaryCategory = this.GetSecondaryCategory(category.ID); 
            }
            return categories;
        }
        /// <summary>
        /// list all view 
        /// </summary>
        /// <returns></returns>
        public List<Category> GetAllview()
        {
            //List<View> acview2 = null; 
            //var acview3 = this.GetViewAll();
            //View acview = new View();
            Category acviewac = new Category();
            var categories = this.GetFirstCategory();
            foreach (var category in categories)
            {
                category.SecondaryCategory = this.GetSecondaryCategory(category.ID);
                category.SecondaryCategoryac = this.GetViewAC(category.ID);
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
        /// <summary>
        /// 一级分类下二级分类的所有文章
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public List<View> GetViewAC(int parentID)
        {
            List<View> categoriesac = null;
            var sql = $"SELECT id,Name,Language,Size,SizeNum,Uptime,Format,Content,DownUrl,Tong,Cls1_id,Cls2_id FROM [dbo].[View] where  Cls2_id  in(select ID from Category where ParentID={parentID}) ";
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
                        Language= reader.GetString(2),
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
        /// <summary>
        /// 一级分类下二级分类的各个文章
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public List<View> GetViewACsecond(int id)
        {
            List<View> categoriesac = null;
            //var sql = $"select ID from Category where ParentID={id}";
            //var secondid = dbhelper1.GetDataTable(sql).ToString();
            //foreach (var item in id)
            //{
                var sqll = $"SELECT id,Name,Language,Size,SizeNum,Uptime,Format,Content,DownUrl,Tong,Cls1_id,Cls2_id FROM [dbo].[View] where  Cls2_id  ={id} ";
                using (var reader = DBHelper.ExecuteReader(sqll))
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

            //var sql = $"SELECT id,Name,Uptime,Cls2_id FROM [dbo].[View] where  Cls2_id  in (select ID from Category where ParentID = {parentID} )";
           
            //}

            return categoriesac;
        }

        /// <summary>
        /// 获取一级分类
        /// </summary>
        /// <returns></returns>
        public List<Category> GetFirstCategory()
        {
            List<Category> categories = null;

            var sql = "select ID, ClassName, Sort, ParentID from Category where ParentID = 0 order by Sort";
            using (var reader = DBHelper.ExecuteReader(sql))
            {
                categories = new List<Category>();
                while (reader.Read())
                {
                    var category = new Category
                    {
                        ID = reader.GetInt32(0),
                        ClassName = reader.GetString(1),
                        Sort = reader.GetInt32(2),
                        ParentID = reader.GetInt32(3)
                    };
                    categories.Add(category);
                }
            }

            return categories;
        }

        /// <summary>
        /// 获取二级分类
        /// </summary>
        /// <param name="parentID">父级分类ID</param>
        /// <returns></returns>
        public List<Category> GetSecondaryCategory(int parentID)
        {
            List<Category> categories = null;

            var sql = $"select ID, ClassName, Sort, ParentID from Category where ParentID = {parentID} order by Sort";
            using (var reader = DBHelper.ExecuteReader(sql))
            {
                categories = new List<Category>();
                while (reader.Read())
                {
                    var category = new Category
                    {
                        ID = reader.GetInt32(0),
                        ClassName = reader.GetString(1),
                        Sort = reader.GetInt32(2),
                        ParentID = reader.GetInt32(3)
                    };
                    categories.Add(category);
                }
            }

            return categories;
        }
        /// <summary>
        /// 得到所有view
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public List<View> GetViewAll()
        {
            List<View> categoriesac = null;
            var sql = "SELECT id,Name,Language,Size,SizeNum,Uptime,Format,Content,DownUrl,Tong,Cls1_id,Cls2_id FROM [dbo].[View] ";
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
    }
}
