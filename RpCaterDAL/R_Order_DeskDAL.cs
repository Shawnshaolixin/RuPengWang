using RpCater.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace RpCater.DAL
{
    public class R_Order_DeskDAL
    {
        /// <summary>
        /// 添加餐桌订单中间表信息
        /// </summary>
        /// <param name="rod"></param>
        /// <returns></returns>
        public int AddR_Order_Desk(R_Order_Desk rod)
        {
            string sql = "insert into R_Order_Desk(OrderId,DeskId)values(@OrderId,@DeskId)";
            SqlParameter[] ps = { new SqlParameter("@OrderId", rod.OrderId), new SqlParameter("@DeskId", rod.DeskId) };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
    }
}
