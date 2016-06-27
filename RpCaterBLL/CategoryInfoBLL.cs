using RpCater.DAL;
using RpCater.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpCater.BLL
{
    public class CategoryInfoBLL
    {
        CategoryInfoDAL dal = new CategoryInfoDAL();
        /// <summary>
        /// 根据删除标识获取所有类别信息
        /// </summary>
        /// <param name="delFlag">删除标识</param>
        /// <returns>类别信息</returns>
        public List<CategoryInfo> GetAllCategoryInfoByDelFlag(int delFlag)
        {
            return dal.GetAllCategoryInfoByDelFlag(delFlag);
        }
        /// <summary>
        /// 新增或者修改
        /// </summary>
        /// <param name="info">实体</param>
        /// <param name="temp">1--新增，2--修改</param>
        /// <returns></returns>
        public bool AddOrUpdateCategoryInfo(CategoryInfo info, int temp)
        {
            if (temp == 1)//新增 
            {
                return dal.AddCategoryInfo(info) > 0;
            }
            else if (temp == 2)//修改
            {
                return dal.UpdateCategoryInfo(info) > 0;
            }
            return false;
        }


        /// <summary>
        /// 根据id删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool SoftDeleteCategoryInfo(int id)
        {
            return dal.SoftDeleteCategoryInfo(id) > 0;
        }
    }
}
