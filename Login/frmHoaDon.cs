﻿using QuanLiBanHang.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLiBanHang
{
    public partial class frmHoaDon : Form
    {
        DataTable tblCTHoaDon;
        int chucNangDaChon = ChucNang.NONE;
        float sum = 0;
        public string TimKiem { get; set; }
        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            Functions.Connect();
        }

        private void LoadDataGridView()
        {
            txtMaHD.Enabled = false;
            txtTenKH.Enabled = false;
            txtDiaChi.Enabled = false;
            cboMaKH.Enabled = false;
            mtbDienThoai.Enabled = false;
            cboMaNGK.Enabled = false;
            txtSoLuong.Enabled = false;
            txtTenNGK.Enabled = false;
            txtDonGia.Enabled = false;
            txtThanhTien.Enabled = false;
            dtpNgayLapHD.Enabled = false;
            btnIn.Enabled = false;

            string qr = "SELECT MaNGK FROM NuocGiaiKhat";
            DataTable dtDoChoi = Class.Functions.GetDataToTable(qr);
            cboMaNGK.DataSource = dtDoChoi;
            cboMaNGK.DisplayMember = "MaNGK";
            cboMaNGK.ValueMember = "MaNGK";

            string kh = "SELECT MaKH FROM KhachHang";
            DataTable dtKhachHang = Functions.GetDataToTable(kh);
            cboMaKH.DataSource = dtKhachHang;
            cboMaKH.DisplayMember = "MaKH";
            cboMaKH.ValueMember = "MaKH";

            string hd = "SELECT MaHD FROM HoaDon";
            DataTable dtHoaDon = Functions.GetDataToTable(hd);
            cboMaHoaDon.DataSource = dtHoaDon;
            cboMaHoaDon.DisplayMember = "MaHD";
            cboMaHoaDon.ValueMember = "MaHD";
            dgvHDBanHang.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvHDBanHang.AllowUserToAddRows = false;
        }

        private void btnPhieuGhiNo_Click(object sender, EventArgs e)
        {
            frmPhieuTraNo frmPhieuTraNo = new frmPhieuTraNo();
            this.Hide();
            frmPhieuTraNo.ShowDialog();
            this.Show();
        }

        private void btnPhieuHen_Click(object sender, EventArgs e)
        {
            frmPhieuHen frm = new frmPhieuHen();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void ResetValue()
        {
            //txtMaHD.Text = "";
            txtTenKH.Text = "";
            cboMaKH.Text = "";
            mtbDienThoai.Text = "";
            txtDiaChi.Text = "";

            cboMaNGK.Text = "";
            txtTenNGK.Text = "";
            txtThanhTien.Text = "0";
            txtSoLuong.Text = "0";
            txtDonGia.Text = "0";
        }

        private void SetStateControl(bool trangThai)
        {
            btnThem.Enabled = trangThai;
            btnExit.Enabled = trangThai;
            btnHuy.Enabled = !trangThai;
            btnThanhToan.Enabled = !trangThai;
            btnLuu.Enabled = !trangThai;
        }

        private void SwitchMode(int chucNang)
        {
            chucNangDaChon = chucNang;
            switch (chucNang)
            {
                case ChucNang.ADD:
                    SetStateControl(false);
                    txtMaHD.Text = Class.Functions.CreateKey("HDB");
                    cboMaNGK.Enabled = true;
                    txtSoLuong.Enabled = true;
                    txtDiaChi.Enabled = false;
                    txtTenKH.Enabled = false;
                    cboMaKH.Enabled = true;
                    dtpNgayLapHD.Enabled = true;
                    mtbDienThoai.Enabled = false;
                    txtDonGia.Enabled = true;
                    ResetValue();
                    break;

                case ChucNang.NONE:
                    SetStateControl(true);
                    btnHuy.Enabled = false;
                    btnIn.Enabled = false;
                    txtTenKH.Enabled = false;
                    txtDiaChi.Enabled = false;
                    mtbDienThoai.Enabled = false;
                    break;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SwitchMode(ChucNang.ADD);
            dgvHDBanHang.DataSource = null; // Xóa dữ liệu hiện tại
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql, qr2, qr;
            if (cboMaKH.Text == "")
            {
                MessageBox.Show("Bạn chưa thêm thông tin mã khách hàng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboMaNGK.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã đồ chơi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvHDBanHang.Rows.Count < 1)
            {
                sql = $"SELECT MaNGK, SoLuongMua, DonGiaBan FROM ChiTietHoaDon WHERE MaHD = N'{txtMaHD.Text}'";
                qr = $"INSERT INTO ChiTietHoaDon VALUES(N'{txtMaHD.Text}',N'{cboMaNGK.Text}',{int.Parse(txtSoLuong.Text.Trim())},{float.Parse(txtDonGia.Text.Trim())})";
                qr2 = $"INSERT INTO HoaDon VALUES(N'{txtMaHD.Text}','{dtpNgayLapHD.Value.ToString("yyyy/MM/dd")}',N'{cboMaKH.Text}')";
                Class.Functions.RunSQL(qr2);
                Class.Functions.RunSQL(qr);
                MessageBox.Show("Thêm thành công!");
                tblCTHoaDon = Class.Functions.GetDataToTable(sql);
                dgvHDBanHang.DataSource = tblCTHoaDon;
            }
            else
            {
                string check = $"SELECT MaHD, MaNGK FROM ChiTietHoaDon WHERE MaHD = N'{txtMaHD.Text}' AND MaNGK = N'{cboMaNGK.Text}'";
                if (Class.Functions.CheckKey(check))
                {
                    MessageBox.Show("Mã hóa đơn và mã đồ chơi đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                sql = $"SELECT MaNGK, SoLuongMua, DonGiaBan FROM ChiTietHoaDon WHERE MaHD = N'{txtMaHD.Text}'";
                qr = $"INSERT INTO ChiTietHoaDon VALUES(N'{txtMaHD.Text}',N'{cboMaNGK.Text}',{int.Parse(txtSoLuong.Text.Trim())},{float.Parse(txtDonGia.Text.Trim())})";
                Class.Functions.RunSQL(qr);
                MessageBox.Show("Thêm thành công!");
                tblCTHoaDon = Class.Functions.GetDataToTable(sql);
                dgvHDBanHang.DataSource = tblCTHoaDon;
            }
        }

        private void cboMaDC_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaNGK.Text == "")
                txtTenNGK.Text = "";
            // Khi chọn Mã nhân viên thì tên nhân viên tự động hiện ra
            str = "Select TenNGK from NuocGiaiKhat where MaNGK =N'" + cboMaNGK.SelectedValue + "'";
            txtTenNGK.Text = Functions.GetFieldValues(str);
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi số lượng thì thực hiện tính lại thành tiền
            float donGia, thanhTien;
            int soLuong;
            float.TryParse(txtDonGia.Text, out donGia);
            int.TryParse(txtSoLuong.Text, out soLuong);
            thanhTien = soLuong * donGia;
            txtThanhTien.Text = thanhTien.ToString();
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi số lượng thì thực hiện tính lại thành tiền
            float donGia, thanhTien;
            int soLuong;
            float.TryParse(txtDonGia.Text, out donGia);
            int.TryParse(txtSoLuong.Text, out soLuong);
            thanhTien = soLuong * donGia;
            txtThanhTien.Text = thanhTien.ToString();
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            if (cboMaHoaDon.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã hóa đơn cần tìm!");
                return;
            }
            else
            {
                // Thiết lập giá trị cho thuộc tính TimKiem trước khi mở form tìm kiếm
                TimKiem = cboMaHoaDon.Text; // Lấy giá trị từ một TextBox (giả sử tên là txtMaHoaDon)

                // Mở form tìm kiếm và truyền giá trị hiện tại của frmHoaDon
                frmTimKiemHD frmTimKiem = new frmTimKiemHD(this);
                frmTimKiem.ShowDialog();
            }
        }

        private void cboMaKH_TextChanged(object sender, EventArgs e)
        {
            if (cboMaKH.Text == "")
            {
                txtTenKH.Text = "";
                txtDiaChi.Text = "";
                mtbDienThoai.Text = "";
            }
            // Khi chọn Mã khách hàng thì tên khách hàng tự động hiện ra
            string tenKH = $"Select TenKH FROM KhachHang WHERE MaKH = N'{cboMaKH.SelectedValue}'";
            string diaChi = $"Select DiaChi FROM KhachHang WHERE MaKH = N'{cboMaKH.SelectedValue}'";
            string sdt = $"Select SDT FROM KhachHang WHERE MaKH = N'{cboMaKH.SelectedValue}'";
            txtTenKH.Text = Functions.GetFieldValues(tenKH);
            txtDiaChi.Text = Functions.GetFieldValues(diaChi);
            mtbDienThoai.Text = Functions.GetFieldValues(sdt);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy không?", "Thông báo", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                SwitchMode(ChucNang.NONE);
            }
            else
            {
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (cboMaNGK.Text == "" && txtTenNGK.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để xóa!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            // Xóa chi tiết hóa đơn
            string sql = "DELETE FROM ChiTietHoaDon WHERE MaHD = N'" + txtMaHD.Text.Trim() + "' AND MaNGK = N'" + cboMaNGK.Text.Trim() + "'";
            Functions.RunSqlDel(sql);

            // Lấy lại danh sách chi tiết hóa đơn sau khi xóa
            sql = $"SELECT MaNGK, SoLuongMua, DonGiaBan FROM ChiTietHoaDon WHERE MaHD = N'{txtMaHD.Text.Trim()}'";
            tblCTHoaDon = Class.Functions.GetDataToTable(sql);
            dgvHDBanHang.DataSource = tblCTHoaDon;

            MessageBox.Show("Xóa thành công!");
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            btnHuy.Enabled = true;
            btnIn.Enabled = true;
            btnThem.Enabled = false;
            btnLuu.Enabled = false;
            btnExit.Enabled = false;
            btnThanhToan.Enabled = false;
        }

        private void dgvHDBanHang_Click(object sender, EventArgs e)
        {
            if (tblCTHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            cboMaNGK.Text = dgvHDBanHang.CurrentRow.Cells[0].Value.ToString();
            txtSoLuong.Text = dgvHDBanHang.CurrentRow.Cells[1].Value.ToString();
            txtDonGia.Text = dgvHDBanHang.CurrentRow.Cells[2].Value.ToString();
        }

        private void txtThanhTien_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi số lượng thì thực hiện tính lại thành tiền
            float thanhTien;
            float.TryParse(txtThanhTien.Text, out thanhTien);
            sum += thanhTien;
            txtTongTien.Text = sum.ToString();
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            string sql = @"
                        SELECT HD.MaHD, HD.MaKH, CT.MaNGK, CT.SoLuongMua, CT.DonGiaBan
                        FROM HoaDon HD
                        JOIN ChiTietHoaDon CT ON HD.MaHD = CT.MaHoaDon
                        WHERE HD.MaHD = N'" + txtMaHD.Text + "'";

            DataTable dt = Class.Functions.GetDataToTable(sql);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Tạo một ứng dụng Excel mới
            Excel.Application excelApp = new Excel.Application();
            if (excelApp == null)
            {
                MessageBox.Show("Excel is not properly installed!");
                return;
            }

            // Tạo một workbook mới
            Excel.Workbook excelWorkbook = excelApp.Workbooks.Add();
            Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelWorkbook.Sheets[1];

            // Đặt tiêu đề cột
            excelWorksheet.Cells[1, 1] = "Mã Hóa Đơn";
            excelWorksheet.Cells[1, 2] = "Mã Khách Hàng";
            excelWorksheet.Cells[1, 3] = "Mã Đồ Chơi";
            excelWorksheet.Cells[1, 4] = "Số Lượng Mua";
            excelWorksheet.Cells[1, 5] = "Đơn Giá";

            // Đặt dữ liệu từ DataTable vào Excel
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                excelWorksheet.Cells[i + 2, 1] = dt.Rows[i]["MaHD"].ToString();
                excelWorksheet.Cells[i + 2, 2] = dt.Rows[i]["MaKH"].ToString();
                excelWorksheet.Cells[i + 2, 3] = dt.Rows[i]["MaNGK"].ToString();
                excelWorksheet.Cells[i + 2, 4] = dt.Rows[i]["SoLuongMua"].ToString();
                excelWorksheet.Cells[i + 2, 5] = dt.Rows[i]["DonGiaBan"].ToString();
            }

            // Định dạng trang
            excelWorksheet.Columns.AutoFit();
            excelWorksheet.Rows.AutoFit();

            // Hiển thị ứng dụng Excel
            excelApp.Visible = true;

            // Giải phóng các đối tượng COM
            releaseObject(excelWorksheet);
            releaseObject(excelWorkbook);
            releaseObject(excelApp);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
