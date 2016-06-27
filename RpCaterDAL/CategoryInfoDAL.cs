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
    public class CategoryInfoDAL
    {
        /// <summary>
        /// 根据删除标识获取所有类别信息
        /// </summary>
        /// <param name="delFlag">删除标识</param>
        /// <returns>类别信息</returns>
        public List<CategoryInfo> GetAllCategoryInfoByDelFlag(int delFlag)
        {
            string sql = "select * from CategoryInfo where delflag=" + delFlag;
            List<CategoryInfo> list = new List<CategoryInfo>();
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
        /// 增加
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int AddCategoryInfo(CategoryInfo info)
        {
            string sql = "insert into CategoryInfo ( CName, CNum, CRemark, DelFlag, SubTime, SubBy) values (@CName, @CNum, @CRemark, @DelFlag, @SubTime, @SubBy)";
            return AddOrUpdateCategoryInfo(sql, 1, info);

        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int UpdateCategoryInfo(CategoryInfo info)
        {
            string sql = "update CategoryInfo set CName=@CName, CNum=@CNum,CRemark=@CRemark where CId=@CId";
            return AddOrUpdateCategoryInfo(sql, 2, info);
        }
        /// <summary>
        /// 增加和修改公用
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="temp"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public int AddOrUpdateCategoryInfo(string sql, int temp, CategoryInfo info)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            SqlParameter[] ps = { new SqlParameter("@CName", info.CName),
                               new SqlParameter("@CNum", info.CNum),
                               new SqlParameter("@CRemark", info.CRemark),
                               };
            list.AddRange(ps);
            if (temp == 1)//新增
            {
                list.Add(new SqlParameter { ParameterName = "@DelFlag", Value = info.DelFlag });
                list.Add(new SqlParameter("@SubTime", info.SubTime));
                list.Add(new SqlParameter("@SubBy", info.SubBy));
            }
            else if (temp == 2)//修改
            {
                list.Add(new SqlParameter("@CId", info.CId));
            }
            return SqlHelper.ExecuteNonQuery(sql, list.ToArray());
        }

        /// <summary>
        /// 根据id删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int SoftDeleteCategoryInfo(int id) {
            string sql = "update CategoryInfo set delflag=1 where cid="+id;
            return SqlHelper.ExecuteNonQuery(sql);
        }
        private CategoryInfo RowToModel(DataRow dr)
        {
            CategoryInfo cg = new CategoryInfo();
            cg.CId = Convert.ToInt32(dr["CId"]);
            cg.CName = dr["CName"].ToString();
            cg.CNum = Convert.ToInt32(dr["CNum"]);
            cg.CRemark = dr["CRemark"].ToString();
            cg.DelFlag = Convert.ToInt32(dr["DelFlag"]);
            cg.SubBy = Convert.ToInt32(dr["SubBy"]);
            cg.SubTime = Convert.ToDateTime(dr["SubTime"]);
            return cg;

        }
    }
}
