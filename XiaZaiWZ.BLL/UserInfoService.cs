using XiaZaiWZ.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaZaiWZ.Models;

namespace XiaZaiWZ.BLL
{
    public class UserInfoService
    {
        private UserInfoDao dao = new UserInfoDao();
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool AddUser(UserInfo obj)
        {
            obj.UserCode = DateTime.Now.Ticks.ToString(); 
            return dao.Add(obj);
        }
         
        /// <summary>
        /// 验证用户是否有效
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public UserInfo CheckUser(UserInfo obj, out string msg)
        {
            msg = "";
            var user = dao.Get(obj.UserName);
            if (user == null)
            {
                msg = "无效的用户名";
            }
            else
            {
                if (obj.Password != user.Password)
                {
                    msg = "无效的密码";
                    return null;
                }
            }

            return user;
        }
    }
}
