using RpCater.DAL;
using RpCater.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpCater.BLL
{
    public class R_Order_ProductBLL
    {
        R_Order_ProductDAL dal = new R_Order_ProductDAL();
        /// <summary>
        /// 添加订单产品中间表信息
        /// </summary>
        /// <param name="rop"></param>
        /// <returns></returns>
        public bool AddR_Order_Product(R_Order_Product rop)
        {
            return dal.AddR_Order_Product(rop) > 0;
        }
        /// <summary>
        /// 根据订单id获取该订单下面的所有商品
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<R_Order_Product> GetProductByOrderId(int orderId)
        {
            return dal.GetProductByOrderId(orderId);
        }
        /// <summary>
        /// 删除订单下的产品
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public bool SoftDeleteR_Order_ProByRpoId(int rpoId)
        {
            return dal.SoftDeleteR_Order_ProByRpoId(rpoId) > 0;
        }

        /// <summary>
        /// 更新订单菜单中间表状态
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public bool UpdateR_Order_ProductByOrderId(int orderId)
        {
            return dal.UpdateR_Order_ProductByOrderId(orderId) > 0;
        }
    }
}
