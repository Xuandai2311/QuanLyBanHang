using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public partial class HangHoa : Form
    {
        DataTable tblH;
        public HangHoa()
        {
            InitializeComponent();
        }

        private void HangHoa_FormClosed(object sender, FormClosedEventArgs e)
        {
            new TrangChinh().Show();
            this.Hide();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            new TrangChinh().Show();
            this.Hide();
        }

        private void HangHoa_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * from NCC";
            txtMaHang.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView();
            Functions.FillCombo(sql, cboMaNCC, "MaNCC", "TenNCC");
            cboMaNCC.SelectedIndex = -1;
            ResetValues();
        }
        private void ResetValues()
        {
            txtMaHang.Text = "";
            txtTenHang.Text = "";
            cboMaNCC.Text = "";
            txtSoLuong.Text = "";
            txtGiaNhap.Text = "";
            txtGiaBan.Text = "";
            txtSoLuong.Enabled = true;
            txtGiaNhap.Enabled = true;
            txtGiaBan.Enabled = true;
            txtDonVi.Text = "";
            txtXuatXu.Text = "";
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from HangHoa";
            tblH = Functions.GetDataToTable(sql);
            dgvHangHoa.DataSource = tblH;
            dgvHangHoa.Columns[0].HeaderText = "Mã hàng";
            dgvHangHoa.Columns[1].HeaderText = "Tên hàng";
            dgvHangHoa.Columns[2].HeaderText = "Mã NCC";
            dgvHangHoa.Columns[3].HeaderText = "Đơn Vị";
            dgvHangHoa.Columns[4].HeaderText = "Xuất Xứ";
            dgvHangHoa.Columns[5].HeaderText = "Số lượng";
            dgvHangHoa.Columns[6].HeaderText = "Đơn giá nhập";
            dgvHangHoa.Columns[7].HeaderText = "Đơn giá bán";

            dgvHangHoa.Columns[0].Width = 80;
            dgvHangHoa.Columns[1].Width = 140;
            dgvHangHoa.Columns[2].Width = 80;
            dgvHangHoa.Columns[3].Width = 80;
            dgvHangHoa.Columns[4].Width = 50;
            dgvHangHoa.Columns[5].Width = 50;
            dgvHangHoa.Columns[6].Width = 80;
            dgvHangHoa.Columns[7].Width = 80;
            dgvHangHoa.AllowUserToAddRows = false;
            dgvHangHoa.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvHangHoaHoa_Click(object sender, EventArgs e)
        {
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaHang.Enabled = true;
            txtMaHang.Focus();
            txtXuatXu.Enabled = true; txtDonVi.Enabled = true;
            txtSoLuong.Enabled = true;
            txtGiaNhap.Enabled = true;
            txtGiaBan.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHang.Focus();
                return;
            }
            if (txtTenHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenHang.Focus();
                return;
            }
            
            
            sql = "SELECT MaHang FROM HangHoa WHERE MaHang=N'" + txtMaHang.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã tồn tại, bạn phải chọn mã hàng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHang.Focus();
                return;
            }
            sql = "INSERT INTO HangHoa(MaHang,TenHang,MaNCC,DVTinh,XuatXu,SoLuong,DonGiaNhap,DonGiaBan) VALUES(N'"
                + txtMaHang.Text.Trim() + "',N'" + txtTenHang.Text.Trim() +
                "',N'" + cboMaNCC.SelectedValue.ToString() + "',N'" + txtDonVi.Text.Trim() + "',N'" + txtXuatXu.Text.Trim() +
                "'," + txtSoLuong.Text.Trim() + "," + txtGiaNhap.Text +"," + txtGiaBan.Text + ")";

            Functions.RunSQL(sql);
            LoadDataGridView();
            //ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaHang.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHang.Focus();
                return;
            }
            if (txtTenHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenHang.Focus();
                return;
            }
            if (cboMaNCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaNCC.Focus();
                return;
            }
            
            sql = "UPDATE HangHoa SET TenHang=N'" + txtTenHang.Text.Trim().ToString() +
                "',MaNCC=N'" + cboMaNCC.SelectedValue.ToString() + "',DVTinh=N'" + txtDonVi.Text +
                "',XuatXu=N'" + txtXuatXu.Text + "',SoLuong=" + txtSoLuong.Text +
                ",DonGiaNhap=" + txtGiaNhap.Text + ",DonGiaBan=" + txtGiaBan.Text +
                " WHERE MaHang = N'" + txtMaHang.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE HangHoa WHERE MaHang=N'" + txtMaHang.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaHang.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaHang.Text == "") && (txtTenHang.Text == "") && (cboMaNCC.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from HangHoa WHERE 1=1";
            if (txtMaHang.Text != "")
                sql += " AND MaHang LIKE N'%" + txtMaHang.Text + "%'";
            if (txtTenHang.Text != "")
                sql += " AND TenHang LIKE N'%" + txtTenHang.Text + "%'";
            if (cboMaNCC.Text != "")
                sql += " AND MaNCC LIKE N'%" + cboMaNCC.SelectedValue + "%'";
            tblH = Functions.GetDataToTable(sql);
            if (tblH.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblH.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvHangHoa.DataSource = tblH;
            ResetValues();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaHang,TenHang,MaNCC,DVTinh,XuatXu,SoLuong,DonGiaNhap,DonGiaBan FROM HangHoa";
            tblH = Functions.GetDataToTable(sql);
            dgvHangHoa.DataSource = tblH;
        }

        

        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaNCC;
            string sql;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHang.Focus();
                return;
            }
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaHang.Text = dgvHangHoa.CurrentRow.Cells["MaHang"].Value.ToString();
            txtTenHang.Text = dgvHangHoa.CurrentRow.Cells["TenHang"].Value.ToString();
            MaNCC = dgvHangHoa.CurrentRow.Cells["MaNCC"].Value.ToString();
            sql = "SELECT TenNCC FROM NCC WHERE MaNCC=N'" + MaNCC + "'";
            cboMaNCC.Text = Functions.GetFieldValues(sql);
            txtDonVi.Text = dgvHangHoa.CurrentRow.Cells["DVTinh"].Value.ToString();
            txtXuatXu.Text = dgvHangHoa.CurrentRow.Cells["XuatXu"].Value.ToString();
            txtSoLuong.Text = dgvHangHoa.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtGiaNhap.Text = dgvHangHoa.CurrentRow.Cells["DonGiaNhap"].Value.ToString();
            txtGiaBan.Text = dgvHangHoa.CurrentRow.Cells["DonGiaBan"].Value.ToString();

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }
    }
}
