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
    public partial class FrmAddConsumption : Form
    {

        ProductInfoBLL probll = new ProductInfoBLL();
        R_Order_ProductBLL ropbll = new R_Order_ProductBLL();
        private FrmAddConsumption(string deskName, int orderId)
        {
            InitializeComponent();
            labDeskName.Text = deskName;
            labOrderId.Text = orderId.ToString();
        }
        private static FrmAddConsumption _instance;
        //传餐桌的编号，传订单的id 查点的菜  数量 金额
        public static FrmAddConsumption Single(string deskName, int orderId)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new FrmAddConsumption(deskName, orderId);
            }
            return _instance;
        }
        //窗体加载的时候
        private void FrmAddConsumption_Load(object sender, EventArgs e)
        {
            //加载所有的商品
            LoadAllProductInfoByDelFlag(0);
            LoadAllCategoryInfoByDelFlag(0);
            LoadProductByOrderId(Convert.ToInt32(labOrderId.Text));

        }
        //加载所有的类别
        private void LoadAllCategoryInfoByDelFlag(int p)
        {
            CategoryInfoBLL cbll = new CategoryInfoBLL();
            List<CategoryInfo> list = cbll.GetAllCategoryInfoByDelFlag(p);
            for (int i = 0; i < list.Count; i++)
            {
                TreeNode tn = tvCategory.Nodes.Add(list[i].CName);
                LoadProductInfoByCId(tn.Nodes, list[i].CId);
            }
        }

        private void LoadProductInfoByCId(TreeNodeCollection tnc, int p)
        {
            List<ProductInfo> list = probll.GetProductInfoByCId(p);
            foreach (ProductInfo pro in list)
            {
                tnc.Add(pro.ProName + "==" + pro.ProPrice + "元");
            }
        }
        //g根据类别id获取对应类别下面的产品

        //加载所有的商品
        private void LoadAllProductInfoByDelFlag(int p)
        {
            ProductInfoBLL probll = new ProductInfoBLL();
            dgvProduct.AutoGenerateColumns = false;//禁止自动生成列
            dgvProduct.DataSource = probll.GetAllProductInfoByFlag(p);
            dgvProduct.ClearSelection();
        }
        //双击单元格时发生
        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProduct.SelectedRows.Count <= 0)
            {
                md.MsgDivShow("请选择要点的菜", 1);
                return;
            }
            int tCount;
            if (txtCount.Text == "0" || txtCount.Text == "1" || string.IsNullOrEmpty(txtCount.Text))
            {
                txtCount.Text = "1";
            }
            if (!int.TryParse(txtCount.Text, out tCount))//如果转换成功，将值给tCount
            {
                md.MsgDivShow("输入的不是数字", 1);
                return;
            }
            R_Order_Product rop = new R_Order_Product();
            rop.DelFlag = 0;
            rop.OrderId = Convert.ToInt32(labOrderId.Text);

            rop.ProId = ((ProductInfo)dgvProduct.SelectedRows[0].DataBoundItem).ProId;
            rop.SubTime = DateTime.Now;
            rop.UnitCount = Convert.ToInt32(txtCount.Text);
            R_Order_ProductBLL ropbll = new R_Order_ProductBLL();
            md.MsgDivShow(ropbll.AddR_Order_Product(rop) ? "添加成功" : "添加失败", 1);

            //刷新
            //显示点的菜
            LoadProductByOrderId(Convert.ToInt32(labOrderId.Text));

            //坑啊
        }
        //显示点的菜
        private void LoadProductByOrderId(int p)
        {
            dgvROrderProduct.AutoGenerateColumns = false;
            List<R_Order_Product> list = ropbll.GetProductByOrderId(p);
            double sum = 0;
            foreach (R_Order_Product pro in list)
            {
                sum += pro.ProMoney;
            }
            labCount.Text = list.Count.ToString();
            labSumMoney.Text = sum.ToString();
            dgvROrderProduct.DataSource = list;
            dgvROrderProduct.ClearSelection();//清除默认选中项
        }
        //模糊搜索
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            int temp = string.IsNullOrEmpty(txtSearch.Text) ? 0 : char.IsLetter(txtSearch.Text[0]) ? 1 : 2;
            dgvProduct.AutoGenerateColumns = false;
            dgvProduct.DataSource = probll.GetProductByProSpellOrProNum(temp, txtSearch.Text);
            dgvProduct.ClearSelection();
        }
        //退菜操作
        private void btnDeleteRorderPro_Click(object sender, EventArgs e)
        {
            if (dgvROrderProduct.SelectedRows.Count <= 0)
            {
                md.MsgDivShow("请选择要删除的商品", 1);
                return;
            }
            if (MessageBox.Show("确定移除吗?", "移除", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                R_Order_ProductBLL ropbll = new R_Order_ProductBLL();

                int ropId = ((R_Order_Product)(dgvROrderProduct.SelectedRows[0].DataBoundItem)).ROrderProId;
                md.MsgDivShow(ropbll.SoftDeleteR_Order_ProByRpoId(ropId) ? "操作成功" : "操作失败", 1, Bind);

            }
            else
            {
                md.MsgDivShow("你已经取消删除", 1);
                return;
            }
        }
        private void Bind()
        {
            //删除之后要刷新
            LoadProductByOrderId(Convert.ToInt32(labOrderId.Text));
        }
        //页面关闭的时候
        private void FrmAddConsumption_FormClosed(object sender, FormClosedEventArgs e)
        {
            ////更新总价
            //if (string.IsNullOrEmpty(labSumMoney.Text))
            //{
            //    OrderInfoBLL obll = new OrderInfoBLL();
            //    obll.UpdateOrderMoneyAndBeginTimeByOrderId(Convert.ToInt32(labOrderId.Text), Convert.ToDouble(labSumMoney.Text));
            //    //不用提示吧？
            //}
        }

        private void FrmAddConsumption_FormClosing(object sender, FormClosingEventArgs e)
        {
            //更新总价
            if (!string.IsNullOrEmpty(labSumMoney.Text))
            {
                OrderInfoBLL obll = new OrderInfoBLL();
                obll.UpdateOrderMoneyAndBeginTimeByOrderId(Convert.ToInt32(labOrderId.Text), Convert.ToDouble(labSumMoney.Text));
                //不用提示吧？
            }
        }
    }
}
