using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaZaiWZ.DAL;
using XiaZaiWZ.Models;
namespace XiaZaiWZ.BLL
{
 public   class viewService
    {
        /// <summary>
        /// obj view 更新
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        viewdao vie = new viewdao();
        public View Get(int id)
        {
            return vie.Get(id);

        }   
        /// <summary>
            /// view id 修改 view 
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
        public bool Update(View obj)
        {
            return vie.Update(obj);
        }
        /// <summary>
        /// id获取view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public View get(int obj)
        {
            return vie.Get(obj);
        }
        public View getacid(int obj)
        {
            return vie.Getacid(obj);
        }
        /// <summary>
        /// 一级 id 获取二级文章
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public List<Category> adget(int id)
        {
            return vie.adgetGetAllview(id);
        }

        /// <summary>
        /// 二级 id 获取二级文章
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public List<Category> idGetsecondview(int id)
        {
            return vie.idGetsecondview(id);
        }
      

    }
}
