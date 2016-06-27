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
    public partial class FrmRoomAndDesk : Form
    {
        DeskInfoBLL bll = new DeskInfoBLL();
        RoomInfoBLL rbll = new RoomInfoBLL();
        private FrmRoomAndDesk()
        {
            InitializeComponent();
        }
        private static FrmRoomAndDesk _instance;

        public static FrmRoomAndDesk Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FrmRoomAndDesk();
                }
                return _instance;
            }

        }

        private void FrmRoomAndDesk_Load(object sender, EventArgs e)
        {
            LoadAllRoomInfoByDelFlag(0);
            LoadAllDeskInfoByDelFlag(0);
        }

        private void LoadAllRoomInfoByDelFlag(int p)
        {
            //  RoomInfoBLL rbll = new RoomInfoBLL();
            dgvRoom.AutoGenerateColumns = false;
            dgvRoom.DataSource = rbll.GetAllRoomInfoByDelFlag(p);
        }

        private void LoadAllDeskInfoByDelFlag(int p)
        {
            //  DeskInfoBLL bll = new DeskInfoBLL();
            dgvDesk.AutoGenerateColumns = false;
            dgvDesk.DataSource = bll.GetAllDeskInfoByDelFlag(p);
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            ShowFrmRoomAddOrModify(1, null);
        }

        private void btnUpdateRoom_Click(object sender, EventArgs e)
        {
            if (dgvRoom.SelectedRows.Count <= 0)
            {
                msgRoom.MsgDivShow("请选择要修改的项", 1);
                return;
            }
            RoomInfo info = (RoomInfo)dgvRoom.SelectedRows[0].DataBoundItem;
            ShowFrmRoomAddOrModify(2, info);
        }
        private void ShowFrmRoomAddOrModify(int temp, RoomInfo room)
        {
            this.Hide();
            FrmRoomAddOrModify frm = FrmRoomAddOrModify.Single(temp, room);
            frm.FormClosed += frm_FormClosed;
            frm.Show();
        }
        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadAllRoomInfoByDelFlag(0);
            LoadAllDeskInfoByDelFlag(0);
            this.Show();
        }

        private void btnAddDesk_Click(object sender, EventArgs e)
        {
            ShowFrmDeskAddOrModify(1, null);
        }

        private void btnUpdateDesk_Click(object sender, EventArgs e)
        {
            if (dgvDesk.SelectedRows.Count <= 0)
            {
                msgDesk.MsgDivShow("请选择要修改的项", 1);
                return;
            }
            DeskInfo desk = (DeskInfo)dgvDesk.SelectedRows[0].DataBoundItem;
            ShowFrmDeskAddOrModify(2, desk);
        }
        private void ShowFrmDeskAddOrModify(int temp, DeskInfo desk)
        {
            FrmDeskAddOrModify frm = FrmDeskAddOrModify.Single(temp, desk);
            frm.FormClosed += frm_FormClosed;
            frm.Show();
        }

        private void btnDeleteDesk_Click(object sender, EventArgs e)
        {
            if (dgvDesk.SelectedRows.Count <= 0)
            {
                msgDesk.MsgDivShow("请选择要删除的项", 1);
                return;
            }
            if (MessageBox.Show("确定删除该产品吗？", "删除商品", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                int id = ((DeskInfo)dgvDesk.SelectedRows[0].DataBoundItem).DeskId;
                string strMsg = bll.SoftDeleteDeskInfoById(id) ? "删除成功" : "删除失败";
                msgDesk.MsgDivShow(strMsg, 1);
                LoadAllDeskInfoByDelFlag(0);
            }
            else
            {
                msgDesk.MsgDivShow("你已经取消删除", 1);
            }

        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (dgvRoom.SelectedRows.Count <= 0)
            {
                msgRoom.MsgDivShow("请选择要删除的项", 1);
                return;
            }
            if (MessageBox.Show("确定删除该产品吗？", "删除商品", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                int id = ((RoomInfo)dgvRoom.SelectedRows[0].DataBoundItem).RoomId;
                if (bll.GetDeskCountByRoomId(id) > 0)
                {
                    msgRoom.MsgDivShow("该房间下面有很多餐桌信息", 1);
                    return;
                }
                string strMsg = rbll.SoftDeleteRoomInfoByRoomId(id) ? "删除成功" : "删除失败";
                msgRoom.MsgDivShow(strMsg, 1);
                LoadAllRoomInfoByDelFlag(0);
            }
            else
            {
                msgRoom.MsgDivShow("你已经取消删除", 1);
            }
        }
    }
}
