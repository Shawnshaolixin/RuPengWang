using RpCater.DAL;
using RpCater.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpCater.BLL
{
    public class ProductInfoBLL
    {
        ProductInfoDAL dal = new ProductInfoDAL();
        /// <summary>
        /// 根据删除标记获取所有产品信息
        /// </summary>
        /// <param name="delFlag"></param>
        /// <returns>所有产品信息</returns>
        public List<ProductInfo> GetAllProductInfoByFlag(int delFlag)
        {
            return dal.GetAllProductInfoByFlag(delFlag);
        }
        /// <summary>
        /// 新增或者修改商品
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pro"></param>
        /// <param name="temp"></param>
        /// <returns></returns>
        public bool AddOrUpdateProductInfo(ProductInfo pro, int temp)
        {
            if (temp == 1)
            {
                return dal.AddProductInfo(pro) > 0;
            }
            else if (temp == 2)
            {
                return dal.UpdateProductInfo(pro) > 0;
            }
            return false;
        }


        /// <summary>
        /// 根据id删除商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool SoftDeleteProductInfoById(int id)
        {
            return dal.SoftDeleteProductInfoById(id) > 0;
        }
        /// <summary>
        /// 根据类别id查看商品总条数
        /// </summary>
        /// <param name="cId"></param>
        /// <returns></returns>
        public int GetProCountByCId(int cId)
        {
            return (int)dal.GetProCountByCId(cId);
        }

        /// <summary>
        /// 根据列表id获取对应产品
        /// </summary>
        /// <param name="cId"></param>
        /// <returns></returns>
        public List<ProductInfo> GetProductInfoByCId(int cId)
        {
            return dal.GetProductInfoByCId(cId);
        }
        /// <summary>
        /// 根据拼音或者编号模糊搜索
        /// </summary>
        /// <param name="name">1拼音 2编号</param>
        /// <returns></returns>
        public List<ProductInfo> GetProductByProSpellOrProNum(int temp, string name)
        {
            return dal.GetProductByProSpellOrProNum(temp, name);
        }
    }
}
