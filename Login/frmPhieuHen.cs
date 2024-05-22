
using QuanLiBanHang.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

using OfficeOpenXml;
using OfficeOpenXml.Style;


namespace QuanLiBanHang
{
    public partial class frmPhieuHen : Form
    {
        DataTable tblPhieuHen;
        int chucNangDaChon = ChucNang.NONE;

        public object ExcelPackage { get; private set; }

        public frmPhieuHen()
        {
            InitializeComponent();
        }

        private void frmPhieuHen_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            btnLuu.Enabled = false;
        }
        private void LoadDataGridView()
        {
            txtMaPH.Enabled = false;
            cboMaKH.Enabled = false;
            cboMaNGK.Enabled = false;
            dtpNgayHen.Enabled = false;
            dtpNgayLap.Enabled = false;
            txtSoLuong.Enabled = false;

            string sql = "SELECT PhieuHen.MaPhieuHen, PhieuHen.NgayHen, PhieuHen.NgayLap, PhieuHen.MaKH, " +
                         "ChiTietPhieuHen.MaNGK, ChiTietPhieuHen.SoLuongHen " +
                         "FROM PhieuHen " +
                         "INNER JOIN ChiTietPhieuHen ON PhieuHen.MaPhieuHen = ChiTietPhieuHen.MaPhieuHen";
            tblPhieuHen = Functions.GetDataToTable(sql);
            dgvPhieuHen.DataSource = tblPhieuHen;

            string qr = "SELECT MaNGK FROM NuocGiaiKhat";
            DataTable dtMaNGK = Class.Functions.GetDataToTable(qr);
            cboMaNGK.DataSource = dtMaNGK;
            cboMaNGK.DisplayMember = "MaNGK";
            cboMaNGK.ValueMember = "MaNGK";

            string query = "SELECT MaKH FROM KhachHang";
            DataTable dtMaKH = Class.Functions.GetDataToTable(query);
            cboMaKH.DataSource = dtMaKH;
            cboMaKH.DisplayMember = "MaKH";
            cboMaKH.ValueMember = "MaKH";


            dgvPhieuHen.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvPhieuHen.AllowUserToAddRows = false;
        }
        private void SetStateControl(bool trangThai)
        {
            btnThem.Enabled = trangThai;
            btnSua.Enabled = trangThai;
            btnXoa.Enabled = trangThai;
            btnLuu.Enabled = !trangThai;
            btnHuy.Enabled = !trangThai;
            btnExit.Enabled = trangThai;
        }

        private void SwitchMode(int chucNang)
        {
            chucNangDaChon = chucNang;
            switch (chucNang)
            {
                case ChucNang.ADD:
                    SetStateControl(false);
                    txtMaPH.Enabled = true;
                    cboMaKH.Enabled = true;
                    cboMaNGK.Enabled = true;
                    dtpNgayHen.Enabled = true;
                    dtpNgayLap.Enabled = true;
                    txtSoLuong.Enabled = true;
                    ResetValue();
                    txtMaPH.Focus();
                    break;
                case ChucNang.UPDATE:
                    SetStateControl(false);
                    txtMaPH.Enabled = false;
                    cboMaKH.Enabled = true;
                    cboMaNGK.Enabled = false;
                    dtpNgayHen.Enabled = true;
                    dtpNgayLap.Enabled = true;
                    txtSoLuong.Enabled = true;
                    break;
                case ChucNang.NONE:
                    SetStateControl(true);
                    txtMaPH.Enabled = false;
                    cboMaKH.Enabled = false;
                    cboMaNGK.Enabled = false;
                    dtpNgayHen.Enabled = false;
                    dtpNgayLap.Enabled = false;
                    txtSoLuong.Enabled = false;
                    break;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (chucNangDaChon == ChucNang.NONE)
                SwitchMode(ChucNang.ADD);
            else
                SwitchMode(ChucNang.NONE);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (tblPhieuHen.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaPH.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "DELETE FROM PhieuHen WHERE MaPhieuHen = N'" + txtMaPH.Text + "'";
                string qr = "DELETE FROM ChiTietPhieuHen WHERE MaNGK = N'" + cboMaNGK.Text + "' AND MaPhieuHen = N'" + txtMaPH.Text + "'";

                Functions.RunSqlDel(qr);
                Functions.RunSqlDel(sql);
                MessageBox.Show("Xóa thành công!", "Thông báo");
                LoadDataGridView();
                ResetValue();
            }
        }
        private void ResetValue()
        {
            txtMaPH.Text = "";
            txtSoLuong.Text = "";
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaPH.Text == "")
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
                if (txtMaPH.Text.Trim().Length == 0 || cboMaKH.Text.Trim().Length == 0 ||
                    cboMaNGK.Text.Trim().Length == 0 || txtSoLuong.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                    return;
                }

                string sqlCheck = "SELECT MaPhieuHen FROM PhieuHen WHERE MaPhieuHen = '" + txtMaPH.Text.Trim() + "'";
                if (Functions.CheckKey(sqlCheck))
                {
                    MessageBox.Show("Mã phiếu hẹn đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaPH.Focus();
                    return;
                }

                string ngayHenFormatted = dtpNgayHen.Value.ToString("yyyy/MM/dd");
                string ngayLapFormatted = dtpNgayLap.Value.ToString("yyyy/MM/dd");

                string sqlInsertPH = $"INSERT INTO PhieuHen (MaPhieuHen, NgayHen, NgayLap, MaKH) " +
                                     $"VALUES (N'{txtMaPH.Text.Trim()}', '{ngayHenFormatted}', '{ngayLapFormatted}', N'{cboMaKH.Text.Trim()}')";
                string sqlInsertCTPH = $"INSERT INTO ChiTietPhieuHen (MaPhieuHen, MaNGK, SoLuongHen) " +
                                       $"VALUES (N'{txtMaPH.Text.Trim()}', N'{cboMaNGK.Text.Trim()}', {int.Parse(txtSoLuong.Text)})";

                Functions.RunSQL(sqlInsertPH);
                Functions.RunSQL(sqlInsertCTPH);

                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridView();
            }
            else if (chucNangDaChon == ChucNang.UPDATE)
            {
                if (txtMaPH.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn bản ghi nào để cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string ngayHenFormatted = dtpNgayHen.Value.ToString("yyyy/MM/dd");
                string ngayLapFormatted = dtpNgayLap.Value.ToString("yyyy/MM/dd");

                string sqlUpdatePH = $"UPDATE PhieuHen SET NgayHen = '{ngayHenFormatted}', NgayLap = '{ngayLapFormatted}', " +
                                     $"MaKH = N'{cboMaKH.Text.Trim()}' WHERE MaPhieuHen = N'{txtMaPH.Text.Trim()}'";
                string sqlUpdateCTPH = $"UPDATE ChiTietPhieuHen SET MaNGK = N'{cboMaNGK.Text.Trim()}', SoLuongHen = {int.Parse(txtSoLuong.Text)} " +
                                       $"WHERE MaPhieuHen = N'{txtMaPH.Text.Trim()}'";

                Functions.RunSQL(sqlUpdatePH);
                Functions.RunSQL(sqlUpdateCTPH);

                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridView();
            }

            ResetValue();
            SwitchMode(ChucNang.NONE);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValue();
            SwitchMode(ChucNang.NONE);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtMaPhieuHen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã phiếu hẹn cần tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xây dựng câu truy vấn SQL để tìm kiếm thông tin phiếu hẹn và chi tiết phiếu hẹn tương ứng
            string sql = "SELECT PhieuHen.MaPhieuHen, PhieuHen.NgayHen, PhieuHen.NgayLap, PhieuHen.MaKH, " +
                         "ChiTietPhieuHen.MaNGK, ChiTietPhieuHen.SoLuongHen " +
                         "FROM PhieuHen " +
                         "INNER JOIN ChiTietPhieuHen ON " +
                         "PhieuHen.MaPhieuHen = ChiTietPhieuHen.MaPhieuHen " +
                         "WHERE PhieuHen.MaPhieuHen LIKE '%" + txtMaPhieuHen.Text + "%'";
            tblPhieuHen = Class.Functions.GetDataToTable(sql);
            dgvPhieuHen.DataSource = tblPhieuHen;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnXuat_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                // Khởi tạo đối tượng Excel
                excelApp = new Excel.Application();
                if (excelApp == null)
                {
                    MessageBox.Show("Excel is not properly installed!!");
                    return;
                }

                // Tạo Workbook mới
                workbook = excelApp.Workbooks.Add(Type.Missing);

                // Tạo Worksheet cho dữ liệu kết hợp Phiếu Hẹn và Chi Tiết Phiếu Hẹn
                worksheet = workbook.Sheets[1] as Excel.Worksheet;
                if (worksheet == null)
                {
                    throw new InvalidCastException("Unable to cast object to Excel.Worksheet.");
                }
                worksheet.Name = "Phieu Hen & Chi Tiet";

                // Thêm tiêu đề cột
                worksheet.Cells[1, 1] = "MaPhieuHen";
                worksheet.Cells[1, 2] = "NgayHen";
                worksheet.Cells[1, 3] = "NgayLap";
                worksheet.Cells[1, 4] = "MaKH";
                worksheet.Cells[1, 5] = "MaNNGK";
                worksheet.Cells[1, 6] = "SoLuongHen";

                // Load dữ liệu từ cơ sở dữ liệu với JOIN
                string sql = "SELECT PhieuHen.MaPhieuHen, PhieuHen.NgayHen, PhieuHen.NgayLap, PhieuHen.MaKH, " +
                                "ChiTietPhieuHen.MaNGK, ChiTietPhieuHen.SoLuongHen " +
                                "FROM PhieuHen " +
                                "INNER JOIN ChiTietPhieuHen ON PhieuHen.MaPhieuHen = ChiTietPhieuHen.MaPhieuHen";
                DataTable tblData = Functions.GetDataToTable(sql);

                // Thêm dữ liệu vào worksheet
                for (int i = 0; i < tblData.Rows.Count; i++)
                {
                    worksheet.Cells[i + 2, 1] = tblData.Rows[i]["MaPhieuHen"].ToString();
                    worksheet.Cells[i + 2, 2] = tblData.Rows[i]["NgayHen"].ToString();
                    worksheet.Cells[i + 2, 3] = tblData.Rows[i]["NgayLap"].ToString();
                    worksheet.Cells[i + 2, 4] = tblData.Rows[i]["MaKH"].ToString();
                    worksheet.Cells[i + 2, 5] = tblData.Rows[i]["MaNGK"].ToString();
                    worksheet.Cells[i + 2, 6] = tblData.Rows[i]["SoLuongHen"].ToString();
                }

                // Hiển thị hộp thoại lưu tệp Excel
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Save an Excel File";
                saveFileDialog.FileName = "PhieuHen_ChiTietPhieuHen.xlsx";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình chuyển đổi: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
            finally
            {
                // Đóng Workbook và Excel
                if (workbook != null)
                {
                    workbook.Close(false);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                }
                if (worksheet != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                }

                workbook = null;
                worksheet = null;
                excelApp = null;

                // Giải phóng tài nguyên
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void dgvPhieuHen_Click(object sender, EventArgs e)
        {
            txtMaPH.Text = dgvPhieuHen.CurrentRow.Cells[0].Value.ToString();
            txtMaPhieuHen.Text = dgvPhieuHen.CurrentRow.Cells[0].Value.ToString();
            cboMaKH.Text = dgvPhieuHen.CurrentRow.Cells[1].Value.ToString();
            cboMaNGK.Text = dgvPhieuHen.CurrentRow.Cells[2].Value.ToString();
            dtpNgayHen.Value = DateTime.Parse(dgvPhieuHen.CurrentRow.Cells[3].Value.ToString());
            dtpNgayLap.Value = DateTime.Parse(dgvPhieuHen.CurrentRow.Cells[4].Value.ToString());
            txtSoLuong.Text = dgvPhieuHen.CurrentRow.Cells[3].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
    }
}