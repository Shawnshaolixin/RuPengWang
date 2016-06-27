using RpCater.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpCater.DAL
{
    public class DeskInfoDAL
    {
        /// <summary>
        /// 根据删除标记获取所有餐桌信息
        /// </summary>
        /// <param name="delFlag"></param>
        /// <returns></returns>
        public List<DeskInfo> GetAllDeskInfoByDelFlag(int delFlag)
        {
            string sql = "select * from deskInfo where delflag=" + delFlag;
            List<DeskInfo> list = new List<DeskInfo>();
            DataTable dt = SqlHelper.ExecuteTable(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToModel(dr));
                }
            }
            return list;
        }
        public int AddDeskInfo(DeskInfo deskInfo)
        {
            string sql = "insert into DeskInfo (RoomId, DeskName, DeskRemark, DeskRegion, DeskState, DelFlag, SubTime, SubBy) values (@RoomId, @DeskName, @DeskRemark, @DeskRegion, @DeskState, @DelFlag, @SubTime, @SubBy)";
            return AddOrUpdateDeskInfo(deskInfo, sql, 1);
        }

        public int UpdateDeskInfo(DeskInfo deskInfo)
        {
            string sql = "update DeskInfo set RoomId=@RoomId, DeskName=@DeskName, DeskRemark=@DeskRemark, DeskRegion=@DeskRegion, DeskState=@DeskState where DeskId=@DeskId";
            return AddOrUpdateDeskInfo(deskInfo, sql, 2);
        }
        /// <summary>
        /// 新增或者删除
        /// </summary>
        /// <param name="deskInfo"></param>
        /// <param name="sql"></param>
        /// <param name="temp"></param>
        /// <returns></returns>
        public int AddOrUpdateDeskInfo(DeskInfo deskInfo, string sql, int temp)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            SqlParameter[] ps = {
                               new SqlParameter("RoomId",deskInfo.RoomId),
                               new SqlParameter("DeskName",deskInfo.DeskName),
                               new SqlParameter("DeskRemark",deskInfo.DeskRemark),
                               new SqlParameter("DeskRegion",deskInfo.DeskRegion),
                               new SqlParameter("DeskState",deskInfo.DeskState)
                               };
            list.AddRange(ps);
            if (temp == 1)//新增
            {
                list.Add(new SqlParameter("DelFlag", deskInfo.DelFlag));
                list.Add(new SqlParameter("SubTime", deskInfo.SubTime));
                list.Add(new SqlParameter("SubBy", deskInfo.SubBy));
            }
            else if (temp == 2)//修改
            {
                list.Add(new SqlParameter("DeskId", deskInfo.DeskId));
            }
            return SqlHelper.ExecuteNonQuery(sql, list.ToArray());
        }

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="deskId"></param>
        /// <returns></returns>
        public int SoftDeleteDeskInfoById(int deskId)
        {
            string sql = "update deskinfo set delflag=1 where deskid=" + deskId;
            return SqlHelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 根据房间id获取餐桌数量
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public object GetDeskCountByRoomId(int roomId)
        {
            string sql = "select count(*) from deskInfo where delflag=0 and roomid=" + roomId;

            return SqlHelper.ExecuteScalar(sql);
        }
        /// <summary>
        /// 根据房间的id查询该房间下所有的餐桌
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public List<DeskInfo> GetAllDeskInfoByRoomId(int roomId)
        {
            string sql = "select * from deskInfo where delflag=0 and roomid=" + roomId;
            List<DeskInfo> list = new List<DeskInfo>();
            DataTable dt = SqlHelper.ExecuteTable(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToModel(dr));
                }
            }
            return list;
        }
        /// <summary>
        /// 改变餐桌的状态
        /// </summary>
        /// <param name="deskid"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public int UpdateDeskInfoStateByDeskId(int deskid, int state)
        {
            string sql = "update deskInfo set deskstate=@deskstate where delflag=0 and deskId=@deskid";
            SqlParameter[] ps = { new SqlParameter("@deskstate", state), new SqlParameter("@deskId", deskid) };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        /// <summary>
        /// 关系转对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private DeskInfo RowToModel(DataRow dr)
        {
            DeskInfo d = new DeskInfo();
            d.DelFlag = Convert.ToInt32(dr["DelFlag"]);
            d.DeskId = Convert.ToInt32(dr["DeskId"]);
            d.DeskRemark = dr["DeskRemark"].ToString();
            d.DeskState = Convert.ToInt32(dr["DeskState"]);
            d.RoomId = Convert.ToInt32(dr["RoomId"]);
            d.SubBy = Convert.ToInt32(dr["SubBy"]);
            d.SubTime = Convert.ToDateTime(dr["SubTime"]);
            d.DeskName = dr["DeskName"].ToString();
            d.DeskRegion = dr["DeskRegion"].ToString();
            return d;
        }
    }
}
