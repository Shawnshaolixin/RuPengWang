using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpCater.Model
{
    public class DeskInfo
    {
        //DeskId, RoomId, DeskName, DeskRemark, DeskRegion, DeskState, DelFlag, SubTime, SubBy
        public int DeskId { get; set; }
        public int RoomId { get; set; }
        public string DeskRemark { get; set; }
        public int DeskState { get; set; }
        public int DelFlag { get; set; }
        public DateTime SubTime { get; set; }
        public int SubBy { get; set; }
        public string DeskName { get; set; }
        public string DeskRegion { get; set; }
    }
}
