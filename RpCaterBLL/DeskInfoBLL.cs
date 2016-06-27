using RpCater.DAL;
using RpCater.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpCater.BLL
{
    public class DeskInfoBLL
    {
        DeskInfoDAL dal = new DeskInfoDAL();
        /// <summary>
        /// 根据删除标记获取所有餐桌信息
        /// </summary>
        /// <param name="delFlag"></param>
        /// <returns></returns>
        public List<DeskInfo> GetAllDeskInfoByDelFlag(int delFlag)
        {
            return dal.GetAllDeskInfoByDelFlag(delFlag);
        }
        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="deskId"></param>
        /// <returns></returns>
        public bool SoftDeleteDeskInfoById(int deskId)
        {
            return dal.SoftDeleteDeskInfoById(deskId) > 0;
        }
        /// <summary>
        /// 根据房间id获取餐桌数量
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public int GetDeskCountByRoomId(int roomId)
        {
            return (int)dal.GetDeskCountByRoomId(roomId);
        }

        /// <summary>
        /// 根据房间的id查询该房间下所有的餐桌
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public List<DeskInfo> GetAllDeskInfoByRoomId(int roomId)
        {
            return dal.GetAllDeskInfoByRoomId(roomId);
        }

        /// <summary>
        /// 改变餐桌的状态
        /// </summary>
        /// <param name="deskid">餐桌id</param>
        /// <param name="state">0-未启用，1正在使用</param>
        /// <returns></returns>
        public bool UpdateDeskInfoStateByDeskId(int deskid, int state)
        {
            return dal.UpdateDeskInfoStateByDeskId(deskid, state) > 0;
        }
        /// <summary>
        /// 新增或者删除
        /// </summary>
        /// <param name="deskInfo"></param>
        /// <param name="sql"></param>
        /// <param name="temp"></param>
        /// <returns></returns>
        public bool AddOrUpdateDeskInfo(DeskInfo deskInfo, int temp)
        {
            if (temp == 1)
            {
                return dal.AddDeskInfo(deskInfo) > 0;
            }
            else if (temp == 2)
            {
                return dal.UpdateDeskInfo(deskInfo) > 0;
            }
            return false;
        }
    }
}