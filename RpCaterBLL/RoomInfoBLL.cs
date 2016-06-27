using RpCater.DAL;
using RpCater.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpCater.BLL
{
    public class RoomInfoBLL
    {
        RoomInfoDAL dal = new RoomInfoDAL();
        /// <summary>
        /// 根据删除标记获取所有房间信息
        /// </summary>
        /// <param name="delFlag">删除标记 0未删除  1已删除</param>
        /// <returns>房间信息列表</returns>
        public List<RoomInfo> GetAllRoomInfoByDelFlag(int delFlag)
        {
            return dal.GetAllRoomInfoByDelFlag(delFlag);
        }
        /// <summary>
        /// 删除房间信息根据房间id
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public bool SoftDeleteRoomInfoByRoomId(int roomId)
        {
            return dal.SoftDeleteRoomInfoByRoomId(roomId) > 0;
        }
        public bool AddOrUpdateRoomInfo(RoomInfo roomInfo, int temp)
        {
            if (temp == 1)
            {
                return dal.AddRoomInfo(roomInfo) > 0;
            }
            else if (temp == 2)
            {
                return dal.UpdateRoomInfo(roomInfo) > 0;
            }
            return false;
        }
    }
}
