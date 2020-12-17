using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms.Business.Service;
using WindowsForms.DataAccess.Repository;

namespace WindowsForms.Presentation
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            //                   tin nhắn                                   title       có 2 nút ok và cancel          sự kiện bấn nút ok
            if (MessageBox.Show("Bạn có thực sự muốn thoát chương trình?", "Thông Báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                // không được thực thi
                e.Cancel = true;
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            String username = textBoxUserName.Text;
            String password = textBoxPassword.Text;

            if (UserService.getInstance().checkLogin(username, password))
            {
                Manager manager = new Manager(username);
                this.Hide();
                manager.ShowDialog(); // show lên trên cùng, chỉ xử lý form trên cùng,những form bên dưới không được hoạt động
                this.Show();
            } else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }
    }
}
