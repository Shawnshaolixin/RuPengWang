using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RpCater.Model;
using RpCater.BLL;
namespace RpCater
{
    public partial class FrmCategoryAddProduct : Form
    {
        ProductInfoBLL bll = new ProductInfoBLL();
        private FrmCategoryAddProduct()
        {
            InitializeComponent();
        }
        private static FrmCategoryAddProduct _instance;

        public static FrmCategoryAddProduct Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FrmCategoryAddProduct();
                }
                return _instance;
            }

        }
        private void FrmCategoryAddProduct_Load(object sender, EventArgs e)
        {
            LoadCategoryInfoByDelFlag(0);
            LoadProductInfoByDelFlag(0);
        }

        private void LoadProductInfoByDelFlag(int p)
        {

            dgvProduct.AutoGenerateColumns = false;
            dgvProduct.DataSource = bll.GetAllProductInfoByFlag(p);


        }

        private void LoadCategoryInfoByDelFlag(int p)
        {
            CategoryInfoBLL bll = new CategoryInfoBLL();
            dgvCategory.AutoGenerateColumns = false;//禁止自动生成列
            dgvCategory.DataSource = bll.GetAllCategoryInfoByDelFlag(p);

        }
        //增加
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            ShowFrmAddOrUpdateCategory(1, null);
        }
        //修改
        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {

            if (dgvCategory.SelectedRows.Count <= 0)
            {
                msg.MsgDivShow("请选择要修改的项", 1);
                return;
            }
            CategoryInfo categoryInfo = ((CategoryInfo)dgvCategory.SelectedRows[0].DataBoundItem);

            ShowFrmAddOrUpdateCategory(2, categoryInfo);
        }
        private void ShowFrmAddOrUpdateCategory(int temp, CategoryInfo c)
        {
            this.Hide();//隐藏当前窗口
            FrmAddOrUpdateCategory f = FrmAddOrUpdateCategory.Single(temp, c);
            f.FormClosed += frm_FormClosed;
            f.Show();
        }


        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            CategoryInfoBLL bll = new CategoryInfoBLL();
            if (dgvCategory.SelectedRows.Count <= 0)
            {
                msg.MsgDivShow("请选择要删除的项", 1);
                return;
            }
            if (MessageBox.Show("确定删除该产品吗？", "删除商品", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                int id = ((CategoryInfo)dgvCategory.SelectedRows[0].DataBoundItem).CId;
                ProductInfoBLL pbll = new ProductInfoBLL();
                if (pbll.GetProCountByCId(id) > 0)
                {
                    msg.MsgDivShow("该类别下有很多商品部能删除", 1);
                    return;
                }
                string strMsg = bll.SoftDeleteCategoryInfo(id) ? "删除成功" : "删除失败";
                msg.MsgDivShow(strMsg, 1);
                LoadCategoryInfoByDelFlag(0);
            }
            else
            {
                msg.MsgDivShow("您已经取消删除", 1);
            }
        }

        private void btnAddPro_Click(object sender, EventArgs e)
        {
            //新增
            ShowFrmProductAddOrModify(1, null);
        }

        private void btnUpdatePro_Click(object sender, EventArgs e)
        {
            //修改产品
            if (dgvProduct.SelectedRows.Count <= 0)//没有选择任何对象
            {
                msgp.MsgDivShow("请选择要修改的行", 1);
                return;
            }
            ProductInfo pro = (ProductInfo)dgvProduct.SelectedRows[0].DataBoundItem;
            ShowFrmProductAddOrModify(2, pro);
        }
        private void ShowFrmProductAddOrModify(int temp, ProductInfo pro)
        {
            this.Hide();
            FrmProductAddOrModify frm = FrmProductAddOrModify.Single(temp, pro);
            frm.FormClosed += frm_FormClosed;
            frm.Show();
        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadProductInfoByDelFlag(0);
            LoadCategoryInfoByDelFlag(0);
            this.Show();
        }

        private void btnDeletePro_Click(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count <= 0)
            {
                msgp.MsgDivShow("请选择要删除的商品", 1);
                return;
            }
            if (MessageBox.Show("确定删除该产品吗？", "删除商品", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                int id = ((ProductInfo)dgvProduct.SelectedRows[0].DataBoundItem).ProId;
                string strMsg = bll.SoftDeleteProductInfoById(id) ? "删除成功" : "删除失败";
                msgp.MsgDivShow(strMsg, 1);
                LoadProductInfoByDelFlag(0);
                return;
            }
            else
            {
                msgp.MsgDivShow("你已经取消删除", 1);
                return;
            }


            //  LoadCategoryInfoByDelFlag(0);

        }
    }
}
