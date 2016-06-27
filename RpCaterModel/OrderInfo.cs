using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpCater.Model
{
    public class OrderInfo
    {
        public int OrderId { get; set; }
        public DateTime SubTime { get; set; }
        public string Remark { get; set; }
        public int OrderState { get; set; }
        public int OrderMemberId { get; set; }
        public int DelFlag { get; set; }
        public int SubBy { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public double OrderMoney { get; set; }
        public double DisCount { get; set; }
    }
}
