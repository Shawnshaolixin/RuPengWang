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
    public partial class FrmGuestPay : Form
    {

        private FrmGuestPay(int orderId, string deskName, int deskId)
        {
            InitializeComponent();
            labDeskName.Text = deskName;
            labOrderId.Text = orderId.ToString();
            labdkId.Text = deskId.ToString();
            OrderInfoBLL obll = new OrderInfoBLL();
            object objMoney = obll.GetMoneyByOrderId(orderId);
             labMoney.Text = objMoney.ToString();//显示消费金额
            lblMoney.Text = objMoney.ToString();//结账金额


        }
        private static FrmGuestPay _instance;
        public static FrmGuestPay Single(int orderId, string deskName, int deskId)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new FrmGuestPay(orderId, deskName, deskId);
            }
            return _instance;
        }

        private void FrmGuestPay_Load(object sender, EventArgs e)
        {
            MemberInfoBLL membll = new MemberInfoBLL();
            List<MemberInfo> list = membll.GetAllMemberInfoByDelFlag(0);
            list.Insert(0, new MemberInfo() { MemName = "请选择", MemberId = -1 });

            cmbMember.DataSource = list;
            cmbMember.DisplayMember = "MemName";
            cmbMember.ValueMember = "MemberId";


            //显示 该订单所有的菜
            LoadAddProByOrder(Convert.ToInt32(labOrderId.Text));
        }

        private void LoadAddProByOrder(int p)
        {
            R_Order_ProductBLL ropbll = new R_Order_ProductBLL();
            dgvROrderProduct.AutoGenerateColumns = false;
            dgvROrderProduct.DataSource = ropbll.GetProductByOrderId(p);
            dgvROrderProduct.ClearSelection();
        }

        private void cmbMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMember.SelectedIndex != 0)
            {
                MemberInfo mem = cmbMember.SelectedItem as MemberInfo;
                if (mem != null)
                {
                    labyuMoney.Text = mem.MemMoney.ToString();
                    lblDisCount.Text = mem.MemDiscount.ToString();
                    if (!string.IsNullOrEmpty(lblDisCount.Text))
                    {
                        lblMoney.Text = (0.1 * Convert.ToInt32(lblDisCount.Text) * Convert.ToInt32(labMoney.Text)).ToString();
                    }
                }
            }
            else
            {
                labyuMoney.Text = "";
                lblDisCount.Text = "";
                lblMoney.Text = labMoney.Text;
            }
        }
        private void btnAccounts_Click(object sender, EventArgs e)
        {
            //更新餐桌状态
            DeskInfoBLL dbll = new DeskInfoBLL();
            bool dkResult = dbll.UpdateDeskInfoStateByDeskId(Convert.ToInt32(labdkId.Text), 0);
            //订单状态改变
            OrderInfoBLL ordlbll = new OrderInfoBLL();
            OrderInfo order = new OrderInfo();
            order.EndTime = System.DateTime.Now;
            order.OrderMoney = Convert.ToDouble(lblMoney.Text);
            order.OrderState = 2;
            order.OrderId = Convert.ToInt32(labOrderId.Text);
            if (cmbMember.SelectedIndex != 0)//是会员
            {
                MemberInfo mem = (MemberInfo)cmbMember.SelectedItem;
                order.OrderMemberId = mem.MemberId;
                order.DisCount = mem.MemDiscount;//状态

                //根据会员的id更新会员的金额
                double money = Convert.ToDouble(labyuMoney.Text) - Convert.ToDouble(lblMoney.Text);
                MemberInfoBLL membll = new MemberInfoBLL();
                membll.UpdateMoneyByMemId(mem.MemberId, money);
            }
            bool ordResult = ordlbll.UpdateOrderInfo(order);
            //改变订单对应订单和菜单的中间表中的菜的状态
            R_Order_ProductBLL ropbll = new R_Order_ProductBLL();
            bool ropResult = ropbll.UpdateR_Order_ProductByOrderId(Convert.ToInt32(labOrderId.Text));
            if (dkResult && ordResult && ropResult)
            {
                md.MsgDivShow("结账成功", 1, Bind);

            }
            else
            {
                md.MsgDivShow("结账失败了", 1);
            }

        }
        private void Bind()
        {
            this.Close();
        }
    }
}
