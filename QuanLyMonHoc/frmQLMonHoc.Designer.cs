using System.Diagnostics.Eventing.Reader;

namespace QuanLyMonHoc
{
    partial class frmQLMonHoc
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            grpThongTin = new GroupBox();
            txtSoTinChi = new TextBox();
            txtTenMH = new TextBox();
            lblTenMH = new Label();
            lblSoTinChi = new Label();
            txtMaMH = new TextBox();
            lblMaMH = new Label();
            groupBox1 = new GroupBox();
            btnThoat = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            grpDanhSach = new GroupBox();
            dgvMonHoc = new DataGridView();
            errorProvider1 = new ErrorProvider(components);
            grpThongTin.SuspendLayout();
            groupBox1.SuspendLayout();
            grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMonHoc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // grpThongTin
            // 
            grpThongTin.Controls.Add(txtSoTinChi);
            grpThongTin.Controls.Add(txtTenMH);
            grpThongTin.Controls.Add(lblTenMH);
            grpThongTin.Controls.Add(lblSoTinChi);
            grpThongTin.Controls.Add(txtMaMH);
            grpThongTin.Controls.Add(lblMaMH);
            grpThongTin.Location = new Point(3, 12);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(242, 328);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin môn học";
            // 
            // txtSoTinChi
            // 
            txtSoTinChi.Location = new Point(9, 235);
            txtSoTinChi.Name = "txtSoTinChi";
            txtSoTinChi.Size = new Size(165, 31);
            txtSoTinChi.TabIndex = 5;
            txtSoTinChi.KeyPress += txtSoTinChi_KeyPress;
            // 
            // txtTenMH
            // 
            txtTenMH.Location = new Point(9, 155);
            txtTenMH.Name = "txtTenMH";
            txtTenMH.Size = new Size(165, 31);
            txtTenMH.TabIndex = 3;
            // 
            // lblTenMH
            // 
            lblTenMH.AutoSize = true;
            lblTenMH.Location = new Point(9, 115);
            lblTenMH.Name = "lblTenMH";
            lblTenMH.Size = new Size(118, 25);
            lblTenMH.TabIndex = 2;
            lblTenMH.Text = "Tên môn học:";
            // 
            // lblSoTinChi
            // 
            lblSoTinChi.AutoSize = true;
            lblSoTinChi.Location = new Point(9, 195);
            lblSoTinChi.Name = "lblSoTinChi";
            lblSoTinChi.Size = new Size(89, 25);
            lblSoTinChi.TabIndex = 4;
            lblSoTinChi.Text = "Số tín chỉ:";
            // 
            // txtMaMH
            // 
            txtMaMH.Location = new Point(9, 75);
            txtMaMH.Name = "txtMaMH";
            txtMaMH.Size = new Size(165, 31);
            txtMaMH.TabIndex = 1;
            // 
            // lblMaMH
            // 
            lblMaMH.AutoSize = true;
            lblMaMH.Location = new Point(9, 35);
            lblMaMH.Name = "lblMaMH";
            lblMaMH.Size = new Size(117, 25);
            lblMaMH.TabIndex = 0;
            lblMaMH.Text = "Mã môn học:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Location = new Point(3, 346);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(242, 256);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(124, 139);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(112, 85);
            btnThoat.TabIndex = 3;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(9, 139);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(112, 85);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(124, 48);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(112, 85);
            btnSua.TabIndex = 1;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += this.btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(9, 48);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(112, 85);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // grpDanhSach
            // 
            grpDanhSach.Controls.Add(dgvMonHoc);
            grpDanhSach.Location = new Point(251, 12);
            grpDanhSach.Name = "grpDanhSach";
            grpDanhSach.Size = new Size(798, 590);
            grpDanhSach.TabIndex = 4;
            grpDanhSach.TabStop = false;
            grpDanhSach.Text = "Danh sách môn học";
            // 
            // dgvMonHoc
            // 
            dgvMonHoc.AllowUserToAddRows = false;
            dgvMonHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMonHoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMonHoc.Location = new Point(6, 30);
            dgvMonHoc.MultiSelect = false;
            dgvMonHoc.Name = "dgvMonHoc";
            dgvMonHoc.ReadOnly = true;
            dgvMonHoc.RowHeadersWidth = 62;
            dgvMonHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMonHoc.Size = new Size(786, 554);
            dgvMonHoc.TabIndex = 0;
            dgvMonHoc.CellClick += dgvMonHoc_CellClick;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmQLMonHoc
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1095, 637);
            Controls.Add(grpDanhSach);
            Controls.Add(groupBox1);
            Controls.Add(grpThongTin);
            Name = "frmQLMonHoc";
            Text = "Quản lý Môn học/Học phần";
            FormClosing += frmQLMonHoc_FormClosing;
            Load += frmQLMonHoc_Load;
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            groupBox1.ResumeLayout(false);
            grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMonHoc).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpThongTin;
        private Label lblTenMH;
        private Label lblSoTinChi;
        private Label lblMaMH;
        private TextBox txtMaMH;
        private TextBox txtSoTinChi;
        private TextBox txtTenMH;
        private GroupBox groupBox1;
        private Button btnThoat;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private GroupBox grpDanhSach;
        private DataGridView dgvMonHoc;
        private ErrorProvider errorProvider1;
    }
}
