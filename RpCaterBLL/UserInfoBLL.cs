using RpCater.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpCater.DAL;
using System.Security.Cryptography;
namespace RpCater.BLL
{
    public class UserInfoBLL
    {
        UserInfoDAL dal = new UserInfoDAL();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="pwd"></param>
        /// <returns>状态信息</returns>
        public LoginState GetUserInfoByLoginName(string loginName, string pwd)
        {
            UserInfo userInfo = null;
            userInfo = dal.GetUserInfoByLoginName(loginName);
            if (userInfo == null)
            {
                return LoginState.LoginNameNotFound;
            }
            pwd = GetMd5(pwd);
            if (userInfo.Pwd != pwd)
            {
                return LoginState.PasswordError;
            }
            return LoginState.OK;
        }
        /// <summary>
        /// 获取md5值
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        private string GetMd5(string pwd)
        {
            string s = "";
            byte[] byteValues = System.Text.Encoding.UTF8.GetBytes(pwd);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] byteDatas = md5.ComputeHash(byteValues);
            for (int i = 0; i < byteDatas.Length; i++)
            {
                s += byteDatas[i].ToString("x2");
            }
            return s;
        }
    }
}
