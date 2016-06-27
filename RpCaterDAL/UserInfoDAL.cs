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
    public class UserInfoDAL
    {
        /// <summary>
        /// 根据用户的登录名字，查询数据库
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <returns>登录的用户对象</returns>
        public UserInfo GetUserInfoByLoginName(string loginName)
        {
            string sql = "select * from userinfo where DelFlag=0 and LoginUserName=@LoginUserName";
            DataTable dt = SqlHelper.ExecuteTable(sql, new SqlParameter("@LoginUserName", loginName));
            UserInfo userInfo = null;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    userInfo = RowToUserInfo(dt.Rows[0]);
                }
            }
            return userInfo;
        }
        /// <summary>
        /// 关系转换对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private UserInfo RowToUserInfo(DataRow dr)
        {
            UserInfo userInfo = new UserInfo();
            userInfo.LoginUserName = dr["LoginUserName"].ToString();
            userInfo.Pwd = dr["Pwd"].ToString();
            userInfo.UserId = Convert.ToInt32(dr["UserId"]);
            userInfo.SubTime = Convert.ToDateTime(dr["SubTime"]);
            userInfo.LastLoginIP = dr["LastLoginIP"].ToString();
            userInfo.LastLoginTime = Convert.ToDateTime(dr["LastLoginTime"]);
            userInfo.DelFlag = Convert.ToInt32(dr["DelFlag"]);
            return userInfo;
        }
    }
}
