using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaZaiWZ.Models;
namespace XiaZaiWZ.DAL
{
   public class LogDao
    {        /// <summary>
             /// 获取所有分类
             /// </summary>
   public  bool delID(int id)
        {
            var sql=$"delete from Log   where id = { id}";
           return DBHelper.Execute(sql)>0;
        }
        public bool delall ()
        {
            var sql = $"delete  from Log ";
            return DBHelper.Execute(sql) > 0;
        }
        public bool addlog(string logname)
        {
            var sql = $"INSERT INTO Log (LogName,Time )values('{logname}登陆后台！','{ DateTime.Now}')";
            return DBHelper.Execute(sql) > 0;
        }

    }
}
