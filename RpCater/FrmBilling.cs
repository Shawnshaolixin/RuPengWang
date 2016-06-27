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
    public partial class FrmBilling : Form
    {
        private FrmBilling(int deskId, string deskName, RoomInfo room)
        {
            InitializeComponent();
            labDeskName.Text = deskName;
            labLittleMoney.Text = room.RoomMinMoney.ToString();
            labRoomName.Text = room.RoomName;
            labId.Text = deskId.ToString();

        }
        private static FrmBilling _instance;
        public static FrmBilling Single(int deskId, string deskName, RoomInfo room)
        {
            //餐桌id 编号  房间类型 房间的最低消费

            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new FrmBilling(deskId, deskName, room);
            }
            return _instance;
        }
        private int ordId;
        private void btnOk_Click(object sender, EventArgs e)
        {
            //顾客开单
            //更新餐桌状态
            DeskInfoBLL dbll = new DeskInfoBLL();
            int deksId = Convert.ToInt32(labId.Text);

            bool isDesk = dbll.UpdateDeskInfoStateByDeskId(deksId, 1);//1标识正在使用
            //生成订单
            OrderInfoBLL obll = new OrderInfoBLL();
            OrderInfo order = new OrderInfo();
            order.BeginTime = DateTime.Now;
            order.DelFlag = 0;
            order.DisCount = 0;
            order.OrderMoney = 0;
            order.OrderState = 1;//表示已经开单
            order.Remark = txtPersonCount.Text + "个人" + txtDescription.Text;
            order.SubBy = 1;
            order.SubTime = System.DateTime.Now;

            object obj = obll.AddOrderInfo(order);//返回的是刚刚插入的订单的主键id;
            //向中间表插入一条数据
            R_Order_DeskBLL rodbll = new R_Order_DeskBLL();
            R_Order_Desk rod = new R_Order_Desk();
            rod.DeskId = deksId;
            rod.OrderId = Convert.ToInt32(obj);
            ordId = Convert.ToInt32(obj); 
            bool isRod = rodbll.AddR_Order_Desk(rod);
            if (!isDesk || !isRod)
            {
                md.MsgDivShow("开单失败，请联系管理员", 1);
                return;
            }
            md.MsgDivShow("开单成功", 1, Bind);

            //  md.MsgDivShow("开单成功",1,Bind);
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        private void Bind()
        {
            if (ckbMeal.Checked)
            {
                this.Hide();
                //增加消费的窗体显示出来-传订单的id，根据订单的id 查菜单  消费数量  金额
                //传餐桌的编号
                FrmAddConsumption f = FrmAddConsumption.Single(labDeskName.Text, ordId);
                f.FormClosed += f_FormClosed;
                f.Show();
                return;
            }
            this.Close();
        }

    }

}
