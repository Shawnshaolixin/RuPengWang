using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RpCater.Model;
namespace RpCater.DAL
{
    public class MemberInfoDAL
    {


        public void AddMemberInfo(List<MemberInfo> list)
        {

            using (SqlConnection conn = new SqlConnection(SqlHelper.conStr))
            {
                conn.Open();
                SqlTransaction sqlTran = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        MemberInfo memberinfo = list[i];
                        string sql = "insert into MemberInfo(MemMobilePhone, MemAddress, MemType, MemNum, MemGender, MemDiscount, MemMoney, DelFlag, SubTime, MemIntegral, MemEndTime, MemBirthday, MemName) values (@MemMobilePhone, @MemAddress, @MemType, @MemNum, @MemGender, @MemDiscount, @MemMoney, @DelFlag, @SubTime, @MemIntegral, @MemEndTime, @MemBirthday, @MemName)";
                        SqlParameter[] ps = {  
                new SqlParameter("@MemMobilePhone",memberinfo.MemMobilePhone),
                new SqlParameter("@MemAddress",memberinfo.MemAddress),
                 new SqlParameter("@MemName",memberinfo.MemName),
                  new SqlParameter("@MemNum",memberinfo.MemNum),
                    new SqlParameter("@MemGender",memberinfo.MemGender),
                new SqlParameter("@MemDiscount",memberinfo.MemDiscount),
                 new SqlParameter("@MemMoney",memberinfo.MemMoney),
              new SqlParameter("@MemIntegral",memberinfo.MemIntegral),
            new SqlParameter("@MemEndTime",memberinfo.MemEndTime),
             new SqlParameter("@MemBirthday",memberinfo.MemBirthday),
          new SqlParameter("@MemType",memberinfo.MemType),
                                       new SqlParameter("@DelFlag", memberinfo.DelFlag),
           new SqlParameter("@SubTime", memberinfo.SubTime)
                };
                        SqlHelper.ExecuteNonQuery(conn, sqlTran, sql, ps);
                    }

                    sqlTran.Commit();
                }

                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    throw;
                }
            }
        }
        /// <summary>
        /// 根据会员id 更新会员金额
        /// </summary>
        /// <param name="memId"></param>
        /// <param name="memMoney"></param>
        /// <returns></returns>
        public int UpdateMoneyByMemId(int memId, double memMoney)
        {
            string sql = "update MemberInfo set MemMoney=@MemMoney where MemberId=@MemberId";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@MemMoney", memMoney), new SqlParameter("@MemberId", memId));
        }
        /// <summary>
        /// 根据删除标记获取所有会员信息
        /// </summary>
        /// <param name="Flag">删除标记</param>
        /// <returns>会员列表</returns>
        public List<MemberInfo> GetAllMemberInfoByDelFlag(int flag)
        {
            string sql = "select * from MemberInfo where delflag=" + flag;

            DataTable dt = SqlHelper.ExecuteTable(sql);
            List<MemberInfo> listMember = new List<MemberInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    listMember.Add(RowToMemberInfo(item));
                }
            }
            return listMember;
        }

        /// <summary>
        /// 根据姓名查找会员信息
        /// </summary>
        /// <param name="memName">姓名</param>
        /// <returns>会员列表</returns>
        public List<MemberInfo> GetMemberIinfoByName(string memName)
        {
            string sql = "select * from memberinfo where delflag=0 and memname like @memName";
            DataTable dt = SqlHelper.ExecuteTable(sql, new SqlParameter("@memName", "%" + memName + "%"));
            List<MemberInfo> listMember = new List<MemberInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    listMember.Add(RowToMemberInfo(item));
                }
            }
            return listMember;
        }
        /// <summary>
        /// 删除成员
        /// </summary>
        /// <param name="delFlag">删除标记</param>
        /// <param name="memId">成员id</param>
        /// <returns>受影响行数</returns>
        public int SoftDeleteMember(int delFlag, int memId)
        {
            string sql = "update  memberinfo set delFlag=@delFlag where  memberid=" + memId;
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@delFlag", delFlag));
        }

        /// <summary>
        /// 根据id获取会员信息
        /// </summary>
        /// <param name="memId">会员的id</param>
        /// <returns>会员信息</returns>
        public MemberInfo GetMemberInfoByMemId(int memId)
        {
            string sql = "select * from memberinfo where memberid=" + memId;
            DataTable dt = SqlHelper.ExecuteTable(sql);
            MemberInfo memberinfo = new MemberInfo();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    memberinfo = RowToMemberInfo(dt.Rows[0]);
                }
            }
            return memberinfo;
        }


        //新增
        public int AddMemberInfo(MemberInfo memberInfo)
        {
            string sql = "insert into MemberInfo(MemMobilePhone, MemAddress, MemType, MemNum, MemGender, MemDiscount, MemMoney, DelFlag, SubTime, MemIntegral, MemEndTime, MemBirthday, MemName) values (@MemMobilePhone, @MemAddress, @MemType, @MemNum, @MemGender, @MemDiscount, @MemMoney, @DelFlag, @SubTime, @MemIntegral, @MemEndTime, @MemBirthday, @MemName)";
            return AddOrUpdateMemberInfo(1, memberInfo, sql);
        }
        //修改
        public int UpdateMemberInfo(MemberInfo memberInfo)
        {
            string sql = "update MemberInfo set MemMobilePhone=@MemMobilePhone, MemAddress=@MemAddress, MemType=@MemType, MemNum=@MemNum, MemGender=@MemGender, MemDiscount=@MemDiscount, MemMoney=@MemMoney, MemIntegral=@MemIntegral, MemEndTime=@MemEndTime, MemBirthday=@MemBirthday, MemName=@MemName where MemberId=@MemberId";
            return AddOrUpdateMemberInfo(2, memberInfo, sql);
        }
        //新增或者修改公用的
        public int AddOrUpdateMemberInfo(int flag, MemberInfo memberinfo, string sql)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            SqlParameter[] ps = { 
            new SqlParameter("@MemMobilePhone",memberinfo.MemMobilePhone),
            new SqlParameter("@MemAddress",memberinfo.MemAddress),
          new SqlParameter("@MemName",memberinfo.MemName),
          new SqlParameter("@MemNum",memberinfo.MemNum),
            new SqlParameter("@MemGender",memberinfo.MemGender),
           new SqlParameter("@MemDiscount",memberinfo.MemDiscount),
         new SqlParameter("@MemMoney",memberinfo.MemMoney),
       new SqlParameter("@MemIntegral",memberinfo.MemIntegral),
            new SqlParameter("@MemEndTime",memberinfo.MemEndTime),
        new SqlParameter("@MemBirthday",memberinfo.MemBirthday),
          new SqlParameter("@MemType",memberinfo.MemType)
                                 };
            list.AddRange(ps);
            if (flag == 1)//新增
            {
                list.Add(new SqlParameter("@DelFlag", memberinfo.DelFlag));
                list.Add(new SqlParameter("@SubTime", memberinfo.SubTime));
            }
            else if (flag == 2)//修改
            {
                list.Add(new SqlParameter("@MemberId", memberinfo.MemberId));
            }

            return SqlHelper.ExecuteNonQuery(sql, list.ToArray());
        }
        private MemberInfo RowToMemberInfo(DataRow dr)
        {
            MemberInfo memberInfo = new MemberInfo();
            memberInfo.DelFlag = Convert.ToInt32(dr["DelFlag"]);
            memberInfo.MemAddress = dr["MemAddress"].ToString();
            memberInfo.MemberId = Convert.ToInt32(dr["MemberId"]);
            memberInfo.MemBirthday = Convert.ToDateTime(dr["MemBirthday"]);
            memberInfo.MemDiscount = Convert.ToDouble(dr["MemDiscount"]);
            memberInfo.MemEndTime = Convert.ToDateTime(dr["MemEndTime"]);
            memberInfo.MemGender = dr["MemGender"].ToString();
            memberInfo.MemIntegral = Convert.ToInt32(dr["MemIntegral"]);
            memberInfo.MemMobilePhone = dr["MemMobilePhone"].ToString();
            memberInfo.MemMoney = Convert.ToDouble(dr["MemMoney"]);
            memberInfo.MemNum = dr["MemNum"].ToString();
            memberInfo.MemType = Convert.ToInt32(dr["MemType"]);
            memberInfo.SubTime = Convert.ToDateTime(dr["SubTime"]);
            memberInfo.MemName = dr["MemName"].ToString();
            return memberInfo;
        }
    }
}
