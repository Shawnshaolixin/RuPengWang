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
    public partial class FrmRoomAddOrModify : Form
    {
        RoomInfoBLL bll = new RoomInfoBLL();
        private FrmRoomAddOrModify(RoomInfo room)
        {
            InitializeComponent();

            if (room != null)
            {
                txtDefault.Text = room.DelFlag.ToString();
                txtMoney.Text = room.RoomMinMoney.ToString();
                txtName.Text = room.RoomName;
                txtNum.Text = room.RoomMaxNum.ToString();
                txtType.Text = room.RoomType.ToString();
                labId.Text = room.RoomId.ToString();
            }

        }
        private static int Temp;
        private static FrmRoomAddOrModify _instance;
        public static FrmRoomAddOrModify Single(int temp, RoomInfo room)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new FrmRoomAddOrModify(room);
                Temp = temp;
            }
            return _instance;
        }
        private void FrmRoomAddOrModify_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (CheckEmpty())
            {
                RoomInfo room = new RoomInfo();
                room.IsDefault = Convert.ToInt32(txtDefault.Text);
                room.RoomMaxNum = Convert.ToInt32(txtNum.Text);
                room.RoomMinMoney = Convert.ToDecimal(txtMoney.Text);
                room.RoomName = txtName.Text;
                room.RoomType = Convert.ToInt32(txtType.Text);
                if (Temp == 1)
                {
                    room.DelFlag = 0;
                    room.SubBy = 1;
                    room.SubTime = DateTime.Now;
                }
                else if (Temp == 2)
                {
                    room.RoomId = Convert.ToInt32(labId.Text);
                }
                string strMsg = bll.AddOrUpdateRoomInfo(room, Temp) ? "操作成功" : "操作失败";
                msg.MsgDivShow(strMsg, 1, Bind);
            }

        }
        private void Bind()
        {
            this.Close();
        }
        private bool CheckEmpty()
        {
            if (string.IsNullOrEmpty(txtType.Text))
            {
                msg.MsgDivShow("类型不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtNum.Text))
            {
                msg.MsgDivShow("数量不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                msg.MsgDivShow("名字不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtMoney.Text))
            {
                msg.MsgDivShow("钱数不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtDefault.Text))
            {
                msg.MsgDivShow("默认值不能为空", 1);
                return false;
            }
            return true;
        }
    }
}
