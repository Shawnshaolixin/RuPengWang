using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpCater.Model
{
   public class UserInfo
    {

        private int _userId;

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
       private string _loginUserName;

       public string LoginUserName
       {
           get { return _loginUserName; }
           set { _loginUserName = value; }
       }
       private string _pwd;

       public string Pwd
       {
           get { return _pwd; }
           set { _pwd = value; }
       }
       private int _delFlag;

       public int DelFlag
       {
           get { return _delFlag; }
           set { _delFlag = value; }
       }

       private string _lastLoginIP;

       public string LastLoginIP
       {
           get { return _lastLoginIP; }
           set { _lastLoginIP = value; }
       }
       private DateTime _lastLoginTime;

       public DateTime LastLoginTime
       {
           get { return _lastLoginTime; }
           set { _lastLoginTime = value; }
       }
       private DateTime _subTime;

       public DateTime SubTime
       {
           get { return _subTime; }
           set { _subTime = value; }
       }
    }
}
