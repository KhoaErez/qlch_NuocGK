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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Class.Functions.Connect();
        }

        private void mnuNhaCC_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (frmNhaCungCap frmNhaCungCap = new frmNhaCungCap())
            {
                frmNhaCungCap.ShowDialog();
            }
            this.Show();
        }

        private void mnuLoaiNGK_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (frmLoaiNGK frmLoaiNGK = new frmLoaiNGK())
            {
                frmLoaiNGK.ShowDialog();
            }
            this.Show();
        }

        private void mnuNGK_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (frmNGK frmNGK = new frmNGK())
            {
                frmNGK.ShowDialog();
            }
            this.Show();
        }

        private void mnuDonDH_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (frmDonDH frmDonDH = new frmDonDH())
            {
                frmDonDH.ShowDialog();
            }
            this.Show();
        }

        private void mnuPhieuGH_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (frmPhieuGiaoHang frmPhieuGiaoHang = new frmPhieuGiaoHang())
            {
                frmPhieuGiaoHang.ShowDialog();
            }
            this.Show();
        }

        private void mnuHoaDon_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (frmHoaDon frmHoaDon = new frmHoaDon())
            {
                frmHoaDon.ShowDialog();
            }
            this.Show();
        }

        private void mnuPhieuHen_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (frmPhieuHen frmPH = new frmPhieuHen())
            {
                frmPH.ShowDialog();
            }
            this.Show();
        }

        private void mnuPhieuNo_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (frmPhieuTraNo frmPTN = new frmPhieuTraNo())
            {
                frmPTN.ShowDialog();
            }
            this.Show();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (frmKhachHang frmKH = new frmKhachHang())
            {
                frmKH.ShowDialog();
            }
            this.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Class.Functions.Disconnect();
        }
    }
}
