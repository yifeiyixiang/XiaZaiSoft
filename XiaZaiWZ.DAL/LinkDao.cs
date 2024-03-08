using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaZaiWZ.Models;


namespace XiaZaiWZ.DAL
{
  public   class LinkDao
    {
        /// <summary>
        ///    传入固定id获取title使用的标题linkName
        /// </summary>  
        public static List<Link> SG(int parentID)
        {
            List<Link> categories = null;

            var sql = $"select id, LinkName from Link where id = {parentID}";
            using (var reader = DBHelper.ExecuteReader(sql))
            {
                categories = new List<Link>();
                while (reader.Read())
                {
                    var category = new Link
                    {   id = reader.GetInt32(0),
                        LinkName = reader.GetString(1), 
                    };
                    categories.Add(category);
                }
            } 
            return categories;
        }
        #region 修改站点名称
        public static bool UPGet(string lname,int id)
        {
            var sql = "update  Link  set  LinkName=@LName where id =@ID";
            return DBHelper.Execute(sql, new SqlParameter[]
           {
                new SqlParameter("@LName", lname),
              
                new SqlParameter("@ID",id)
           }) > 0;

        }
        #endregion
        #region id修改站点
        public static  bool idUPdate( Link obj)
        {
            var sql = "UPDATE [dbo].[Link] SET [LinkName] = @LName,[LinkUrl] =@LinkUrl,[LinkLogo] =@LinkLogo,[LinkType] =@LinkType WHERE id=@ID";
            return DBHelper.Execute(sql, new SqlParameter[]
           {
                new SqlParameter("@LName", obj.LinkName),
                   new SqlParameter("@LinkUrl", obj.LinkUrl),
                     new SqlParameter("@LinkLogo", obj.LinkLogo),
                            new SqlParameter("@LinkType", obj.LinkType),
                new SqlParameter("@ID",obj.id)
           })>0;

        }
        #endregion
        /// <summary>
        /// 新增站点
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Add(Link obj)
        {
            var sql = $"INSERT INTO [dbo].[Link]  ([LinkName] ,[LinkUrl] ,[LinkLogo]  ,[LinkType])  VALUES ('{obj.LinkName}','{obj.LinkUrl}','{obj.LinkLogo}','{obj.LinkType}') ";
            return DBHelper.Execute(sql) > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            var sql = "delete from UserInfo where ID = " + id;
            return DBHelper.Execute(sql) > 0;
        }

        /// <summary>
        /// id获取 link
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static Link Get(int id)
        {
            Link user = null; 
            var sql = "select id, LinkName, LinkUrl, LinkLogo,LinkType from Link where id ="+id;
            var reader = DBHelper.ExecuteReader(sql); 
            using (reader)
            {
                while (reader.Read())
                {
                    user = new Link()
                    {
                        id = reader.GetInt32(0),
                        LinkName = reader.GetString(1),
                        LinkUrl = reader.GetString(2),
                        LinkLogo = reader.GetString(3),
                        LinkType= reader.GetInt32(4)
                    };
                }
            }

            return user;
        }

          
        public  static Link SGet(string userName)
        {
            Link user = null;

            var sql = "select * from Link where LinkName = @UserName";
            var reader = DBHelper.ExecuteReader(sql, new SqlParameter[]
            {
                new SqlParameter("@UserName", userName)
            });

            using (reader)
            {
                while (reader.Read())
                {
                    user = new Link()
                    {
                        id = reader.GetInt32(0),
                        LinkName = reader.GetString(1), 
                    };
                }
            }

            return user;
        }
        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> GetAll()
        {
            List<UserInfo> users = null;

            var sql = "select ID, UserCode, UserName, Password from UserInfo";
            using (var reader = DBHelper.ExecuteReader(sql))
            {
                users = new List<UserInfo>();
                while (reader.Read())
                {
                    var user = new UserInfo
                    {
                        ID = reader.GetInt32(0),
                        UserCode = reader.GetString(1),
                        UserName = reader.GetString(2),
                        Password = reader.GetString(3)
                    };
                    users.Add(user);
                }
            }

            return users;
        }
    }
}
