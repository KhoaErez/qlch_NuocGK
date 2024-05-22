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
    public partial class frmNGK : Form
    {
        DataTable tblNGK;
        int chucNangDaChon = ChucNang.NONE;
        public frmNGK()
        {
            InitializeComponent();
        }

        private void LoadDataGridView()
        {
            txtMaNGK.Enabled = false;
            txtTenNGK.Enabled = false;
            cboMaLoaiNGK.Enabled = false;
            string sql = "SELECT * FROM NuocGiaiKhat";
            tblNGK = Class.Functions.GetDataToTable(sql);
            dgvNGK.DataSource = tblNGK;
            string qr = "SELECT MaLoai FROM LoaiNuocGiaiKhat";

            DataTable dtLoaiNGK = Class.Functions.GetDataToTable(qr);
            cboMaLoaiNGK.DataSource = dtLoaiNGK;
            cboMaLoaiNGK.DisplayMember = "MaLoai";  
            cboMaLoaiNGK.ValueMember = "MaLoai";  

            dgvNGK.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvNGK.AllowUserToAddRows = false;
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
                        txtMaNGK.Enabled = true;
                        txtTenNGK.Enabled = true;
                        cboMaLoaiNGK.Enabled = true;
                        ResetValue();
                        txtMaNGK.Focus();
                        break;
                    }
                case ChucNang.UPDATE:
                    {
                        SetStateControl(false);
                        txtMaNGK.Enabled = false;
                        txtTenNGK.Enabled = true;
                        cboMaLoaiNGK.Enabled = true;
                        txtMaNGK.Focus();
                        break;
                    }
                case ChucNang.NONE:
                    {
                        SetStateControl(true);
                        txtMaNGK.Enabled = false;
                        txtTenNGK.Enabled = false;
                        cboMaLoaiNGK.Enabled = false;
                        break;
                    }
            }
        }
        private void ResetValue()
        {
            txtMaNGK.Text = "";
            txtTenNGK.Text = "";
            cboMaLoaiNGK.Text = "";
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
            if (txtMaNGK.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (chucNangDaChon == ChucNang.NONE)
                SwitchMode(ChucNang.UPDATE);
            else
                SwitchMode(ChucNang.NONE);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNGK.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNGK.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE FROM NuocGiaiKhat WHERE MaNGK = '" + txtMaNGK.Text + "'";
                Class.Functions.RunSqlDel(sql);
                MessageBox.Show("Xóa thành công!", "Thông báo");
                LoadDataGridView();
                ResetValue();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (chucNangDaChon == ChucNang.ADD)
            {
                string sql;
                if (txtMaNGK.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập mã loại đồ chơi", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                if (txtTenNGK.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập tên loại đồ chơi", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                if (cboMaLoaiNGK.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn chưa chọn mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK);
                    return;
                }

                sql = "SELECT MaNGK FROM NuocGiaiKhat WHERE MaNGK = '" + txtMaNGK.Text.Trim() + "'";
                if (Class.Functions.CheckKey(sql))
                {
                    MessageBox.Show("Mã nhà cung cấp này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNGK.Focus();
                    return;
                }

                sql = "INSERT INTO NuocGiaiKhat VALUES('" + txtMaNGK.Text.Trim() + "',N'" + txtTenNGK.Text.Trim() + "', N'" + cboMaLoaiNGK.Text + "')";
                Class.Functions.RunSQL(sql);
                MessageBox.Show("Thêm thành công!");
                LoadDataGridView();
            }
            if (chucNangDaChon == ChucNang.UPDATE)
            {
                string sql = "update NuocGiaiKhat set TenNGK = N'" + txtTenNGK.Text.ToString() +
                             "', MaLoai = N'" + cboMaLoaiNGK.Text.ToString() +
                             "' where MaNGK = N'" + txtMaNGK.Text + "'";
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvNGK_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                txtMaNGK.Focus();
                return;
            }
            if (tblNGK.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaNGK.Text = dgvNGK.CurrentRow.Cells[0].Value.ToString();
            txtTenNGK.Text = dgvNGK.CurrentRow.Cells[1].Value.ToString();
            cboMaLoaiNGK.Text = dgvNGK.CurrentRow.Cells[2].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void frmNGK_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            btnLuu.Enabled = false;
        }
    }
}
