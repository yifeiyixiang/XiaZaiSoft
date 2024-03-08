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
        /// 用户Dao
        /// </summary>
        public class UserInfoDao
        {
            /// <summary>
            /// 新增
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public bool Add(UserInfo obj)
            {
                var sql = "insert into UserInfo(UserCode, UserName, Password) values(@UserCode, @UserName, @Password)";
                return DBHelper.Execute(sql, new SqlParameter[]
                {
                new SqlParameter("@UserCode", obj.UserCode),
                new SqlParameter("@UserName", obj.UserName),
                new SqlParameter("@Password", obj.Password)
                }) > 0;
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
            /// 获取
            /// </summary>
            /// <param name="userName"></param>
            /// <returns></returns>
            public UserInfo Get(string userName)
            {
                UserInfo user = null;

                var sql = "select ID, UserCode, UserName, Password from UserInfo where UserName = @UserName";
                var reader = DBHelper.ExecuteReader(sql, new SqlParameter[]
                {
                new SqlParameter("@UserName", userName)
                });

                using (reader)
                {
                    while (reader.Read())
                    {
                        user = new UserInfo()
                        {
                            ID = reader.GetInt32(0),
                            UserCode = reader.GetString(1),
                            UserName = reader.GetString(2),
                            Password = reader.GetString(3)
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
