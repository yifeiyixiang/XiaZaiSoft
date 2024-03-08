using XiaZaiWZ.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaZaiWZ.Models;

namespace XiaZaiWZ.BLL
{
    public class CategoryService
    {
        private CategoryDao dao = new CategoryDao();

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Add(Category obj)
        {
            return dao.Add(obj);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update(Category obj)
        {
            return dao.Update(obj);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return dao.Delete(id);
        }

        /// <summary>
        /// 获取分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Category Get(int id)
        {
            return dao.Get(id);
        }

        /// <summary>
        /// 获取所有分类
        /// </summary>
        public List<Category> GetAllCategory()
        {
            return dao.GetAllCategory();
        }
        /// <summary>
        /// 获取一级分类下二级分类文字
        /// </summary>
        public List<Category> GetAllview()
        {
            return dao.GetAllview();
        }
        /// <summary>
        /// 获取一级分类
        /// </summary>
        /// <returns></returns>
        public List<Category> GetFirstCategory()
        {
            return dao.GetFirstCategory();
        }

        /// <summary>
        /// 获取二级分类
        /// </summary>
        /// <param name="parentID">父级分类ID</param>
        /// <returns></returns>
        public List<Category> GetSecondaryCategory(int parentID)
        {
            return dao.GetSecondaryCategory(parentID);
        }
    }
}
