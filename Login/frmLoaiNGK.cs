using QuanLiBanHang.Class;
using System;
using System.Collections;
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
    public partial class frmLoaiNGK : Form
    {
        DataTable tblLoaiNGK;
        int chucNangDaChon = ChucNang.NONE;
        public frmLoaiNGK()
        {
            InitializeComponent();
        }

        private void LoadDataGridView()
        {
            txtMaLoaiNGK.Enabled = false;
            txtTenLoaiNGK.Enabled = false;
            cboMaNhaCC.Enabled = false;
            string sql = "SELECT * FROM LoaiNuocGiaiKhat";
            tblLoaiNGK = Class.Functions.GetDataToTable(sql);
            dgvLoaiNGK.DataSource = tblLoaiNGK;
            string qr = "SELECT MaNCC FROM NhaCungCap";
            DataTable dtMaNhaCungCap = Class.Functions.GetDataToTable(qr);

            cboMaNhaCC.DataSource = dtMaNhaCungCap;
            cboMaNhaCC.DisplayMember = "MaNCC";  // Hiển thị mã nhà cung cấp
            cboMaNhaCC.ValueMember = "MaNCC";    // Giá trị của mỗi mục là mã nhà cung cấp

            dgvLoaiNGK.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvLoaiNGK.AllowUserToAddRows = false;
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
                        txtMaLoaiNGK.Enabled = true;
                        txtTenLoaiNGK.Enabled = true;
                        cboMaNhaCC.Enabled = true;
                        ResetValue();
                        txtMaLoaiNGK.Focus();
                        break;
                    }
                case ChucNang.UPDATE:
                    {
                        SetStateControl(false);
                        txtMaLoaiNGK.Enabled = false;
                        txtTenLoaiNGK.Enabled = true;
                        cboMaNhaCC.Enabled = true;
                        txtMaLoaiNGK.Focus();
                        break;
                    }
                case ChucNang.NONE:
                    {
                        SetStateControl(true);
                        txtMaLoaiNGK.Enabled = false;
                        txtTenLoaiNGK.Enabled = false;
                        cboMaNhaCC.Enabled = false;
                        break;
                    }
            }
        }

        private void ResetValue()
        {
            txtMaLoaiNGK.Text = "";
            txtTenLoaiNGK.Text = "";
            cboMaNhaCC.Text = "";
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
            if (txtMaLoaiNGK.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (chucNangDaChon == ChucNang.NONE)
                SwitchMode(ChucNang.UPDATE);
            else
                SwitchMode(ChucNang.NONE);
        }

        private void dgvLoaiDC_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                txtMaLoaiNGK.Focus();
                return;
            }
            if (tblLoaiNGK.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaLoaiNGK.Text = dgvLoaiNGK.CurrentRow.Cells[0].Value.ToString();
            txtTenLoaiNGK.Text = dgvLoaiNGK.CurrentRow.Cells[1].Value.ToString();
            cboMaNhaCC.Text = dgvLoaiNGK.CurrentRow.Cells[2].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SwitchMode(ChucNang.NONE);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblLoaiNGK.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaLoaiNGK.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE FROM LoaiNuocGiaiKhat WHERE MaLoai = N'" + txtMaLoaiNGK.Text + "'";
                Class.Functions.RunSqlDel(sql);
                MessageBox.Show("Xóa thành công!", "Thông báo");
                LoadDataGridView();
                ResetValue();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (chucNangDaChon == ChucNang.ADD)
            {
                string sql;
                if (txtMaLoaiNGK.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập mã loại đồ chơi", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                if (txtTenLoaiNGK.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập tên loại đồ chơi", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                if (cboMaNhaCC.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn chưa chọn mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK);
                    return;
                }

                sql = "SELECT MaLoai FROM LoaiNuocGiaiKhat WHERE MaLoai = '" + txtMaLoaiNGK.Text.Trim() + "'";
                if (Class.Functions.CheckKey(sql))
                {
                    MessageBox.Show("Mã nhà cung cấp này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaLoaiNGK.Focus();
                    return;
                }

                sql = "INSERT INTO LoaiNuocGiaiKhat VALUES('" + txtMaLoaiNGK.Text.Trim() + "',N'" + txtTenLoaiNGK.Text.Trim() + "', N'" + cboMaNhaCC.Text + "')";
                Class.Functions.RunSQL(sql);
                MessageBox.Show("Thêm thành công!");
                LoadDataGridView();
            }
            if (chucNangDaChon == ChucNang.UPDATE)
            {
                string sql = "update LoaiNuocGiaiKhat set TenLoai = N'" + txtTenLoaiNGK.Text.ToString() +
                             "', MaNCC = N'" + cboMaNhaCC.Text.ToString() +
                             "' where MaLoai = N'" + txtMaLoaiNGK.Text + "'";
                Class.Functions.RunSQL(sql);
                SwitchMode(ChucNang.NONE);
                LoadDataGridView();
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void frmLoaiNGK_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            btnLuu.Enabled = false;
        }
    }
}
