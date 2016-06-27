using RpCater.DAL;
using RpCater.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpCater.BLL
{
    public class R_Order_DeskBLL
    {
        R_Order_DeskDAL dal = new R_Order_DeskDAL();
        /// <summary>
        /// 添加餐桌订单中间表信息
        /// </summary>
        /// <param name="rod"></param>
        /// <returns></returns>
        public bool AddR_Order_Desk(R_Order_Desk rod)
        {
            return dal.AddR_Order_Desk(rod)>0;
        }
    }
}
