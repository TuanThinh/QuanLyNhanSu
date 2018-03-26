namespace QuanLyNhanSu.GUI
{
    partial class frmTK_DSNV
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lsvNhanVien = new System.Windows.Forms.ListView();
            this.colMaNV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHoTen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGioiTinh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNgaySinh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDiaChi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDanToc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQuocTich = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSoDienThoai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMaPB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colChucVu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMaTDHV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBacLuong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnInDanhSach = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1213, 561);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lsvNhanVien);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 18);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1207, 540);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // lsvNhanVien
            // 
            this.lsvNhanVien.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMaNV,
            this.colHoTen,
            this.colGioiTinh,
            this.colNgaySinh,
            this.colDiaChi,
            this.colDanToc,
            this.colQuocTich,
            this.colSoDienThoai,
            this.colMaPB,
            this.colChucVu,
            this.colMaTDHV,
            this.colBacLuong});
            this.lsvNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvNhanVien.Location = new System.Drawing.Point(3, 18);
            this.lsvNhanVien.Name = "lsvNhanVien";
            this.lsvNhanVien.Size = new System.Drawing.Size(1201, 519);
            this.lsvNhanVien.TabIndex = 0;
            this.lsvNhanVien.UseCompatibleStateImageBehavior = false;
            this.lsvNhanVien.View = System.Windows.Forms.View.Details;
            // 
            // colMaNV
            // 
            this.colMaNV.Text = "Mã nhân viên";
            this.colMaNV.Width = 100;
            // 
            // colHoTen
            // 
            this.colHoTen.Text = "Họ tên";
            this.colHoTen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colHoTen.Width = 100;
            // 
            // colGioiTinh
            // 
            this.colGioiTinh.Text = "Giới tính";
            this.colGioiTinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colGioiTinh.Width = 100;
            // 
            // colNgaySinh
            // 
            this.colNgaySinh.Text = "Ngày sinh";
            this.colNgaySinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colNgaySinh.Width = 100;
            // 
            // colDiaChi
            // 
            this.colDiaChi.Text = "Địa chỉ";
            this.colDiaChi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colDiaChi.Width = 100;
            // 
            // colDanToc
            // 
            this.colDanToc.Text = "Dân tộc";
            this.colDanToc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colDanToc.Width = 100;
            // 
            // colQuocTich
            // 
            this.colQuocTich.Text = "Quốc tịch";
            this.colQuocTich.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colQuocTich.Width = 100;
            // 
            // colSoDienThoai
            // 
            this.colSoDienThoai.Text = "Số điện thoại";
            this.colSoDienThoai.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colSoDienThoai.Width = 100;
            // 
            // colMaPB
            // 
            this.colMaPB.Text = "Mã phòng ban";
            this.colMaPB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colMaPB.Width = 100;
            // 
            // colChucVu
            // 
            this.colChucVu.Text = "Chức vụ";
            this.colChucVu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colChucVu.Width = 100;
            // 
            // colMaTDHV
            // 
            this.colMaTDHV.Text = "Mã TĐHV";
            this.colMaTDHV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colMaTDHV.Width = 100;
            // 
            // colBacLuong
            // 
            this.colBacLuong.Text = "Bậc lương";
            this.colBacLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colBacLuong.Width = 100;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnInDanhSach);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 510);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(0, 0, 30, 3);
            this.groupBox3.Size = new System.Drawing.Size(1213, 51);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            // 
            // btnInDanhSach
            // 
            this.btnInDanhSach.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnInDanhSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInDanhSach.Image = global::QuanLyNhanSu.Properties.Resources.if_printer_16414;
            this.btnInDanhSach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInDanhSach.Location = new System.Drawing.Point(1065, 13);
            this.btnInDanhSach.Name = "btnInDanhSach";
            this.btnInDanhSach.Padding = new System.Windows.Forms.Padding(3);
            this.btnInDanhSach.Size = new System.Drawing.Size(118, 35);
            this.btnInDanhSach.TabIndex = 0;
            this.btnInDanhSach.Text = "In danh sách";
            this.btnInDanhSach.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInDanhSach.UseVisualStyleBackColor = true;
            // 
            // frmTK_DSNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 561);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmTK_DSNV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách tất cả nhân viên";
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView lsvNhanVien;
        private System.Windows.Forms.ColumnHeader colMaNV;
        private System.Windows.Forms.ColumnHeader colHoTen;
        private System.Windows.Forms.ColumnHeader colGioiTinh;
        private System.Windows.Forms.ColumnHeader colNgaySinh;
        private System.Windows.Forms.ColumnHeader colDiaChi;
        private System.Windows.Forms.ColumnHeader colDanToc;
        private System.Windows.Forms.ColumnHeader colQuocTich;
        private System.Windows.Forms.ColumnHeader colSoDienThoai;
        private System.Windows.Forms.ColumnHeader colMaPB;
        private System.Windows.Forms.ColumnHeader colChucVu;
        private System.Windows.Forms.ColumnHeader colMaTDHV;
        private System.Windows.Forms.ColumnHeader colBacLuong;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnInDanhSach;
    }
}