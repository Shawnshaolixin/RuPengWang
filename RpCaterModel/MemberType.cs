using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpCater.Model
{
    public class MemberType
    {

        //MemType, MemTypeName, MemTypeDesc, DelFlag, SubBy
        public int MemType { get; set; }
        public string MemTypeName { get; set; }
        public string MemTypeDesc { get; set; }
        public int DelFlag { get; set; }
        public int SubBy { get; set; }
    }
}
