using RpCater.DAL;
using RpCater.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpCater.BLL
{
    public class OrderInfoBLL
    {
        OrderInfoDAL dal = new OrderInfoDAL();
        /// <summary>
        /// 添加订单信息
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public object AddOrderInfo(OrderInfo order)
        {
            return dal.AddOrderInfo(order);
        }

        /// <summary>
        /// 根据餐桌的id获取订单的id
        /// </summary>
        /// <param name="DeskId"></param>
        /// <returns></returns>
        public object GetOrderIdByDeskId(int deskId)
        {
            return dal.GetOrderIdByDeskId(deskId);
        }
        /// <summary>
        /// 更新点菜时间和订单金额
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="orderMoney"></param>
        /// <returns></returns>
        public bool UpdateOrderMoneyAndBeginTimeByOrderId(int orderId, double orderMoney)
        {
            return dal.UpdateOrderMoneyAndBeginTimeByOrderId(orderId, orderMoney) > 0;
        }
        /// <summary>
        /// 根据订单id获取消费金额
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public object GetMoneyByOrderId(int orderId)
        {
            return dal.GetMoneyByOrderId(orderId);
        }

           /// <summary>
        /// 更新订单信息
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public bool UpdateOrderInfo(OrderInfo order)
        {
            return dal.UpdateOrderInfo(order) > 0;
        }
    }
}
