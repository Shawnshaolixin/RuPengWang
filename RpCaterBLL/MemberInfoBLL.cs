using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpCater.DAL;
using RpCater.Model;
using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
namespace RpCater.BLL
{
    public class MemberInfoBLL
    {
        MemberInfoDAL dal = new MemberInfoDAL();
        /// <summary>
        /// 根据删除标记获取所有会员信息
        /// </summary>
        /// <param name="Flag">删除标记</param>
        /// <returns>会员列表</returns>
        public List<MemberInfo> GetAllMemberInfoByDelFlag(int flag)
        {

            return dal.GetAllMemberInfoByDelFlag(flag);
        }
        /// <summary>
        /// 根据姓名查找会员信息
        /// </summary>
        /// <param name="memName">姓名</param>
        /// <returns>会员列表</returns>
        public List<MemberInfo> GetMemberIinfoByName(string memName)
        {
            return dal.GetMemberIinfoByName(memName);
        }
        /// <summary>
        /// 删除成员
        /// </summary>
        /// <param name="delFlag">删除标记</param>
        /// <param name="memId">成员id</param>
        /// <returns>受影响行数</returns>
        public bool SoftDeleteMember(int delFlag, int memId)
        {
            return dal.SoftDeleteMember(delFlag, memId) > 0;
        }
        /// <summary>
        /// 根据id获取会员信息
        /// </summary>
        /// <param name="memId">会员的id</param>
        /// <returns>会员信息</returns>
        public MemberInfo GetMemberInfoByMemId(int memId)
        {
            return dal.GetMemberInfoByMemId(memId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberInfo">会员对象</param>
        /// <param name="flag">标识  1 新增 2修改</param>
        /// <returns>成功或者失败</returns>
        public bool AddOrUpdateMemberInfo(MemberInfo memberInfo, int flag)
        {
            if (flag == 1)
            {
                return dal.AddMemberInfo(memberInfo) > 0;
            }
            else if (flag == 2)
            {
                return dal.UpdateMemberInfo(memberInfo) > 0;
            }
            return false;
        }
        /// <summary>
        /// 根据会员id 更新会员金额
        /// </summary>
        /// <param name="memId"></param>
        /// <param name="memMoney"></param>
        /// <returns></returns>
        public bool UpdateMoneyByMemId(int memId, double memMoney)
        {

            return dal.UpdateMoneyByMemId(memId, memMoney) > 0;
        }
        /// <summary>
        /// Excel导出
        /// </summary>
        /// <param name="path"></param>
        public void ExcelWrite(string path)
        {
            //流
            using (FileStream fsWrite = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                //创建工作表07excel
                XSSFWorkbook work = new XSSFWorkbook();
                //03excel
                // HSSFWorkbook work = new HSSFWorkbook();
                //创建页
                ISheet sheet = work.CreateSheet("会员信息");

                //创建行
                List<MemberInfo> list = dal.GetAllMemberInfoByDelFlag(0);
                for (int i = 0; i < list.Count; i++)
                {
                    IRow row = sheet.CreateRow(i);

                    ICell cell1 = row.CreateCell(0, CellType.String);
                    cell1.SetCellValue(list[i].MemName);
                    ICell cell2 = row.CreateCell(1, CellType.Numeric);
                    cell2.SetCellValue(list[i].MemMoney);
                    ICell cell3 = row.CreateCell(2, CellType.String);
                    cell3.SetCellValue(list[i].MemMobilePhone);
                    ICell cell4 = row.CreateCell(3, CellType.String);
                    cell4.SetCellValue(list[i].MemGender);
                    ICell cell5 = row.CreateCell(4, CellType.String);
                    cell5.SetCellValue(list[i].MemNum);
                }
                work.Write(fsWrite);
            }

        }

        public void ExcelRead(string path)
        {
            //流
            using (FileStream fsRead = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                List<MemberInfo> list = new List<MemberInfo>();
                //工作表
                IWorkbook workBook = WorkbookFactory.Create(fsRead);
                //获取页
                ISheet sheet = workBook.GetSheetAt(0);
                //遍历该页中所有的行
                for (int i = 0; i <= sheet.LastRowNum; i++)
                {
                    MemberInfo member = new MemberInfo();
                    //获取行
                    IRow row = sheet.GetRow(i);
                    member.MemName = row.GetCell(1).StringCellValue;//名字
                    member.MemMobilePhone = row.GetCell(2).StringCellValue;//电话号码
                    member.MemAddress = row.GetCell(3).StringCellValue;//地址
                    member.MemType = Convert.ToInt32(row.GetCell(4).StringCellValue);//类型
                    member.MemNum = row.GetCell(5).StringCellValue;//编号
                    member.MemGender = row.GetCell(6).StringCellValue;//性别
                    member.MemDiscount = Convert.ToDouble(row.GetCell(7).StringCellValue);//折扣
                    member.MemMoney = Convert.ToDouble(row.GetCell(8).StringCellValue);//钱
                    member.DelFlag = Convert.ToInt32(row.GetCell(9).StringCellValue);//删除标识
                    member.SubTime = Convert.ToDateTime(row.GetCell(10).StringCellValue);//提交时间
                    member.MemIntegral = Convert.ToInt32(row.GetCell(11).StringCellValue);//积分
                    member.MemEndTime = Convert.ToDateTime(row.GetCell(12).StringCellValue);//结束时间
                    member.MemBirthday = Convert.ToDateTime(row.GetCell(13).StringCellValue);//生日
                    list.Add(member);
                    // //把excel文件的数据插入到数据库中 --


                }// end for
                //循环结束了====集合中好多个会员的对象==传到DAL中

                dal.AddMemberInfo(list);
            }// end using

        }
    }
}
