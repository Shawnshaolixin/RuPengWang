using RpCater.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace RpCater.DAL
{
    public class ProductInfoDAL
    {
        //新增
        public int AddProductInfo(ProductInfo pro)
        {
            string sql = "insert into ProductInfo( CId,ProName, ProCost, ProSpell, ProPrice, ProUnit, Remark, DelFlag, SubTime, ProStock, ProNum, SubBy) values ( @CId,@ProName, @ProCost, @ProSpell, @ProPrice, @ProUnit, @Remark, @DelFlag, @SubTime, @ProStock, @ProNum, @SubBy)";
            return AddOrUpdateProductInfo(sql, pro, 1);
        }
        //修改
        public int UpdateProductInfo(ProductInfo pro)
        {
            string sql = "update ProductInfo set CId=@CId, ProName=@ProName, ProCost=@ProCost, ProSpell=@ProSpell, ProPrice=@ProPrice, ProUnit=@ProUnit, Remark=@Remark, ProStock=@ProStock, ProNum=@ProNum where ProId=@ProId";
            return AddOrUpdateProductInfo(sql, pro, 2);
        }
        /// <summary>
        /// 新增或者修改商品
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pro"></param>
        /// <param name="temp"></param>
        /// <returns></returns>
        public int AddOrUpdateProductInfo(string sql, ProductInfo pro, int temp)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            SqlParameter[] ps = { 
                                new SqlParameter ("@ProName",pro.ProName),
                                new SqlParameter ("@ProCost",pro.ProCost),
                                new SqlParameter ("@ProSpell",pro.ProSpell),
                                new SqlParameter ("@ProPrice",pro.ProPrice),
                                new SqlParameter ("@ProUnit",pro.ProUnit),
                                new SqlParameter ("@Remark",pro.Remark),
                    new SqlParameter ("@CId",pro.CId),
                                new SqlParameter ("@ProStock",pro.ProStock),
                                new SqlParameter ("@ProNum",pro.ProNum)
                          
                                };
            list.AddRange(ps);
            if (temp == 1)//新增
            {
                list.Add(new SqlParameter("@DelFlag", pro.DelFlag));
                list.Add(new SqlParameter("@SubTime", pro.SubTime));
                list.Add(new SqlParameter("@SubBy", pro.SubBy));
            }
            else if (temp == 2)//修改
            {
                list.Add(new SqlParameter("@ProId", pro.ProId));
            }
            return SqlHelper.ExecuteNonQuery(sql, list.ToArray());
        }
        /// <summary>
        /// 根据删除标记获取所有产品信息
        /// </summary>
        /// <param name="delFlag"></param>
        /// <returns>所有产品信息</returns>
        public List<ProductInfo> GetAllProductInfoByFlag(int delFlag)
        {
            string sql = "select * from ProductInfo where delflag=" + delFlag;
            List<ProductInfo> list = new List<ProductInfo>();
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
        /// 根据拼音或者编号模糊搜索
        /// </summary>
        /// <param name="name">1拼音 2编号</param>
        /// <returns></returns>
        public List<ProductInfo> GetProductByProSpellOrProNum(int temp, string name)
        {
            string sql = "select * from ProductInfo where delflag=0";
            if (temp == 1)
            {
                sql += " and prospell like @name";
            }
            else if (temp==2)
            {
                sql += " and Pronum like @name";
            }
            DataTable dt = SqlHelper.ExecuteTable(sql, new SqlParameter("@name", "%" + name + "%"));
            List<ProductInfo> list = new List<ProductInfo>();
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
        /// 根据id删除商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int SoftDeleteProductInfoById(int id)
        {
            string sql = "update ProductInfo set DelFlag=1 where ProId=" + id;
            return SqlHelper.ExecuteNonQuery(sql);

        }
        /// <summary>
        /// 根据类别id查看商品总条数
        /// </summary>
        /// <param name="cId"></param>
        /// <returns></returns>
        public object GetProCountByCId(int cId)
        {
            string sql = "select count(*) from ProductInfo where DelFlag=0 and CId=" + cId;
            return SqlHelper.ExecuteScalar(sql);
        }
        /// <summary>
        /// 根据列表id获取对应产品
        /// </summary>
        /// <param name="cId"></param>
        /// <returns></returns>
        public List<ProductInfo> GetProductInfoByCId(int cId)
        {
            string sql = "select * from ProductInfo where CId=" + cId;
            List<ProductInfo> list = new List<ProductInfo>();
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

        private ProductInfo RowToModel(DataRow dr)
        {
            ProductInfo pro = new ProductInfo();
            pro.CId = Convert.ToInt32(dr["CId"]);
            pro.DelFlag = Convert.ToInt32(dr["DelFlag"]);
            pro.ProCost = Convert.ToDecimal(dr["ProCost"]);
            pro.ProId = Convert.ToInt32(dr["ProId"]);
            pro.ProName = dr["ProName"].ToString();
            pro.ProNum = Convert.ToInt32(dr["ProNum"]);
            pro.ProPrice = Convert.ToDecimal(dr["ProPrice"]);
            pro.ProSpell = dr["ProSpell"].ToString();
            pro.ProStock = Convert.ToInt32(dr["ProStock"]);
            pro.ProUnit = dr["ProUnit"].ToString();
            pro.Remark = dr["Remark"].ToString();
            pro.SubBy = Convert.ToInt32(dr["SubBy"]);
            pro.SubTime = Convert.ToDateTime(dr["SubTime"]);
            return pro;
        }
    }
}
