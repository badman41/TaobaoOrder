﻿using System.Windows.Forms;

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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
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
            chkBxSelect = new DataGridViewCheckBoxColumn();
            txtCreatedTime = new DataGridViewTextBoxColumn();
            txtCustomerName = new DataGridViewTextBoxColumn();
            txtProductCode = new DataGridViewTextBoxColumn();
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
            dgvSelectAll.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSelectAll.Columns.AddRange(new DataGridViewColumn[] { chkBxSelect, txtCreatedTime, txtCustomerName, txtProductCode, txtPhone, txtAddress, txtNote, Id });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvSelectAll.DefaultCellStyle = dataGridViewCellStyle2;
            dgvSelectAll.Location = new Point(13, 253);
            dgvSelectAll.Margin = new Padding(4, 3, 4, 3);
            dgvSelectAll.Name = "dgvSelectAll";
            dgvSelectAll.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvSelectAll.Size = new Size(1134, 441);
            dgvSelectAll.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.Yellow;
            button1.Location = new Point(12, 205);
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
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1135, 187);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Lọc";
            // 
            // radioLast
            // 
            radioLast.AutoSize = true;
            radioLast.Checked = true;
            radioLast.Location = new Point(24, 22);
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
            radioCustom.Location = new Point(24, 75);
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
            lblTo.Location = new Point(44, 147);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(22, 15);
            lblTo.TabIndex = 6;
            lblTo.Text = "To:";
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Enabled = false;
            lblFrom.Location = new Point(30, 104);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(38, 15);
            lblFrom.TabIndex = 5;
            lblFrom.Text = "From:";
            // 
            // dtTo
            // 
            dtTo.Enabled = false;
            dtTo.Format = DateTimePickerFormat.Short;
            dtTo.Location = new Point(76, 143);
            dtTo.Name = "dtTo";
            dtTo.Size = new Size(123, 23);
            dtTo.TabIndex = 4;
            // 
            // dtFrom
            // 
            dtFrom.Enabled = false;
            dtFrom.Format = DateTimePickerFormat.Short;
            dtFrom.Location = new Point(76, 100);
            dtFrom.Name = "dtFrom";
            dtFrom.Size = new Size(123, 23);
            dtFrom.TabIndex = 3;
            // 
            // lblDays
            // 
            lblDays.AutoSize = true;
            lblDays.Location = new Point(122, 24);
            lblDays.Name = "lblDays";
            lblDays.Size = new Size(31, 15);
            lblDays.TabIndex = 2;
            lblDays.Text = "days";
            // 
            // inputDay
            // 
            inputDay.Location = new Point(76, 19);
            inputDay.Name = "inputDay";
            inputDay.Size = new Size(40, 23);
            inputDay.TabIndex = 0;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(0, 192, 0);
            btnExport.Enabled = false;
            btnExport.Location = new Point(173, 205);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(88, 35);
            btnExport.TabIndex = 3;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // chkBxSelect
            // 
            chkBxSelect.DataPropertyName = "IsChecked";
            chkBxSelect.HeaderText = "";
            chkBxSelect.Name = "chkBxSelect";
            chkBxSelect.Width = 50;
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
            txtProductCode.Width = 120;
            // 
            // txtPhone
            // 
            txtPhone.DataPropertyName = "Phone";
            txtPhone.HeaderText = "Số điện thoại";
            txtPhone.Name = "txtPhone";
            txtPhone.ReadOnly = true;
            txtPhone.Width = 120;
            // 
            // txtAddress
            // 
            txtAddress.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            txtAddress.DataPropertyName = "Address";
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            txtAddress.DefaultCellStyle = dataGridViewCellStyle1;
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
            // 
            // frmSelectAll
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1160, 706);
            Controls.Add(btnExport);
            Controls.Add(dgvSelectAll);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmSelectAll";
            Text = "Select All Demo";
            Load += frmSelectAll_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSelectAll).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)inputDay).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSelectAll;

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
        private DataGridViewCheckBoxColumn chkBxSelect;
        private DataGridViewTextBoxColumn txtCreatedTime;
        private DataGridViewTextBoxColumn txtCustomerName;
        private DataGridViewTextBoxColumn txtProductCode;
        private DataGridViewTextBoxColumn txtPhone;
        private DataGridViewTextBoxColumn txtAddress;
        private DataGridViewTextBoxColumn txtNote;
        private DataGridViewTextBoxColumn Id;
    }
}
