namespace QuanLyNhanSu.GUI
{
    partial class frmTK_NV_KT_KL
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnXong = new System.Windows.Forms.Button();
            this.txtKeyValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lsvDanhSach = new System.Windows.Forms.ListView();
            this.colMaNV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTenNV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSoQD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLyDo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHinhThuc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colThoiGian = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnInDanhSach = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.btnXong);
            this.groupBox1.Controls.Add(this.txtKeyValue);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(784, 58);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Mã nhân viên",
            "Hình thức"});
            this.comboBox1.Location = new System.Drawing.Point(141, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // btnXong
            // 
            this.btnXong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXong.Image = global::QuanLyNhanSu.Properties.Resources.Symbol_Check;
            this.btnXong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXong.Location = new System.Drawing.Point(588, 13);
            this.btnXong.Name = "btnXong";
            this.btnXong.Size = new System.Drawing.Size(77, 35);
            this.btnXong.TabIndex = 2;
            this.btnXong.Text = "Xong";
            this.btnXong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXong.UseVisualStyleBackColor = true;
            // 
            // txtKeyValue
            // 
            this.txtKeyValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKeyValue.Location = new System.Drawing.Point(266, 17);
            this.txtKeyValue.Multiline = true;
            this.txtKeyValue.Name = "txtKeyValue";
            this.txtKeyValue.Size = new System.Drawing.Size(315, 26);
            this.txtKeyValue.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thống kê theo";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lsvDanhSach);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 58);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox2.Size = new System.Drawing.Size(784, 503);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách";
            // 
            // lsvDanhSach
            // 
            this.lsvDanhSach.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMaNV,
            this.colTenNV,
            this.colSoQD,
            this.colLyDo,
            this.colHinhThuc,
            this.colThoiGian});
            this.lsvDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvDanhSach.Location = new System.Drawing.Point(3, 25);
            this.lsvDanhSach.Name = "lsvDanhSach";
            this.lsvDanhSach.Size = new System.Drawing.Size(778, 475);
            this.lsvDanhSach.TabIndex = 0;
            this.lsvDanhSach.UseCompatibleStateImageBehavior = false;
            this.lsvDanhSach.View = System.Windows.Forms.View.Details;
            // 
            // colMaNV
            // 
            this.colMaNV.Text = "Mã nhân viên";
            this.colMaNV.Width = 120;
            // 
            // colTenNV
            // 
            this.colTenNV.Text = "Tên nhân viên";
            this.colTenNV.Width = 126;
            // 
            // colSoQD
            // 
            this.colSoQD.Text = "Số QĐ khen thưởng - kỷ luật";
            this.colSoQD.Width = 187;
            // 
            // colLyDo
            // 
            this.colLyDo.Text = "Lý do";
            this.colLyDo.Width = 119;
            // 
            // colHinhThuc
            // 
            this.colHinhThuc.Text = "Hình thức";
            this.colHinhThuc.Width = 115;
            // 
            // colThoiGian
            // 
            this.colThoiGian.Text = "Thời gian";
            this.colThoiGian.Width = 106;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnInDanhSach);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 510);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(0, 0, 30, 3);
            this.groupBox3.Size = new System.Drawing.Size(784, 51);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // btnInDanhSach
            // 
            this.btnInDanhSach.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnInDanhSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInDanhSach.Image = global::QuanLyNhanSu.Properties.Resources.if_printer_16414;
            this.btnInDanhSach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInDanhSach.Location = new System.Drawing.Point(636, 13);
            this.btnInDanhSach.Name = "btnInDanhSach";
            this.btnInDanhSach.Padding = new System.Windows.Forms.Padding(3);
            this.btnInDanhSach.Size = new System.Drawing.Size(118, 35);
            this.btnInDanhSach.TabIndex = 0;
            this.btnInDanhSach.Text = "In danh sách";
            this.btnInDanhSach.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInDanhSach.UseVisualStyleBackColor = true;
            // 
            // frmTK_NV_KT_KL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmTK_NV_KT_KL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhân viên - Khen thưởng - Kr luật";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnXong;
        private System.Windows.Forms.TextBox txtKeyValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lsvDanhSach;
        private System.Windows.Forms.ColumnHeader colMaNV;
        private System.Windows.Forms.ColumnHeader colTenNV;
        private System.Windows.Forms.ColumnHeader colSoQD;
        private System.Windows.Forms.ColumnHeader colLyDo;
        private System.Windows.Forms.ColumnHeader colHinhThuc;
        private System.Windows.Forms.ColumnHeader colThoiGian;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnInDanhSach;
    }
}