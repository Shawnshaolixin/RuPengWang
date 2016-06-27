using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RpCater.BLL;
using RpCater.Model;
namespace RpCater
{
    public partial class FrmProductAddOrModify : Form
    {
        CategoryInfoBLL cbll = new CategoryInfoBLL();
        ProductInfoBLL pbll = new ProductInfoBLL();
        private FrmProductAddOrModify(ProductInfo pro)
        {
            InitializeComponent();
            LoadCategoryInfo(0);
            if (pro != null)//修改
            {
                txtCost.Text = pro.ProCost.ToString();
                txtName.Text = pro.ProName.ToString();
                txtNum.Text = pro.ProNum.ToString();
                txtPrice.Text = pro.ProPrice.ToString();
                txtRemark.Text = pro.Remark.ToString();
                txtSpell.Text = pro.ProSpell.ToString();
                txtStock.Text = pro.ProStock.ToString();
                txtUnit.Text = pro.ProUnit.ToString();
                labId.Text = pro.ProId.ToString();
                cmbCategory.SelectedIndex = pro.CId;
            }
        }
        private static int Temp;
        private static FrmProductAddOrModify _instence;
        public static FrmProductAddOrModify Single(int temp, ProductInfo pro)
        {
            if (_instence == null || _instence.IsDisposed)
            {
                _instence = new FrmProductAddOrModify(pro);
                Temp = temp;
            }
            return _instence;
        }

        private void LoadCategoryInfo(int flag)
        {
            cmbCategory.DataSource = cbll.GetAllCategoryInfoByDelFlag(flag);
            cmbCategory.DisplayMember = "CName";
            cmbCategory.ValueMember = "CId";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {


            if (CheckEmpty())
            {

                ProductInfo pro = new ProductInfo();
                pro.ProCost = Convert.ToDecimal(txtCost.Text);
                pro.ProName = txtName.Text;
                pro.ProNum = Convert.ToInt32(txtNum.Text);
                pro.ProPrice = Convert.ToDecimal(txtPrice.Text);
                pro.ProSpell = txtSpell.Text;
                pro.ProStock = Convert.ToInt32(txtStock.Text);
                pro.ProUnit = txtUnit.Text;
                pro.Remark = txtRemark.Text;
                pro.CId = Convert.ToInt32(cmbCategory.SelectedValue);
              
              
                if (Temp == 1)//新增
                { 
                    pro.SubTime = DateTime.Now;
                    pro.SubBy = 1;
                   pro.DelFlag = 0;
                }
                else if (Temp == 2)//修改
                {
                    pro.ProId = Convert.ToInt32(labId.Text);
                }
                string strMsg = pbll.AddOrUpdateProductInfo(pro, Temp) ? "操作成功" : "操作失败";
                msg.MsgDivShow(strMsg, 1, Bind);
            }
        }
        private void Bind()
        {
            this.Close();
        }
        private bool CheckEmpty()
        {
            if (string.IsNullOrEmpty(txtCost.Text))
            {
                msg.MsgDivShow("原价不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                msg.MsgDivShow("名字不能为空", 1); return false;
            }
            if (string.IsNullOrEmpty(txtNum.Text))
            {
                msg.MsgDivShow("编号不能为空", 1); return false;
            }
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                msg.MsgDivShow("单价不能为空", 1); return false;
            }
            if (string.IsNullOrEmpty(txtRemark.Text))
            {
                msg.MsgDivShow("备注不能为空", 1); return false;
            }
            if (string.IsNullOrEmpty(txtSpell.Text))
            {
                msg.MsgDivShow("拼音不能为空", 1); return false;
            }
            if (string.IsNullOrEmpty(txtStock.Text))
            {
                msg.MsgDivShow("库存不能为空", 1); return false;
            }
            if (string.IsNullOrEmpty(txtUnit.Text))
            {
                msg.MsgDivShow("单位不能为空", 1); return false;
            }
            return true;
        }

        private void FrmProductAddOrModify_Load(object sender, EventArgs e)
        {

        }
    }
}
