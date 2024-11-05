using System.Windows.Forms;

namespace SelectAll
{
    partial class frmSelectAll
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectAll));
            dgvSelectAll = new DataGridView();
            button1 = new Button();
            groupBox1 = new GroupBox();
            radioLast = new RadioButton();
            radioCustom = new RadioButton();
            lblTo = new Label();
            lblFrom = new Label();
            dtTo = new DateTimePicker();
            dtFrom = new DateTimePicker();
            lblDays = new Label();
            inputDay = new NumericUpDown();
            btnExport = new Button();
            btnExportVtp = new Button();
            textBox1 = new TextBox();
            chkBxSelect = new DataGridViewCheckBoxColumn();
            STT = new DataGridViewTextBoxColumn();
            txtCreatedTime = new DataGridViewTextBoxColumn();
            txtCustomerName = new DataGridViewTextBoxColumn();
            txtProductCode = new DataGridViewTextBoxColumn();
            Size = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            txtPhone = new DataGridViewTextBoxColumn();
            txtAddress = new DataGridViewTextBoxColumn();
            txtNote = new DataGridViewTextBoxColumn();
            Id = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvSelectAll).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)inputDay).BeginInit();
            SuspendLayout();
            // 
            // dgvSelectAll
            // 
            dgvSelectAll.AllowUserToAddRows = false;
            dgvSelectAll.AllowUserToDeleteRows = false;
            dgvSelectAll.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvSelectAll.BackgroundColor = Color.WhiteSmoke;
            dgvSelectAll.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.IndianRed;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = Color.IndianRed;
            dataGridViewCellStyle1.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSelectAll.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSelectAll.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSelectAll.Columns.AddRange(new DataGridViewColumn[] { chkBxSelect, STT, txtCreatedTime, txtCustomerName, txtProductCode, Size, Price, txtPhone, txtAddress, txtNote, Id });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.IndianRed;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = Color.White;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvSelectAll.DefaultCellStyle = dataGridViewCellStyle6;
            dgvSelectAll.GridColor = Color.Maroon;
            dgvSelectAll.Location = new Point(13, 188);
            dgvSelectAll.Margin = new Padding(4, 3, 4, 3);
            dgvSelectAll.Name = "dgvSelectAll";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.IndianRed;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = Color.IndianRed;
            dataGridViewCellStyle7.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvSelectAll.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.BackColor = Color.Snow;
            dataGridViewCellStyle8.SelectionBackColor = Color.Salmon;
            dgvSelectAll.RowsDefaultCellStyle = dataGridViewCellStyle8;
            dgvSelectAll.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvSelectAll.Size = new Size(1323, 506);
            dgvSelectAll.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.Yellow;
            button1.Location = new Point(12, 147);
            button1.Name = "button1";
            button1.Size = new Size(153, 35);
            button1.TabIndex = 0;
            button1.Text = "Lấy danh sách đơn hàng";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioLast);
            groupBox1.Controls.Add(radioCustom);
            groupBox1.Controls.Add(lblTo);
            groupBox1.Controls.Add(lblFrom);
            groupBox1.Controls.Add(dtTo);
            groupBox1.Controls.Add(dtFrom);
            groupBox1.Controls.Add(lblDays);
            groupBox1.Controls.Add(inputDay);
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.Location = new Point(12, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1324, 87);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Lọc";
            // 
            // radioLast
            // 
            radioLast.AutoSize = true;
            radioLast.Checked = true;
            radioLast.Location = new Point(24, 36);
            radioLast.Name = "radioLast";
            radioLast.Size = new Size(46, 19);
            radioLast.TabIndex = 8;
            radioLast.TabStop = true;
            radioLast.Text = "Last";
            radioLast.UseVisualStyleBackColor = true;
            // 
            // radioCustom
            // 
            radioCustom.AutoSize = true;
            radioCustom.Location = new Point(217, 35);
            radioCustom.Name = "radioCustom";
            radioCustom.Size = new Size(67, 19);
            radioCustom.TabIndex = 7;
            radioCustom.Text = "Custom";
            radioCustom.UseVisualStyleBackColor = true;
            radioCustom.CheckedChanged += radioCustom_CheckedChanged;
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Enabled = false;
            lblTo.Location = new Point(493, 37);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(22, 15);
            lblTo.TabIndex = 6;
            lblTo.Text = "To:";
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Enabled = false;
            lblFrom.Location = new Point(302, 37);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(38, 15);
            lblFrom.TabIndex = 5;
            lblFrom.Text = "From:";
            // 
            // dtTo
            // 
            dtTo.Enabled = false;
            dtTo.Format = DateTimePickerFormat.Short;
            dtTo.Location = new Point(525, 33);
            dtTo.Name = "dtTo";
            dtTo.Size = new Size(123, 23);
            dtTo.TabIndex = 4;
            // 
            // dtFrom
            // 
            dtFrom.Enabled = false;
            dtFrom.Format = DateTimePickerFormat.Short;
            dtFrom.Location = new Point(348, 33);
            dtFrom.Name = "dtFrom";
            dtFrom.Size = new Size(123, 23);
            dtFrom.TabIndex = 3;
            // 
            // lblDays
            // 
            lblDays.AutoSize = true;
            lblDays.Location = new Point(122, 38);
            lblDays.Name = "lblDays";
            lblDays.Size = new Size(31, 15);
            lblDays.TabIndex = 2;
            lblDays.Text = "days";
            // 
            // inputDay
            // 
            inputDay.Location = new Point(76, 36);
            inputDay.Name = "inputDay";
            inputDay.Size = new Size(40, 23);
            inputDay.TabIndex = 0;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(0, 192, 0);
            btnExport.Enabled = false;
            btnExport.Location = new Point(173, 147);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(169, 35);
            btnExport.TabIndex = 3;
            btnExport.Text = "Export danh sách đơn hàng";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnExportVtp
            // 
            btnExportVtp.BackColor = Color.FromArgb(192, 0, 0);
            btnExportVtp.Enabled = false;
            btnExportVtp.ForeColor = SystemColors.ButtonHighlight;
            btnExportVtp.Location = new Point(348, 147);
            btnExportVtp.Name = "btnExportVtp";
            btnExportVtp.Size = new Size(146, 35);
            btnExportVtp.TabIndex = 4;
            btnExportVtp.Text = "Export to ViettelPost";
            btnExportVtp.UseVisualStyleBackColor = false;
            btnExportVtp.Click += btnExportVtp_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1134, 159);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Search...";
            textBox1.Size = new Size(203, 23);
            textBox1.TabIndex = 9;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // chkBxSelect
            // 
            chkBxSelect.DataPropertyName = "IsChecked";
            chkBxSelect.HeaderText = "";
            chkBxSelect.Name = "chkBxSelect";
            chkBxSelect.Width = 50;
            // 
            // STT
            // 
            STT.DataPropertyName = "STT";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            STT.DefaultCellStyle = dataGridViewCellStyle2;
            STT.HeaderText = "STT";
            STT.Name = "STT";
            STT.Width = 40;
            // 
            // txtCreatedTime
            // 
            txtCreatedTime.DataPropertyName = "CreatedTime";
            txtCreatedTime.HeaderText = "Thời gian";
            txtCreatedTime.Name = "txtCreatedTime";
            txtCreatedTime.Width = 150;
            // 
            // txtCustomerName
            // 
            txtCustomerName.DataPropertyName = "CustomerName";
            txtCustomerName.HeaderText = "Tên khách hàng";
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.ReadOnly = true;
            txtCustomerName.Width = 150;
            // 
            // txtProductCode
            // 
            txtProductCode.DataPropertyName = "ProductCode";
            txtProductCode.HeaderText = "Mã hàng hóa";
            txtProductCode.Name = "txtProductCode";
            txtProductCode.ReadOnly = true;
            // 
            // Size
            // 
            Size.DataPropertyName = "Size";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Size.DefaultCellStyle = dataGridViewCellStyle3;
            Size.HeaderText = "Size";
            Size.Name = "Size";
            Size.Width = 50;
            // 
            // Price
            // 
            Price.DataPropertyName = "Price";
            Price.HeaderText = "Giá";
            Price.Name = "Price";
            Price.Width = 70;
            // 
            // txtPhone
            // 
            txtPhone.DataPropertyName = "Phone";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            txtPhone.DefaultCellStyle = dataGridViewCellStyle4;
            txtPhone.HeaderText = "Số điện thoại";
            txtPhone.Name = "txtPhone";
            txtPhone.ReadOnly = true;
            txtPhone.Width = 120;
            // 
            // txtAddress
            // 
            txtAddress.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            txtAddress.DataPropertyName = "Address";
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            txtAddress.DefaultCellStyle = dataGridViewCellStyle5;
            txtAddress.HeaderText = "Địa chỉ";
            txtAddress.Name = "txtAddress";
            txtAddress.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // txtNote
            // 
            txtNote.DataPropertyName = "Note";
            txtNote.HeaderText = "Ghi chú";
            txtNote.Name = "txtNote";
            txtNote.Width = 200;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.Visible = false;
            // 
            // frmSelectAll
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(1349, 706);
            Controls.Add(textBox1);
            Controls.Add(btnExportVtp);
            Controls.Add(btnExport);
            Controls.Add(dgvSelectAll);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmSelectAll";
            Text = "Chan Store Order";
            Load += frmSelectAll_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSelectAll).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)inputDay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvSelectAll;

        private Button button1;
        private GroupBox groupBox1;
        private Label lblFilter;
        private NumericUpDown inputDay;
        private RadioButton radioCustom;
        private Label lblTo;
        private Label lblFrom;
        private DateTimePicker dtTo;
        private DateTimePicker dtFrom;
        private Label lblDays;
        private RadioButton radioLast;
        private Button btnExport;
        private Button btnExportVtp;
        private TextBox textBox1;
        private DataGridViewCheckBoxColumn chkBxSelect;
        private DataGridViewTextBoxColumn STT;
        private DataGridViewTextBoxColumn txtCreatedTime;
        private DataGridViewTextBoxColumn txtCustomerName;
        private DataGridViewTextBoxColumn txtProductCode;
        private DataGridViewTextBoxColumn Size;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn txtPhone;
        private DataGridViewTextBoxColumn txtAddress;
        private DataGridViewTextBoxColumn txtNote;
        private DataGridViewTextBoxColumn Id;
    }
}

