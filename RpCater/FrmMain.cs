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
    public partial class FrmMain : Form
    {
        DeskInfoBLL dbll = new DeskInfoBLL();
        RoomInfoBLL rbll = new RoomInfoBLL();
        public FrmMain()
        {
            InitializeComponent();
        }
        //窗体加载的时候
        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadAllRoomInfoByDelFlag(0);
            tabMain.SelectedIndexChanged += new EventHandler(tabMain_SelectedIndexChanged);
            LoadDeskInfoByTabpagesSelect(tabMain.SelectedTab);

        }

        void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab != null)
            {
                LoadDeskInfoByTabpagesSelect(tabMain.SelectedTab);
            }

        }

        private void LoadDeskInfoByTabpagesSelect(TabPage tp)
        {
            RoomInfo room = (RoomInfo)tp.Tag;
            //获取tabpage控件中的listview控件
            ListView lv = (ListView)tp.Controls[0];//为什么是0 因为我只往tab下面添加了一个listview控件
            //根据房间的id查询该房间下所有的餐桌

            List<DeskInfo> list = dbll.GetAllDeskInfoByRoomId(room.RoomId);
            lv.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                lv.Items.Add(list[i].DeskName, list[i].DeskState);
                lv.Items[i].Tag = list[i];
            }

        }
        //加载所有的房间
        private void LoadAllRoomInfoByDelFlag(int p)
        {
            //坑==================
            List<RoomInfo> list = rbll.GetAllRoomInfoByDelFlag(0);
            for (int i = list.Count - 1; i >= 0; i--)
            {
                TabPage tp = new TabPage();
                ListView lv = new ListView();
                tp.Tag = list[i];
                lv.View = View.LargeIcon;//设置控件中图片的显示方式
                lv.LargeImageList = imageList1;//设置该控件中显示图片控件中的图片
                lv.BackColor = Color.DarkSeaGreen;
                lv.MultiSelect = false;//禁止多选
                lv.Dock = DockStyle.Fill;
                tp.Text = list[i].RoomName;
                tp.Controls.Add(lv);
                tabMain.TabPages.Add(tp);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            FrmMember f = FrmMember.Instance;
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmCategoryAddProduct f = FrmCategoryAddProduct.Instance;
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmRoomAndDesk f = FrmRoomAndDesk.Instance;
            f.FormClosed += f1_FormClosed;
            f.Show();
        }
        //顾客开单
        private void button1_Click(object sender, EventArgs e)
        {
            ListView lv = (ListView)tabMain.SelectedTab.Controls[0];
            //房间对象
            RoomInfo room = (RoomInfo)(tabMain.SelectedTab.Tag);

            if (lv.SelectedItems.Count <= 0)
            {
                msg.MsgDivShow("请选择要开单的餐桌", 1);
                return;
            }
            DeskInfo desk = (lv.SelectedItems[0].Tag as DeskInfo);
            if (desk.DeskState == 1)//因为只允许单选，所以是tiems[0];
            {
                msg.MsgDivShow("您选择的餐桌这在就餐", 1);
                return;
            }

            FrmBilling f = FrmBilling.Single(desk.DeskId, desk.DeskName, room);
          
            f.Show();
        }

        private void f1_FormClosed(object sender, FormClosedEventArgs e)
        {
            tabMain.TabPages.Clear();

            LoadAllRoomInfoByDelFlag(0);
            LoadDeskInfoByTabpagesSelect(tabMain.SelectedTab);
        }
        //刷新当前选择的餐桌的状态
        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadDeskInfoByTabpagesSelect(tabMain.SelectedTab);
        }
        //增加消费
        private void button2_Click(object sender, EventArgs e)
        {
            //
            ListView lv = (ListView)tabMain.SelectedTab.Controls[0];
            //房间对象
            RoomInfo room = (RoomInfo)(tabMain.SelectedTab.Tag);

            if (lv.SelectedItems.Count <= 0)
            {
                msg.MsgDivShow("请选择要增加消费的餐桌", 1);
                return;
            }
            DeskInfo desk = (lv.SelectedItems[0].Tag as DeskInfo);
            if (desk.DeskState == 0)//因为只允许单选，所以是tiems[0];
            {
                msg.MsgDivShow("您选择的开单后的餐桌", 1);
                return;
            }
            //根据餐桌的id查询对应餐桌订单的id

            OrderInfoBLL obll = new OrderInfoBLL();
            object objOrderId = obll.GetOrderIdByDeskId(desk.DeskId);
            FrmAddConsumption fac = FrmAddConsumption.Single(desk.DeskName, Convert.ToInt32(objOrderId));
            fac.FormClosed += f_FormClosed;
            fac.Show();

        }
        //顾客结账了
        private void button3_Click(object sender, EventArgs e)
        {
            ListView lv = (ListView)tabMain.SelectedTab.Controls[0];
            //房间对象
            RoomInfo room = (RoomInfo)(tabMain.SelectedTab.Tag);

            if (lv.SelectedItems.Count <= 0)
            {
                msg.MsgDivShow("请选择要结账的餐桌", 1);
                return;
            }
            DeskInfo desk = (lv.SelectedItems[0].Tag as DeskInfo);//因为只允许单选，所以是tiems[0];
            if (desk.DeskState == 0)//0如果是空闲的餐桌
            {
                msg.MsgDivShow("请选择正在就餐的餐桌", 1);
                return;
            }
            OrderInfoBLL obll = new OrderInfoBLL();
            object objOrderId = obll.GetOrderIdByDeskId(desk.DeskId);
            FrmGuestPay fgp = FrmGuestPay.Single(Convert.ToInt32(objOrderId), desk.DeskName, desk.DeskId);
            fgp.FormClosed += f_FormClosed;
            fgp.Show();
        }


    }
}
