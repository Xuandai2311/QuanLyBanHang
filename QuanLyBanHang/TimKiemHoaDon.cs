using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class TimKiemHoaDon : Form
    {
        public TimKiemHoaDon()
        {
            InitializeComponent();
        }

        private void TimKiemHoaDon_FormClosed(object sender, FormClosedEventArgs e)
        {
            new TrangChinh().Show();
            this.Hide();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            new TrangChinh().Show();
            this.Hide();
        }
    }
}
