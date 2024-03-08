using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaZaiWZ.Models;
using XiaZaiWZ.DAL;

namespace XiaZaiWZ.BLL
{

   public   class LinkService
    {
        LinkDao link = new LinkDao();
        /// <summary>
        ///    传入固定id获取title使用的linkName
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public static List<Link> SG(int parentID)
        {
            return DAL.LinkDao.SG(parentID);

        }
        #region 修改站点名称
        public static bool UPGet(string lname,int id)
        {
            return DAL.LinkDao.UPGet(lname,id);
        }
        #endregion
        public static Link GetName(string name)
        {
            return LinkDao.SGet(name);
        }
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static Link IdGetName(int id)
        {
            return LinkDao.Get(id);
           }

        /// <summary>
        /// 新增站点
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Add(Link obj)
        {
            return link.Add(obj);
        }

        /// <summary>
        /// id get link all
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Link idGetLink(int obj)
        {
            return LinkDao.Get(obj);
        }
     // id修改站点
        public  bool UPdate(Link obj)
        {
            return LinkDao.idUPdate(obj);
        }
    }
}
