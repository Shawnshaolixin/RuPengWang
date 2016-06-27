using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpCater.Model
{
    public class R_Order_Product
    {

        //ROrderProId, OrderId, ProId, DelFlag, SubTime, UnitCount
        //冗余属性
        // OrderId,ProName,ProPrice,UnitCount,ProUnit,CName,R_Order_Product.SubTime
        public string ProName { get; set; }
        public double ProPrice { get; set; }
        public string CName { get; set; }
        public double ProMoney { get; set; }
        public string ProUnit { get; set; }

        public int ROrderProId { get; set; }
        public int OrderId { get; set; }
        public int ProId { get; set; }
        public int DelFlag { get; set; }
        public DateTime SubTime { get; set; }
        public int UnitCount { get; set; }
    }
}
