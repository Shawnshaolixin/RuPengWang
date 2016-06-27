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
    public partial class FrmDeskAddOrModify : Form
    {
        DeskInfoBLL bll = new DeskInfoBLL();
        private FrmDeskAddOrModify(DeskInfo desk)
        {
            InitializeComponent();
            LoadRoomInfo(0);
            if (desk != null)//修改
            {
                txtName.Text = desk.DeskName;
                txtRegion.Text = desk.DeskRegion;
                txtRemark.Text = desk.DeskRegion;
                txtState.Text = desk.DeskState.ToString();
                labId.Text = desk.DeskId.ToString();
                cmbRoom.SelectedIndex = desk.RoomId;
            }

        }
        private static int Temp;
        private static FrmDeskAddOrModify _instance;
        public static FrmDeskAddOrModify Single(int temp, DeskInfo desk)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new FrmDeskAddOrModify(desk);
                Temp = temp;
            }
            return _instance;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckEmpty())
            {
                DeskInfo desk = new DeskInfo();
                desk.DeskName = txtName.Text;
                desk.DeskRegion = txtRegion.Text;
                desk.DeskRemark = txtRemark.Text;
                
                desk.RoomId = Convert.ToInt32(cmbRoom.SelectedValue);//房间的id
                if (Temp == 1)
                {
                    desk.DeskState = 0;
                    desk.SubBy = 1;
                    desk.SubTime = DateTime.Now;
                    desk.DelFlag = 0;
                }
                else if (Temp == 2)
                {
                    desk.DeskId = Convert.ToInt32(labId.Text);
                }
                string strMsg = bll.AddOrUpdateDeskInfo(desk, Temp) ? "操作成功" : "操作失败";
                msg.MsgDivShow(strMsg, 1, Bind);
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
            if (string.IsNullOrEmpty(txtRegion.Text))
            {
                msg.MsgDivShow("区域不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtRemark.Text))
            {
                msg.MsgDivShow("备注不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtState.Text))
            {
                msg.MsgDivShow("状态不能为空", 1);
                return false;
            }
            return true;
        }

        private void FrmDeskAddOrModify_Load(object sender, EventArgs e)
        {

        }
        private void LoadRoomInfo(int delFlag)
        {
            RoomInfoBLL rbll = new RoomInfoBLL();
            List<RoomInfo> list = new List<RoomInfo>();
            list = rbll.GetAllRoomInfoByDelFlag(delFlag);
            list.Insert(0, new RoomInfo() { RoomName = "请选择", RoomId = -1 });
            cmbRoom.DataSource = list;
            cmbRoom.DisplayMember = "RoomName";
            cmbRoom.ValueMember = "RoomId";
        }

    }



}
