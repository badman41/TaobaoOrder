namespace OrderTool
{
    partial class Form1
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
            button1 = new Button();
            dataGridView1 = new DataGridView();
            groupBox1 = new GroupBox();
            radioLast = new RadioButton();
            radioCustom = new RadioButton();
            lblTo = new Label();
            lblFrom = new Label();
            dtTo = new DateTimePicker();
            dtFrom = new DateTimePicker();
            lblDays = new Label();
            inputDay = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)inputDay).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 205);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Export";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 243);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1040, 622);
            dataGridView1.TabIndex = 1;
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
            groupBox1.Size = new Size(1016, 187);
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
            radioCustom.CheckedChanged += radioButton1_CheckedChanged;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 877);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)inputDay).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private DataGridView dataGridView1;
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
    }
}