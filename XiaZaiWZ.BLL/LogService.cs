using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaZaiWZ.Models;
using XiaZaiWZ.DAL;
namespace XiaZaiWZ.BLL
{
   public class LogService
    {
        private LogDao dao = new LogDao();
        /// <summary>
        /// 获取所有分类
        /// </summary>
        public static void getlog()
        {
            var sql = "select * from Log";
              //DBHelper2.GetDataTable(sql);
        }
        #region 删除id日志
        public bool DelID(int id)
        {
            return dao.delID(id);
        }
        #endregion
        #region 删除所有日志
        public bool DelallLog()
        {
            return dao.delall();
        }
        #endregion
        #region 添加日志
        public bool AddLog(string logname)
        {
            return dao.addlog(logname);
        }
        #endregion
    }
}
