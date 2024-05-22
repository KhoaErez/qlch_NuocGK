using QuanLiBanHang.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiBanHang
{
    public partial class frmDonDH : Form
    {
        DataTable tblDonDH;
        int chucNangDaChon = ChucNang.NONE;
        string nhap;
        frmPhieuGiaoHang frmPhieuGiaoHang;
        public frmDonDH(frmPhieuGiaoHang frmPhieuGiao)
        {
            InitializeComponent();
            this.frmPhieuGiaoHang = frmPhieuGiao;
        }
        public frmDonDH()
        {
            InitializeComponent();
        }

        private void frmDonDH_Load(object sender, EventArgs e)
        {// Kiểm tra xem biến frmPhieuGiaoHang đã được khởi tạo chưa
            if (frmPhieuGiaoHang != null)
            {
                if (!string.IsNullOrEmpty(frmPhieuGiaoHang.TimKiem))
                {
                    // Thực hiện truy vấn dữ liệu với mã hóa đơn từ frmHoaDon
                    string maDDH = frmPhieuGiaoHang.TimKiem;
                    string sql = $"SELECT * FROM DonDatHang WHERE MaDDH = N'{maDDH}'";
                    DataTable dt = Functions.GetDataToTable(sql);

                    // Nếu có kết quả từ truy vấn, hiển thị dữ liệu trong DataGridView
                    if (dt.Rows.Count > 0)
                    {
                        txtMaDDH.Text = maDDH;
                        string qr2 = "SELECT ChiTietDonDatHang.MaDDH, ChiTietDonDatHang.MaNGK, ChiTietDonDatHang.SoLuongDat, DonDatHang.NgayDH, DonDatHang.MaNCC FROM ChiTietDonDatHang " +
                             $"INNER JOIN DonDatHang ON ChiTietDonDatHang.MaDDH = DonDatHang.MaDDH WHERE DonDatHang.MaDDH = N'{maDDH}'";
                        DataTable ddh = Class.Functions.GetDataToTable(qr2);
                        dgvDonDH.DataSource = ddh;

                        string qr = $"SELECT MaNCC FROM DonDatHang WHERE MaDDH = N'{maDDH}'";
                        DataTable dtMaNhaCungCap = Class.Functions.GetDataToTable(qr);
                        cboMaNCC.DataSource = dtMaNhaCungCap;
                        cboMaNCC.DisplayMember = "MaNCC";  // Hiển thị mã nhà cung cấp
                        cboMaNCC.ValueMember = "MaNCC";    // Giá trị của mỗi mục là mã nhà cung cấp

                        string query = $"SELECT MaNGK FROM ChiTietDonDatHang WHERE MaDDH = N'{maDDH}'";
                        DataTable dtMaDC = Class.Functions.GetDataToTable(query);
                        cboMaNGK.DataSource = dtMaDC;
                        cboMaNGK.DisplayMember = "MaNGK";
                        cboMaNGK.ValueMember = "MaNGK";

                        dgvDonDH.EditMode = DataGridViewEditMode.EditProgrammatically;
                        dgvDonDH.AllowUserToAddRows = false;
                    }
                }
                else
                {
                    LoadDataGridView();
                }
            }
            else
            {
                // Xử lý trường hợp khi biến frmPhieuGiaoHang là null
                LoadDataGridView();
            }
        }
        private void LoadDataGridView()
        {
            txtMaDDH.Enabled = false;
            txtSoLuong.Enabled = false;
            dtpNgayDH.Enabled = false;
            cboMaNGK.Enabled = false;
            cboMaNCC.Enabled = false;
            string sql = "SELECT ChiTietDonDatHang.MaDDH, ChiTietDonDatHang.MaNGK, ChiTietDonDatHang.SoLuongDat, DonDatHang.NgayDH, DonDatHang.MaNCC FROM ChiTietDonDatHang " +
                         "INNER JOIN DonDatHang ON ChiTietDonDatHang.MaDDH = DonDatHang.MaDDH";
            tblDonDH = Class.Functions.GetDataToTable(sql);
            dgvDonDH.DataSource = tblDonDH;

            string qr = "SELECT MaNCC FROM NhaCungCap";
            DataTable dtMaNhaCungCap = Class.Functions.GetDataToTable(qr);
            cboMaNCC.DataSource = dtMaNhaCungCap;
            cboMaNCC.DisplayMember = "MaNCC";  // Hiển thị mã nhà cung cấp
            cboMaNCC.ValueMember = "MaNCC";    // Giá trị của mỗi mục là mã nhà cung cấp

            string query = "SELECT MaNGK FROM NuocGiaiKhat";
            DataTable dtMaDC = Class.Functions.GetDataToTable(query);
            cboMaNGK.DataSource = dtMaDC;
            cboMaNGK.DisplayMember = "MaNGK";
            cboMaNGK.ValueMember = "MaNGK";

            dgvDonDH.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvDonDH.AllowUserToAddRows = false;
        }

        private void SetStateControl(Boolean trangThai)
        {
            btnThem.Enabled = trangThai;
            btnSua.Enabled = trangThai;
            btnXoa.Enabled = trangThai;
            btnLuu.Enabled = !trangThai;
            btnHuy.Enabled = !trangThai;
            btnExit.Enabled = trangThai;
        }

        //Phương thức chọn chức năng
        void SwitchMode(int chucNang)
        {
            chucNangDaChon = chucNang;
            switch (chucNang)
            {
                case ChucNang.ADD:
                    {
                        SetStateControl(false);
                        txtMaDDH.Enabled = true;
                        txtSoLuong.Enabled = true;
                        cboMaNCC.Enabled = true;
                        cboMaNGK.Enabled = true;
                        dtpNgayDH.Enabled = true;
                        ResetValue();
                        txtMaDDH.Focus();
                        break;
                    }
                case ChucNang.UPDATE:
                    {
                        SetStateControl(false);
                        txtMaDDH.Enabled = false;
                        txtSoLuong.Enabled = true;
                        cboMaNGK.Enabled = false;
                        cboMaNCC.Enabled = true;
                        dtpNgayDH.Enabled = true;
                        txtMaDDH.Focus();
                        break;
                    }
                case ChucNang.NONE:
                    {
                        SetStateControl(true);
                        txtMaDDH.Enabled = false;
                        txtSoLuong.Enabled = false;
                        cboMaNGK.Enabled = false;
                        cboMaNCC.Enabled = false;
                        dtpNgayDH.Enabled = false;
                        break;
                    }
            }
        }

        private void ResetValue()
        {
            txtMaDDH.Text = "";
            txtSoLuong.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (chucNangDaChon == ChucNang.NONE)
                SwitchMode(ChucNang.ADD);
            else
                SwitchMode(ChucNang.NONE);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaDDH.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (chucNangDaChon == ChucNang.NONE)
                SwitchMode(ChucNang.UPDATE);
            else
                SwitchMode(ChucNang.NONE);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (chucNangDaChon == ChucNang.ADD)
            {
                string sql;
                string qr;
                if (txtMaDDH.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập mã đơn đặt hàng", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                if (cboMaNCC.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn chưa chọn mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                if (cboMaNGK.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn chưa chọn mã đồ chơi", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                if (txtSoLuong.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập số lượng đồ chơi bạn muốn đặt", "Thông báo", MessageBoxButtons.OK);
                    return;
                }

                sql = "SELECT MaNGK, MaDDH FROM ChiTietDonDatHang WHERE MaNGK = N'" + cboMaNGK.Text + "' AND MaDDH = N'" + txtMaDDH.Text.Trim() + "'";
                if (Class.Functions.CheckKey(sql))
                {
                    MessageBox.Show("Mã đồ chơi và mã đơn đặt hàng đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaDDH.Focus();
                    return;
                }
                //sql = "INSERT INTO DoChoi VALUES(N'" + cboMaDC.Text + "',N'" + txtTenDC.Text.Trim() + "', N'" + cboMaLoaiDC.Text + "')";
                sql = "INSERT INTO ChiTietDonDatHang VALUES(N'" + txtMaDDH.Text + "',N'" + cboMaNGK.Text + "'," + txtSoLuong.Text + ")";
                qr = "INSERT INTO DonDatHang VALUES(N'" + txtMaDDH.Text.Trim() + "',N'" + dtpNgayDH.Value.ToString("yyyy/MM/dd") + "', N'" + cboMaNCC.Text + "')";
                Class.Functions.RunSQL(qr);
                Class.Functions.RunSQL(sql);
                MessageBox.Show("Thêm thành công!");
                LoadDataGridView();
            }
            if (chucNangDaChon == ChucNang.UPDATE)
            {
                string sql = "UPDATE DonDatHang SET NgayDH = '" + dtpNgayDH.Value.ToString("yyyy/MM/dd") +
                             "', MaNCC = N'" + cboMaNCC.Text.ToString() +
                             "' WHERE MaDDH = N'" + txtMaDDH.Text + "'";
                string qr = "UPDATE ChiTietDonDatHang SET SoLuongDat = " + int.Parse(txtSoLuong.Text) +
                            " WHERE MaDDH = N'" + txtMaDDH.Text.Trim() + "' AND MaNGK = N'" + cboMaNGK.Text + "'";
                Class.Functions.RunSQL(qr);
                Class.Functions.RunSQL(sql);
                SwitchMode(ChucNang.NONE);
                LoadDataGridView();
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SwitchMode(ChucNang.NONE);
        }

        private void dgvDonDH_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                txtMaDDH.Focus();
                return;
            }
            txtMaDDH.Text = dgvDonDH.CurrentRow.Cells[0].Value.ToString();
            txtSoLuong.Text = dgvDonDH.CurrentRow.Cells[2].Value.ToString();
            dtpNgayDH.Value = DateTime.Parse(dgvDonDH.CurrentRow.Cells[3].Value.ToString());
            cboMaNGK.Text = dgvDonDH.CurrentRow.Cells[1].Value.ToString();
            cboMaNCC.Text = dgvDonDH.CurrentRow.Cells[4].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            string qr;
            if (tblDonDH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaDDH.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE FROM DonDatHang WHERE MaDDH = '" + txtMaDDH.Text + "'";
                qr = "DELETE FROM ChiTietDonDatHang WHERE MaDDH = N'" + txtMaDDH.Text.Trim() + "' AND MaNGK = N'" + cboMaNGK.Text + "'";
                Class.Functions.RunSqlDel(qr);
                Class.Functions.RunSqlDel(sql);
                MessageBox.Show("Xóa thành công!", "Thông báo");
                LoadDataGridView();
                ResetValue();
            }
        }

        private void btnGuiDon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gửi đơn thành công!", "Thành công", MessageBoxButtons.OK);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
