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
    public partial class FrmMember : Form
    {
        MemberInfoBLL bll = new MemberInfoBLL();
        private FrmMember()
        {
            InitializeComponent();
        }
        private static FrmMember _instance;

        public static FrmMember Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FrmMember();
                }
                return _instance;
            }

        }

        private void FrmMember_Load(object sender, EventArgs e)
        {
            //窗体加载的时候
            LoadMemberInfoByDelFlag(0);
            cmbMember.SelectedIndex = 0;//默认请选择
        }

        private void LoadMemberInfoByDelFlag(int p)
        {
            //  MemberInfoBLL bll = new MemberInfoBLL();
            dgvMember.AutoGenerateColumns = false;//禁止自动生成列
            dgvMember.DataSource = bll.GetAllMemberInfoByDelFlag(p);
            dgvMember.ClearSelection();//清空默认选中第一行
        }

        private void cmbMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMemberInfoByDelFlag(cmbMember.SelectedIndex);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtSearch.Text.Trim()))
            //{
            //    msgs.MsgDivShow("不能为空",1);
            //}
            dgvMember.DataSource = bll.GetMemberIinfoByName(txtSearch.Text.Trim());
        }

        private void btnDeleteMember_Click(object sender, EventArgs e)
        {
            if (dgvMember.SelectedRows.Count <= 0)
            {
                msgs.MsgDivShow("请选择要删除的项", 1);
                return;
            }
            if (MessageBox.Show("真的要删除吗？", "删除会员", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                int index = cmbMember.SelectedIndex == 0 ? 1 : 2;
                int memId = ((MemberInfo)dgvMember.SelectedRows[0].DataBoundItem).MemberId;
                if (bll.SoftDeleteMember(index, memId))
                {
                    msgs.MsgDivShow("删除成功", 1);
                    LoadMemberInfoByDelFlag(cmbMember.SelectedIndex);
                }
                else
                {
                    msgs.MsgDivShow("删除失败", 1);
                }
            }
            else
            {
                msgs.MsgDivShow("您已取消删除", 1);
            }
            //获取id

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //新增 标识 1
            ShowFrmMemberAddOrModify(1, null);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvMember.SelectedRows.Count <= 0)
            {
                msgs.MsgDivShow("请选择要修改的项", 1);
                return;
            }
            //获取id
            int memId = ((MemberInfo)dgvMember.SelectedRows[0].DataBoundItem).MemberId;
            MemberInfo memberInfo = bll.GetMemberInfoByMemId(memId);
            //修改 标识2  和会员对象
            ShowFrmMemberAddOrModify(2, memberInfo);//会员对象
        }

        private void ShowFrmMemberAddOrModify(int temp, MemberInfo memberinfo)
        {
            this.Hide();
            FrmMemberAddOrModify frmAddorModify = FrmMemberAddOrModify.Single(temp, memberinfo);
            frmAddorModify.FormClosed += frmAddorModify_FormClosed;
            frmAddorModify.Show();
        }

        void frmAddorModify_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadMemberInfoByDelFlag(0);
            this.Show();
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel文件（*.xlsx)|*.xlsx";
            sfd.Title = "Excel文件操作";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //文件名
                //sfd.FileName
                bll.ExcelWrite(sfd.FileName);
                msgs.MsgDivShow("成功了", 1);
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            //打开窗口
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel文件（*.xlsx;*.xls)|*.xlsx;*.xls";
            ofd.Title = "Excel文件操作";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //o拿路径
                //  ofd.FileName
                bll.ExcelRead(ofd.FileName);
                msgs.MsgDivShow("导入成功了", 1);
                //刷新
                LoadMemberInfoByDelFlag(0);
            }
        }
    }
}
