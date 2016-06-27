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
    public partial class FrmAddOrUpdateCategory : Form
    {
        private FrmAddOrUpdateCategory(CategoryInfo c)
        {
            InitializeComponent();
            if (c != null)//修改
            {
                txtName.Text = c.CName;
                txtNum.Text = c.CNum.ToString();
                txtRemark.Text = c.CRemark;
                labId.Text = c.CId.ToString();
            }
            else//新增
            {

            }
        }
        private static int Temp;
        private static FrmAddOrUpdateCategory _instance;
        public static FrmAddOrUpdateCategory Single(int temp, CategoryInfo c)
        {

            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new FrmAddOrUpdateCategory(c);
                Temp = temp;
            }
            return _instance;
        }

        private void FrmAddOrUpdateCategory_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CategoryInfoBLL bll = new CategoryInfoBLL();
            CategoryInfo c = new CategoryInfo();
            c.CName = txtName.Text;
            c.CNum = Convert.ToInt32(txtNum.Text);
            c.CRemark = txtNum.Text;
            if (CheckEmpty())
            {
                if (Temp == 1)//新增
                {
                    c.DelFlag = 0;
                    c.SubTime = DateTime.Now;
                    c.SubBy = 1;


                }
                else if (Temp == 2)//修改
                {
                    c.CId =Convert.ToInt32( labId.Text);
                }
              string strMsg=  bll.AddOrUpdateCategoryInfo(c, Temp) ? "操作成功" : "操作失败";
                msg.MsgDivShow(strMsg,1,Bind);
            }

        }
        private void Bind()
        {
            this.Close();
        }
        private bool CheckEmpty()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                msg.MsgDivShow("名字不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtNum.Text))
            {
                msg.MsgDivShow("编号不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtRemark.Text))
            {
                msg.MsgDivShow("备注不能为空", 1);
                return false;
            }
            return true;
        }

    }
}
