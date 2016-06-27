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
    public class RoomInfoDAL
    {
        /// <summary>
        /// 根据删除标记获取所有房间信息
        /// </summary>
        /// <param name="delFlag">删除标记 0未删除  1已删除</param>
        /// <returns>房间信息列表</returns>
        public List<RoomInfo> GetAllRoomInfoByDelFlag(int delFlag)
        {
            string sql = "select * from roominfo where delflag=" + delFlag;
            List<RoomInfo> list = new List<RoomInfo>();
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


        public int AddRoomInfo(RoomInfo roomInfo)
        {
            string sql = "insert into RoomInfo (RoomName, RoomType, RoomMinMoney, RoomMaxNum, IsDefault, DelFlag, SubTime, SubBy) values (@RoomName, @RoomType, @RoomMinMoney, @RoomMaxNum, @IsDefault, @DelFlag, @SubTime, @SubBy)";
            return AddOrUpdateRoomInfo(roomInfo, sql, 1);
        }

        public int UpdateRoomInfo(RoomInfo roomInfo)
        {
            string sql = "update RoomInfo set RoomName=@RoomName, RoomType=@RoomType, RoomMinMoney=@RoomMinMoney, RoomMaxNum=@RoomMaxNum, IsDefault=@IsDefault where RoomId=@RoomId";
            return AddOrUpdateRoomInfo(roomInfo, sql, 2);
        }

        /// <summary>
        /// 删除房间信息根据房间id
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public int SoftDeleteRoomInfoByRoomId(int roomId)
        {
            string sql = "update roominfo set delflag=1 where roomid=" + roomId;
            return SqlHelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 新增或者删除
        /// </summary>
        /// <param name="roomInfo"></param>
        /// <param name="sql"></param>
        /// <param name="temp"></param>
        /// <returns></returns>
        public int AddOrUpdateRoomInfo(RoomInfo roomInfo, string sql, int temp)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            SqlParameter[] ps = {
                               new SqlParameter("RoomName",roomInfo.RoomName),
                               new SqlParameter("RoomType",roomInfo.RoomType),
                               new SqlParameter("RoomMinMoney",roomInfo.RoomMinMoney),
                               new SqlParameter("RoomMaxNum",roomInfo.RoomMaxNum),
                               new SqlParameter("IsDefault",roomInfo.IsDefault)
                               };
            list.AddRange(ps);
            if (temp == 1)//新增
            {
                list.Add(new SqlParameter("DelFlag", roomInfo.DelFlag));
                list.Add(new SqlParameter("SubTime", roomInfo.SubTime));
                list.Add(new SqlParameter("SubBy", roomInfo.SubBy));
            }
            else if (temp == 2)//修改
            {
                list.Add(new SqlParameter("RoomId", roomInfo.RoomId));
            }
            return SqlHelper.ExecuteNonQuery(sql, list.ToArray());
        }
        /// <summary>
        /// 关系转对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private RoomInfo RowToModel(DataRow dr)
        {
            RoomInfo r = new RoomInfo();
            r.DelFlag = Convert.ToInt32(dr["DelFlag"]);
            r.IsDefault = Convert.ToInt32(dr["IsDefault"]);
            r.RoomId = Convert.ToInt32(dr["RoomId"]);
            r.RoomMaxNum = Convert.ToInt32(dr["RoomMaxNum"]);
            r.RoomMinMoney = Convert.ToDecimal(dr["RoomMinMoney"]);
            r.RoomName = dr["RoomName"].ToString();
            r.RoomType = Convert.ToInt32(dr["RoomType"]);
            r.SubBy = Convert.ToInt32(dr["SubBy"]); ;
            r.SubTime = Convert.ToDateTime(dr["SubTime"]);
            return r;
        }
    }
}
