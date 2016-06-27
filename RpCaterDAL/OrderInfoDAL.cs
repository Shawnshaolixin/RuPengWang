using RpCater.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpCater.DAL
{
    public class OrderInfoDAL
    {
        /// <summary>
        /// 更新订单信息
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int UpdateOrderInfo(OrderInfo order)
        {
            string sql = "update OrderInfo set OrderState=@OrderState,OrderMemberId=@OrderMemberId,EndTime=@EndTime,OrderMoney=@OrderMoney,DisCount=@DisCount where OrderId=@OrderId";
            SqlParameter[] ps ={
            new SqlParameter("@OrderState",order.OrderState),
                 new SqlParameter("@OrderMemberId",order.OrderMemberId),
                 new SqlParameter("@EndTime",order.EndTime),
                 new SqlParameter("@OrderMoney",order.OrderMoney),
                 new SqlParameter("@DisCount",order.DisCount),
                 new SqlParameter("@OrderId",order.OrderId)
            };

            return SqlHelper.ExecuteNonQuery(sql, ps);
        }

        /// <summary>
        /// 根据订单id获取消费金额
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public object GetMoneyByOrderId(int orderId)
        {
            string sql = "select ordermoney from OrderInfo where DelFlag=0 and OrderId=" + orderId;
            return SqlHelper.ExecuteScalar(sql);
        }
        /// <summary>
        /// 更新点菜时间和订单金额
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="orderMoney"></param>
        /// <returns></returns>
        public int UpdateOrderMoneyAndBeginTimeByOrderId(int orderId, double orderMoney)
        {
            string sql = "update OrderInfo set BeginTime=@BeginTime,OrderMoney=@OrderMoney where DelFlag=0 and OrderId=@OrderId";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@BeginTime", System.DateTime.Now), new SqlParameter("@OrderMoney", orderMoney), new SqlParameter("@OrderId", orderId));
        }

        /// <summary>
        /// 添加订单信息
        /// </summary>
        /// <param name="order"></param>
        /// <returns>刚刚插入订单的主键id</returns>
        public object AddOrderInfo(OrderInfo order)
        {
            string sql = "insert into OrderInfo (SubTime,Remark,OrderState,DelFlag,SubBy,BeginTime,OrderMoney,DisCount) values(@SubTime,@Remark,@OrderState,@DelFlag,@SubBy,@BeginTime,@OrderMoney,@DisCount);select @@identity";
            SqlParameter[] ps ={
                            new SqlParameter("@SubTime",order.SubTime),
                            new SqlParameter("@Remark",order.Remark),
                            new SqlParameter("@OrderState",order.OrderState),
                            new SqlParameter("@DelFlag",order.DelFlag),
                            new SqlParameter("@SubBy",order.SubBy),
                            new SqlParameter("@BeginTime",order.BeginTime),
                            new SqlParameter("@OrderMoney",order.OrderMoney),
                            new SqlParameter("@DisCount",order.DisCount),
                            };
            return SqlHelper.ExecuteScalar(sql, ps);

        }

        /// <summary>
        /// 根据餐桌的id获取订单的id
        /// </summary>
        /// <param name="DeskId"></param>
        /// <returns></returns>
        public object GetOrderIdByDeskId(int deskId)
        {
            string sql = "select OrderInfo.OrderId from OrderInfo inner join R_Order_Desk on R_Order_Desk.OrderId=OrderInfo.OrderId where OrderInfo.DelFlag=0 and OrderInfo.OrderState=1 and R_Order_Desk.DeskId=" + deskId;
            return SqlHelper.ExecuteScalar(sql);
        }
    }
}
