using RpCater.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpCater.DAL;
namespace RpCater.BLL
{
   public class MemberTypeBLL
    {
       MemberTypeDAL dal = new MemberTypeDAL();
            /// <summary>
        /// 根据删除标记获取会员类型
        /// </summary>
        /// <param name="delFlag">0--未删除 ，1---已删除</param>
        /// <returns></returns>
       public List<MemberType> GetAllMemberTypeByDelFlag(int delFlag)
       {
           return dal.GetAllMemberTypeByDelFlag(delFlag);
       }
    }
}
