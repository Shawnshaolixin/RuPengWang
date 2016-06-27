using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpCater.Model
{
    public class MemberInfo
    {
        //MemberId, MemMobilePhone, MemAddress, MemType, MemNum, MemGender, MemDiscount
        //, MemMoney, DelFlag, SubTime, MemIntegral, MemEndTime, MemBirthday
        public int MemberId { get; set; }
        public string MemMobilePhone { get; set; }
        public string MemAddress { get; set; }
        public int MemType { get; set; }
        public string MemNum { get; set; }
        public string MemGender { get; set; }
        public double MemDiscount { get; set; }
        public double MemMoney { get; set; }
        public int DelFlag { get; set; }
        public DateTime SubTime { get; set; }
        public int MemIntegral { get; set; }
        public DateTime MemEndTime { get; set; }
        public DateTime MemBirthday { get; set; }
        public string MemName { get; set; }
    }
}
