namespace QuanLiBanHang
{
    partial class frmNGK
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNGK));
            this.lblDoChoi = new System.Windows.Forms.Label();
            this.lblMaNGK = new System.Windows.Forms.Label();
            this.lblTenNGK = new System.Windows.Forms.Label();
            this.lblMaLoaiNGK = new System.Windows.Forms.Label();
            this.txtMaNGK = new System.Windows.Forms.TextBox();
            this.txtTenNGK = new System.Windows.Forms.TextBox();
            this.cboMaLoaiNGK = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvNGK = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.colMaDC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenDC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaLoaiDC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNGK)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDoChoi
            // 
            this.lblDoChoi.AutoSize = true;
            this.lblDoChoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoChoi.ForeColor = System.Drawing.Color.CadetBlue;
            this.lblDoChoi.Location = new System.Drawing.Point(214, 17);
            this.lblDoChoi.Name = "lblDoChoi";
            this.lblDoChoi.Size = new System.Drawing.Size(290, 24);
            this.lblDoChoi.TabIndex = 4;
            this.lblDoChoi.Text = "DANH MỤC NƯỚC GIẢI KHÁT";
            // 
            // lblMaNGK
            // 
            this.lblMaNGK.AutoSize = true;
            this.lblMaNGK.Location = new System.Drawing.Point(-3, 22);
            this.lblMaNGK.Name = "lblMaNGK";
            this.lblMaNGK.Size = new System.Drawing.Size(114, 16);
            this.lblMaNGK.TabIndex = 5;
            this.lblMaNGK.Text = "Mã nước giải khát:";
            // 
            // lblTenNGK
            // 
            this.lblTenNGK.AutoSize = true;
            this.lblTenNGK.Location = new System.Drawing.Point(-3, 61);
            this.lblTenNGK.Name = "lblTenNGK";
            this.lblTenNGK.Size = new System.Drawing.Size(119, 16);
            this.lblTenNGK.TabIndex = 6;
            this.lblTenNGK.Text = "Tên nước giải khát:";
            // 
            // lblMaLoaiNGK
            // 
            this.lblMaLoaiNGK.AutoSize = true;
            this.lblMaLoaiNGK.Location = new System.Drawing.Point(371, 22);
            this.lblMaLoaiNGK.Name = "lblMaLoaiNGK";
            this.lblMaLoaiNGK.Size = new System.Drawing.Size(139, 16);
            this.lblMaLoaiNGK.TabIndex = 12;
            this.lblMaLoaiNGK.Text = "Mã loại nước giải khát:";
            // 
            // txtMaNGK
            // 
            this.txtMaNGK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaNGK.Location = new System.Drawing.Point(132, 20);
            this.txtMaNGK.Name = "txtMaNGK";
            this.txtMaNGK.Size = new System.Drawing.Size(177, 22);
            this.txtMaNGK.TabIndex = 13;
            // 
            // txtTenNGK
            // 
            this.txtTenNGK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenNGK.Location = new System.Drawing.Point(132, 59);
            this.txtTenNGK.Name = "txtTenNGK";
            this.txtTenNGK.Size = new System.Drawing.Size(177, 22);
            this.txtTenNGK.TabIndex = 14;
            // 
            // cboMaLoaiNGK
            // 
            this.cboMaLoaiNGK.FormattingEnabled = true;
            this.cboMaLoaiNGK.Location = new System.Drawing.Point(539, 19);
            this.cboMaLoaiNGK.Name = "cboMaLoaiNGK";
            this.cboMaLoaiNGK.Size = new System.Drawing.Size(177, 24);
            this.cboMaLoaiNGK.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnLuu);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnSua);
            this.panel2.Controls.Add(this.btnHuy);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Location = new System.Drawing.Point(27, 381);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(717, 63);
            this.panel2.TabIndex = 23;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(374, 11);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(92, 39);
            this.btnLuu.TabIndex = 16;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(624, 11);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(92, 39);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "Đóng";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(122, 11);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(92, 39);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(249, 11);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(92, 39);
            this.btnSua.TabIndex = 13;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(499, 11);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(92, 39);
            this.btnHuy.TabIndex = 12;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(0, 11);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(92, 39);
            this.btnThem.TabIndex = 11;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvNGK
            // 
            this.dgvNGK.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvNGK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNGK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaDC,
            this.colTenDC,
            this.colMaLoaiDC});
            this.dgvNGK.Location = new System.Drawing.Point(27, 169);
            this.dgvNGK.Name = "dgvNGK";
            this.dgvNGK.RowHeadersWidth = 51;
            this.dgvNGK.RowTemplate.Height = 24;
            this.dgvNGK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNGK.Size = new System.Drawing.Size(717, 206);
            this.dgvNGK.TabIndex = 24;
            this.dgvNGK.Click += new System.EventHandler(this.dgvNGK_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTenNGK);
            this.panel1.Controls.Add(this.txtMaNGK);
            this.panel1.Controls.Add(this.lblMaLoaiNGK);
            this.panel1.Controls.Add(this.lblTenNGK);
            this.panel1.Controls.Add(this.cboMaLoaiNGK);
            this.panel1.Controls.Add(this.lblMaNGK);
            this.panel1.Location = new System.Drawing.Point(27, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(717, 98);
            this.panel1.TabIndex = 25;
            // 
            // colMaDC
            // 
            this.colMaDC.DataPropertyName = "MaNGK";
            this.colMaDC.HeaderText = "Mã nước giải khát";
            this.colMaDC.MinimumWidth = 6;
            this.colMaDC.Name = "colMaDC";
            this.colMaDC.Width = 160;
            // 
            // colTenDC
            // 
            this.colTenDC.DataPropertyName = "TenNGK";
            this.colTenDC.HeaderText = "Tên nước giải khát";
            this.colTenDC.MinimumWidth = 6;
            this.colTenDC.Name = "colTenDC";
            this.colTenDC.Width = 160;
            // 
            // colMaLoaiDC
            // 
            this.colMaLoaiDC.DataPropertyName = "MaLoai";
            this.colMaLoaiDC.HeaderText = "Mã loại nước giải khát";
            this.colMaLoaiDC.MinimumWidth = 6;
            this.colMaLoaiDC.Name = "colMaLoaiDC";
            this.colMaLoaiDC.Width = 160;
            // 
            // frmNGK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvNGK);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblDoChoi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNGK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục nước giải khát";
            this.Load += new System.EventHandler(this.frmNGK_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNGK)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDoChoi;
        private System.Windows.Forms.Label lblMaNGK;
        private System.Windows.Forms.Label lblTenNGK;
        private System.Windows.Forms.Label lblMaLoaiNGK;
        private System.Windows.Forms.TextBox txtMaNGK;
        private System.Windows.Forms.TextBox txtTenNGK;
        private System.Windows.Forms.ComboBox cboMaLoaiNGK;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvNGK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaDC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenDC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaLoaiDC;
    }
}