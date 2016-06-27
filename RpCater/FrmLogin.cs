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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        //取消
        private void btnESC_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //登录
            if (IsEmpty())
            {
                UserInfoBLL userBll = new UserInfoBLL();
                var result = userBll.GetUserInfoByLoginName(txtName.Text.Trim(), txtPwd.Text.Trim());
                if (result == LoginState.LoginNameNotFound)
                {
                    msg.MsgDivShow("账号不存在", 1);
                }
                else if (result == LoginState.PasswordError)
                {
                    msg.MsgDivShow("密码错误", 1);
                }
                else if (result == LoginState.OK)
                {
                    msg.MsgDivShow("登录成功", 1,Bind);
                }
                else
                {
                    throw new Exception("不可能的情况");
                }
            }
        }
        private void Bind()
        {
            //设置当前窗体的对话框的结果
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private bool IsEmpty()
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                msg.MsgDivShow("账号不能为空",1);
                return false;
            }
            if (string.IsNullOrEmpty(txtPwd.Text.Trim())) 
            {
                msg.MsgDivShow("密码不能为空",1);
                return false;
            }
            return true;
        }
    }
}
