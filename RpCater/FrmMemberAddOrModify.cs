using RpCater.BLL;
using RpCater.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RpCater
{
    public partial class FrmMemberAddOrModify : Form
    {
        private FrmMemberAddOrModify(MemberInfo memberInfo)
        {

            InitializeComponent();
            LoadMemberType(0);
            if (memberInfo == null)
            {
                //新增
                //随机生成编号
                txtIntger.Text = "0";
                Random rd = new Random();
                int num = rd.Next(100, 500);
                string strDate = DateTime.Now.ToString("yyMMddHHmmss");
                txtNum.Text = strDate + num;
            }
            else
            {
                //修改
                txtAddress.Text = memberInfo.MemAddress;
                txtDiscount.Text = memberInfo.MemDiscount.ToString();
                txtIntger.Text = memberInfo.MemIntegral.ToString();
                txtMoney.Text = memberInfo.MemMoney.ToString();
                txtName.Text = memberInfo.MemName.ToString();
                txtNum.Text = memberInfo.MemNum.ToString();//编号
                txtPhone.Text = memberInfo.MemMobilePhone.ToString();
                labId.Text =memberInfo.MemberId.ToString();
                //会员类型是个坑
                cmbType.SelectedIndex = memberInfo.MemType;
                dtpSubTime.Value = memberInfo.SubTime;
                dtpEndTime.Value = memberInfo.MemEndTime;
                dtpBirthday.Value = memberInfo.MemBirthday;

                rdoMan.Checked = memberInfo.MemGender == "男" ? true : false;
                rdoWomen.Checked = memberInfo.MemGender == "女" ? true : false;
            }
        }
    
        private static int Temp { get; set; }
        private static FrmMemberAddOrModify _instance;
        public static FrmMemberAddOrModify Single(int temp, MemberInfo memberinfo)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new FrmMemberAddOrModify(memberinfo);
                Temp = temp;
            }
            return _instance;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CheckEmpty())
            {
                MemberInfo member = new MemberInfo();
                member.MemAddress = txtAddress.Text;
                member.MemBirthday = dtpBirthday.Value;
                member.MemDiscount =Convert.ToInt32( txtDiscount.Text);
                member.MemEndTime = dtpEndTime.Value;
                member.MemGender = rdoMan.Checked ? "男" : "女";
                member.MemIntegral = Convert.ToInt32(txtIntger.Text);
                member.MemMobilePhone = txtPhone.Text;
                member.MemMoney = Convert.ToDouble(txtMoney.Text);
                member.MemName = txtName.Text;
                member.MemNum = txtNum.Text;
                member.MemType = Convert.ToInt32(cmbType.SelectedIndex);
                member.SubTime = dtpSubTime.Value;
                if (Temp == 1)
                {
                    member.DelFlag = 0;
                    member.MemIntegral = 0;
                    //添加
                }
                else if (Temp == 2)
                {
                    //修改
                    member.MemberId = Convert.ToInt32(labId.Text);
                }
                MemberInfoBLL bll = new MemberInfoBLL();
              string msg=  bll.AddOrUpdateMemberInfo(member, Temp) ? "操作成功" : "操作失败";
              msgAddOrModify.MsgDivShow(msg,1,Bind);
             
            }

        }
        private void Bind()
        { 
         this.Close();
        }
        /// <summary>
        /// 非空判断
        /// </summary>
        /// <returns></returns>
        private bool CheckEmpty()
        {
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                msgAddOrModify.MsgDivShow("地址不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtDiscount.Text))
            {
                msgAddOrModify.MsgDivShow("折扣不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtIntger.Text))
            {
                msgAddOrModify.MsgDivShow("积分不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtMoney.Text))
            {
                msgAddOrModify.MsgDivShow("金额不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                msgAddOrModify.MsgDivShow("名字不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtNum.Text))
            {
                msgAddOrModify.MsgDivShow("编号不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                msgAddOrModify.MsgDivShow("电话不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(dtpEndTime.Value.ToString()))
            {
                msgAddOrModify.MsgDivShow("截止日期不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(dtpBirthday.Value.ToString()))
            {
                msgAddOrModify.MsgDivShow("生日不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(dtpSubTime.Value.ToString()))
            {
                msgAddOrModify.MsgDivShow("注册时间不能为空", 1);
                return false;
            }
            if (dtpSubTime.Value > dtpEndTime.Value)
            {
                msgAddOrModify.MsgDivShow("注册时间不能大于到期时间", 1);
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void LoadMemberType(int delFlag)
        {
            MemberTypeBLL mtbll = new MemberTypeBLL();
            List<MemberType> list = new List<MemberType>();
            list = mtbll.GetAllMemberTypeByDelFlag(delFlag);
            list.Insert(0, new MemberType() { MemTypeName = "请选择", MemType = -1 });
            cmbType.DataSource = list;
            cmbType.DisplayMember = "MemTypeName";
            cmbType.ValueMember = "MemType";


        }
    }
}
