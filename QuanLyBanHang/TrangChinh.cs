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
    public partial class TrangChinh : Form
    {
        public TrangChinh()
        {
            InitializeComponent();
        }
       


        private void mnuNCC_Click(object sender, EventArgs e)
        {
            new NCC().Show();
            this.Hide();
        }

        private void mnuHangHoa_Click(object sender, EventArgs e)
        {
            new HangHoa().Show();
            this.Hide();
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            new NhanVien().Show();
            this.Hide();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            new KhachHang().Show();
            this.Hide();
        }

        private void mnHoaDon_Click(object sender, EventArgs e)
        {
            new ChiTietHoaDon().Show();
            this.Hide();
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TimKiemHoaDon().Show();
            this.Hide();
        }

        private void TrangChinh_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void TrangChinh_Load(object sender, EventArgs e)
        {
            Class.Functions.Connect();
        }
    }
}
