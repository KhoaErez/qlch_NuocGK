namespace QuanLiBanHang
{
    partial class frmLoaiNGK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoaiNGK));
            this.lblMaLoaiNGK = new System.Windows.Forms.Label();
            this.lblTenLoaiNGK = new System.Windows.Forms.Label();
            this.lblLoaiDoChoi = new System.Windows.Forms.Label();
            this.txtMaLoaiNGK = new System.Windows.Forms.TextBox();
            this.txtTenLoaiNGK = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvLoaiNGK = new System.Windows.Forms.DataGridView();
            this.colMaLoaiDC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenLoaiDC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaNhaCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboMaNhaCC = new System.Windows.Forms.ComboBox();
            this.lblMaNCC = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiNGK)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMaLoaiNGK
            // 
            this.lblMaLoaiNGK.AutoSize = true;
            this.lblMaLoaiNGK.Location = new System.Drawing.Point(9, 18);
            this.lblMaLoaiNGK.Name = "lblMaLoaiNGK";
            this.lblMaLoaiNGK.Size = new System.Drawing.Size(139, 16);
            this.lblMaLoaiNGK.TabIndex = 0;
            this.lblMaLoaiNGK.Text = "Mã loại nước giải khát:";
            // 
            // lblTenLoaiNGK
            // 
            this.lblTenLoaiNGK.AutoSize = true;
            this.lblTenLoaiNGK.Location = new System.Drawing.Point(354, 18);
            this.lblTenLoaiNGK.Name = "lblTenLoaiNGK";
            this.lblTenLoaiNGK.Size = new System.Drawing.Size(144, 16);
            this.lblTenLoaiNGK.TabIndex = 1;
            this.lblTenLoaiNGK.Text = "Tên loại nước giải khát:";
            // 
            // lblLoaiDoChoi
            // 
            this.lblLoaiDoChoi.AutoSize = true;
            this.lblLoaiDoChoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiDoChoi.ForeColor = System.Drawing.Color.CadetBlue;
            this.lblLoaiDoChoi.Location = new System.Drawing.Point(159, 20);
            this.lblLoaiDoChoi.Name = "lblLoaiDoChoi";
            this.lblLoaiDoChoi.Size = new System.Drawing.Size(342, 24);
            this.lblLoaiDoChoi.TabIndex = 3;
            this.lblLoaiDoChoi.Text = "DANH MỤC LOẠI NƯỚC GIẢI KHÁT";
            // 
            // txtMaLoaiNGK
            // 
            this.txtMaLoaiNGK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaLoaiNGK.Location = new System.Drawing.Point(157, 16);
            this.txtMaLoaiNGK.Name = "txtMaLoaiNGK";
            this.txtMaLoaiNGK.Size = new System.Drawing.Size(176, 22);
            this.txtMaLoaiNGK.TabIndex = 4;
            // 
            // txtTenLoaiNGK
            // 
            this.txtTenLoaiNGK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenLoaiNGK.Location = new System.Drawing.Point(505, 16);
            this.txtTenLoaiNGK.Name = "txtTenLoaiNGK";
            this.txtTenLoaiNGK.Size = new System.Drawing.Size(187, 22);
            this.txtTenLoaiNGK.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnLuu);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnSua);
            this.panel2.Controls.Add(this.btnHuy);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Location = new System.Drawing.Point(16, 374);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(698, 63);
            this.panel2.TabIndex = 20;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(371, 11);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(82, 39);
            this.btnLuu.TabIndex = 16;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(603, 11);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(76, 39);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "Đóng";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(135, 11);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(86, 39);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(256, 11);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(80, 39);
            this.btnSua.TabIndex = 13;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(483, 11);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(92, 39);
            this.btnHuy.TabIndex = 12;
            this.btnHuy.Text = "Hủy ";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(15, 11);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 39);
            this.btnThem.TabIndex = 11;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvLoaiNGK
            // 
            this.dgvLoaiNGK.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvLoaiNGK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoaiNGK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaLoaiDC,
            this.colTenLoaiDC,
            this.colMaNhaCC});
            this.dgvLoaiNGK.Location = new System.Drawing.Point(19, 164);
            this.dgvLoaiNGK.Name = "dgvLoaiNGK";
            this.dgvLoaiNGK.RowHeadersWidth = 51;
            this.dgvLoaiNGK.RowTemplate.Height = 24;
            this.dgvLoaiNGK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoaiNGK.Size = new System.Drawing.Size(698, 204);
            this.dgvLoaiNGK.TabIndex = 21;
            this.dgvLoaiNGK.Click += new System.EventHandler(this.dgvLoaiDC_Click);
            // 
            // colMaLoaiDC
            // 
            this.colMaLoaiDC.DataPropertyName = "MaLoai";
            this.colMaLoaiDC.HeaderText = "Mã loại nước giải khát";
            this.colMaLoaiDC.MinimumWidth = 6;
            this.colMaLoaiDC.Name = "colMaLoaiDC";
            this.colMaLoaiDC.Width = 160;
            // 
            // colTenLoaiDC
            // 
            this.colTenLoaiDC.DataPropertyName = "TenLoai";
            this.colTenLoaiDC.HeaderText = "Tên loại nước giải khát";
            this.colTenLoaiDC.MinimumWidth = 6;
            this.colTenLoaiDC.Name = "colTenLoaiDC";
            this.colTenLoaiDC.Width = 160;
            // 
            // colMaNhaCC
            // 
            this.colMaNhaCC.DataPropertyName = "MaNCC";
            this.colMaNhaCC.HeaderText = "Mã nhà cung cấp";
            this.colMaNhaCC.MinimumWidth = 6;
            this.colMaNhaCC.Name = "colMaNhaCC";
            this.colMaNhaCC.Width = 150;
            // 
            // cboMaNhaCC
            // 
            this.cboMaNhaCC.FormattingEnabled = true;
            this.cboMaNhaCC.Location = new System.Drawing.Point(157, 51);
            this.cboMaNhaCC.Name = "cboMaNhaCC";
            this.cboMaNhaCC.Size = new System.Drawing.Size(176, 24);
            this.cboMaNhaCC.TabIndex = 22;
            // 
            // lblMaNCC
            // 
            this.lblMaNCC.AutoSize = true;
            this.lblMaNCC.Location = new System.Drawing.Point(9, 51);
            this.lblMaNCC.Name = "lblMaNCC";
            this.lblMaNCC.Size = new System.Drawing.Size(112, 16);
            this.lblMaNCC.TabIndex = 23;
            this.lblMaNCC.Text = "Mã nhà cung cấp:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblMaNCC);
            this.panel1.Controls.Add(this.cboMaNhaCC);
            this.panel1.Controls.Add(this.txtTenLoaiNGK);
            this.panel1.Controls.Add(this.txtMaLoaiNGK);
            this.panel1.Controls.Add(this.lblTenLoaiNGK);
            this.panel1.Controls.Add(this.lblMaLoaiNGK);
            this.panel1.Location = new System.Drawing.Point(19, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(695, 85);
            this.panel1.TabIndex = 24;
            // 
            // frmLoaiNGK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 468);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvLoaiNGK);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblLoaiDoChoi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLoaiNGK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục loại nước giải khát";
            this.Load += new System.EventHandler(this.frmLoaiNGK_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiNGK)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaLoaiNGK;
        private System.Windows.Forms.Label lblTenLoaiNGK;
        private System.Windows.Forms.Label lblLoaiDoChoi;
        private System.Windows.Forms.TextBox txtMaLoaiNGK;
        private System.Windows.Forms.TextBox txtTenLoaiNGK;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvLoaiNGK;
        private System.Windows.Forms.ComboBox cboMaNhaCC;
        private System.Windows.Forms.Label lblMaNCC;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaLoaiDC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenLoaiDC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNhaCC;
    }
}