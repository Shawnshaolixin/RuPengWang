using RpCater.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpCater.DAL
{
    public class R_Order_ProductDAL
    {
        /// <summary>
        /// 添加订单产品中间表信息
        /// </summary>
        /// <param name="rop"></param>
        /// <returns></returns>
        public int AddR_Order_Product(R_Order_Product rop)
        {
            string sql = "insert into R_Order_Product (OrderId, ProId, DelFlag, SubTime, UnitCount) values (@OrderId, @ProId, @DelFlag, @SubTime, @UnitCount)";
            SqlParameter[] ps = { 
                                new SqlParameter("@OrderId",rop.OrderId),
                                 new SqlParameter("@ProId",rop.ProId),
                                  new SqlParameter("@DelFlag",rop.DelFlag),
                                   new SqlParameter("@SubTime",rop.SubTime),
                                    new SqlParameter("@UnitCount",rop.UnitCount)
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        /// <summary>
        /// 根据订单id获取该订单下面的所有商品
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<R_Order_Product> GetProductByOrderId(int orderId)
        {
            string sql = "select ROrderProId,ProName,ProPrice,UnitCount,ProUnit,CName,R_Order_Product.SubTime from R_Order_Product inner join ProductInfo on ProductInfo.proid=R_Order_Product.proid inner join CategoryInfo on CategoryInfo.cid= ProductInfo.cid where R_Order_Product.DelFlag=0 and orderid=" + orderId;
            List<R_Order_Product> list = new List<R_Order_Product>();
            DataTable dt = SqlHelper.ExecuteTable(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToR_Order_Product(dr));
                }
            }
            return list;
        }
        /// <summary>
        /// 更新订单菜单中间表状态
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public int UpdateR_Order_ProductByOrderId(int orderId)
        {
            string sql = "update R_Order_Product set DelFlag=1 where OrderId=" + orderId;
            return SqlHelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 删除订单下的产品
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public int SoftDeleteR_Order_ProByRpoId(int RpoId)
        {
            string sql = "update R_Order_Product set delflag=1 where ROrderProId=" + RpoId;
            return SqlHelper.ExecuteNonQuery(sql);
        }

        private R_Order_Product RowToR_Order_Product(DataRow dr)
        {
            R_Order_Product rop = new R_Order_Product();
            rop.CName = dr["CName"].ToString();
            rop.ROrderProId = Convert.ToInt32(dr["ROrderProId"]);
            rop.ProName = dr["ProName"].ToString();
            rop.ProPrice = Convert.ToDouble(dr["ProPrice"]);//单价
            rop.UnitCount = Convert.ToInt32(dr["UnitCount"]);//数量
            rop.ProMoney = rop.ProPrice * rop.UnitCount;
            rop.SubTime = Convert.ToDateTime(dr["SubTime"]);
            rop.ProUnit = dr["ProUnit"].ToString();
            return rop;
        }
    }
}
