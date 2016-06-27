using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpCater.Model
{
   public class RoomInfo
    {
        //RoomId, RoomName, RoomType, RoomMinMoney, RoomMaxNum, IsDefault, DelFlag, SubTime, SubBy

       public int RoomId { get; set; }
       public string RoomName { get; set; }
       public int RoomType { get; set; }
       public decimal RoomMinMoney { get; set; }
       public int RoomMaxNum { get; set; }
       public int IsDefault { get; set; }
       public int DelFlag { get; set; }
       public DateTime SubTime { get; set; }
       public int SubBy { get; set; }
    }
}
