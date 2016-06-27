using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpCater.Model;
using System.Data;
using System.Data.SqlClient;
namespace RpCater.DAL
{
    public class MemberTypeDAL
    {
        /// <summary>
        /// 根据删除标记获取会员类型
        /// </summary>
        /// <param name="delFlag">0--未删除 ，1---已删除</param>
        /// <returns></returns>
        public List<MemberType> GetAllMemberTypeByDelFlag(int delFlag)
        {
            string sql = "select * from MemberType where DelFlag=" + delFlag;
            List<MemberType> list = new List<MemberType>();
            DataTable dt = SqlHelper.ExecuteTable(sql);
            if (dt.Rows.Count>0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToMemberType(dr));
                }
            }
            return list;
        }

        private MemberType RowToMemberType(DataRow dr)
        {
            MemberType mt = new MemberType();
            mt.DelFlag = Convert.ToInt32(dr["DelFlag"]);
            mt.MemType = Convert.ToInt32(dr["MemType"]);
            mt.MemTypeDesc = dr["MemTypeDesc"].ToString();
            mt.MemTypeName = dr["MemTypeName"].ToString();
            mt.SubBy = Convert.ToInt32(dr["SubBy"]);
            return mt; 
        }
    }
}
