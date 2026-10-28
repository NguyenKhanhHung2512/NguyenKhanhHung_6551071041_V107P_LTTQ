using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using QuanLyMonHoc.Models;

namespace QuanLyMonHoc
{
    public partial class frmQLMonHoc : Form
    {
        public frmQLMonHoc()
        {
            InitializeComponent();
        }

        private enum TrangThai
        {
            BanDau, DaChon, DangThem, DangSua
        }
        private TrangThai trangThai;

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmQLMonHoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn thoát không", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                e.Cancel = true; 
            }
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (trangThai != TrangThai.DangThem)
            {
                txtMaMH.Clear();
                txtTenMH.Clear();
                txtSoTinChi.Clear();
                SetTrangThai(TrangThai.DangThem);
                txtMaMH.Focus();
                return;
            }

            string maMH = txtMaMH.Text.Trim();
            string tenMH = txtTenMH.Text.Trim();
            string soTinChi = txtSoTinChi.Text.Trim();

            if (string.IsNullOrEmpty(maMH) || string.IsNullOrEmpty(tenMH) || string.IsNullOrEmpty(soTinChi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin môn học!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (string.IsNullOrEmpty(maMH)) txtMaMH.Focus();
                else if (string.IsNullOrEmpty(tenMH)) txtTenMH.Focus();
                else txtSoTinChi.Focus();
                return;
            }

            if (!double.TryParse(soTinChi, NumberStyles.Float, CultureInfo.InvariantCulture, out double stc) || stc <= 0)
            {
                MessageBox.Show("Số tín chỉ phải là số nguyên hoặc số thực dương!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTinChi.Focus();
                txtSoTinChi.SelectAll();
                return;
            }

            using var db = new DuLieuContext();

            if (db.MonHocs.Any(m => m.MaMonHoc == maMH))
            {
                MessageBox.Show($"Mã môn học \"{maMH}\" đã tồn tại. Vui lòng nhập mã khác!", "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaMH.Focus();
                txtMaMH.SelectAll();
                return;
            }

            db.MonHocs.Add(new MonHoc
            {
                MaMonHoc = maMH,
                TenMocHoc = tenMH,
                SoTinChi = soTinChi
            });
            db.SaveChanges();

            MessageBox.Show("Thêm môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadDuLieu();
            txtMaMH.Clear();
            txtTenMH.Clear();
            txtSoTinChi.Clear();
            SetTrangThai(TrangThai.BanDau);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (trangThai == TrangThai.DaChon)
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa môn học này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    using var db = new DuLieuContext();
                    var monHoc = db.MonHocs.Find(txtMaMH.Text);
                    if (monHoc != null)
                    {
                        db.MonHocs.Remove(monHoc);
                        db.SaveChanges();
                        LoadDuLieu();
                        SetTrangThai(TrangThai.BanDau);
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (trangThai == TrangThai.DaChon)
            {
                SetTrangThai(TrangThai.DangSua);
                txtTenMH.Focus();
                return;
            }

            if (trangThai != TrangThai.DangSua) return;

            string maMH = txtMaMH.Text.Trim();
            string tenMH = txtTenMH.Text.Trim();
            string soTinChi = txtSoTinChi.Text.Trim();

            if (string.IsNullOrEmpty(tenMH) || string.IsNullOrEmpty(soTinChi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin môn học!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (string.IsNullOrEmpty(tenMH)) txtTenMH.Focus();
                else txtSoTinChi.Focus();
                return;
            }

            if (!double.TryParse(soTinChi, NumberStyles.Float, CultureInfo.InvariantCulture, out double stc) || stc <= 0)
            {
                MessageBox.Show("Số tín chỉ phải là số nguyên hoặc số thực dương!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTinChi.Focus();
                txtSoTinChi.SelectAll();
                return;
            }

            using var db = new DuLieuContext();
            var monHoc = db.MonHocs.Find(maMH);   
            if (monHoc == null)
            {
                MessageBox.Show("Không tìm thấy môn học cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadDuLieu();
                SetTrangThai(TrangThai.BanDau);
                return;
            }

            monHoc.TenMocHoc = tenMH;
            monHoc.SoTinChi = soTinChi;
            db.SaveChanges();

            MessageBox.Show("Cập nhật môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadDuLieu();
            txtMaMH.Clear();
            txtTenMH.Clear();
            txtSoTinChi.Clear();
            SetTrangThai(TrangThai.BanDau);
        }

        private void frmQLMonHoc_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
            SetTrangThai(TrangThai.BanDau);
        }


        private void LoadDuLieu()
        {
            using var db = new DuLieuContext();
            var query = db.MonHocs.ToList();
            dgvMonHoc.DataSource = query
                .OrderBy(m => m.MaMonHoc)
                .Select(m => new
                {
                    m.MaMonHoc,
                    TenMonHoc = m.TenMocHoc,
                    m.SoTinChi
                })
                .ToList();

            dgvMonHoc.Columns["MaMonHoc"].HeaderText = "Mã môn học";
            dgvMonHoc.Columns["TenMonHoc"].HeaderText = "Tên môn học";
            dgvMonHoc.Columns["SoTinChi"].HeaderText = "Số tín chỉ";

        }

        private void SetTrangThai(TrangThai tt)
        {
            trangThai = tt;
            btnThem.Text = tt == TrangThai.DangThem ? "Lưu" : "Thêm";
            btnSua.Text = tt == TrangThai.DangSua ? "Lưu" : "Sửa";
            switch (tt)
            {
                case TrangThai.BanDau:
                    txtMaMH.Enabled = false;
                    txtTenMH.Enabled = false;
                    txtSoTinChi.Enabled = false;
                    btnThem.Enabled = true;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnThoat.Enabled = true;
                    break;
                case TrangThai.DaChon:
                    txtMaMH.Enabled = false;
                    txtTenMH.Enabled = false;
                    txtSoTinChi.Enabled = false;
                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnThoat.Enabled = true;
                    break;
                case TrangThai.DangThem:
                    txtMaMH.Enabled = true;
                    txtTenMH.Enabled = true;
                    txtSoTinChi.Enabled = true;
                    btnThem.Enabled = true;   
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnThoat.Enabled = true;
                    break;
                case TrangThai.DangSua:
                    txtMaMH.Enabled = false; 
                    txtTenMH.Enabled = true;
                    txtSoTinChi.Enabled = true;
                    btnThem.Enabled = false;
                    btnSua.Enabled = true;    
                    btnXoa.Enabled = false;
                    btnThoat.Enabled = true;
                    break;
            }
        }

        private void dgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvMonHoc.Rows.Count)
            {
                var selectedRow = dgvMonHoc.Rows[e.RowIndex];
                txtMaMH.Text = selectedRow.Cells["MaMonHoc"].Value?.ToString();
                txtTenMH.Text = selectedRow.Cells["TenMonHoc"].Value?.ToString();
                txtSoTinChi.Text = selectedRow.Cells["SoTinChi"].Value?.ToString();
                SetTrangThai(TrangThai.DaChon);
            }
        }

        private void txtSoTinChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
            {
                e.Handled = true;
            }
        }
    }
}

