using OfficeOpenXml;
using OfficeOpenXml.Style;
using OrderTool;
using OrderTool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SelectAll
{
    public partial class frmSelectAll : Form
    {
        int TotalCheckBoxes = 0;
        int TotalCheckedCheckBoxes = 0;
        CheckBox HeaderCheckBox = null;
        bool IsHeaderCheckBoxClicked = false;
        public FacebookClient Client { get; set; }
        public List<Chat> Chats { get; set; } = new List<Chat>();
        public Dictionary<string, bool> ChatSelecteds = new Dictionary<string, bool>();

        public frmSelectAll()
        {
            InitializeComponent();
            Client = new FacebookClient();
        }

        private void frmSelectAll_Load(object sender, EventArgs e)
        {
            AddHeaderCheckBox();

            HeaderCheckBox.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);
            HeaderCheckBox.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
            dgvSelectAll.CellValueChanged += new DataGridViewCellEventHandler(dgvSelectAll_CellValueChanged);
            dgvSelectAll.CurrentCellDirtyStateChanged += new EventHandler(dgvSelectAll_CurrentCellDirtyStateChanged);
            dgvSelectAll.CellPainting += new DataGridViewCellPaintingEventHandler(dgvSelectAll_CellPainting);

        }

        private async Task BindGridView()
        {
            await LoadData();
            dgvSelectAll.DataSource = await GetDataSource(Chats);
            AutoSelectAll();
        }


        private void dgvSelectAll_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!IsHeaderCheckBoxClicked)
            {
                var id = ((DataGridViewTextBoxCell)dgvSelectAll["Id", e.RowIndex]).Value.ToString();
                RowCheckBoxClick((DataGridViewCheckBoxCell)dgvSelectAll[e.ColumnIndex, e.RowIndex], id);
            }
        }

        private void dgvSelectAll_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvSelectAll.CurrentCell is DataGridViewCheckBoxCell)
                dgvSelectAll.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }

        private void HeaderCheckBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                HeaderCheckBoxClick((CheckBox)sender);
        }

        private void dgvSelectAll_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
                ResetHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex);
        }

        private void AddHeaderCheckBox()
        {
            HeaderCheckBox = new CheckBox();

            HeaderCheckBox.Size = new Size(15, 15);

            //Add the CheckBox into the DataGridView
            this.dgvSelectAll.Controls.Add(HeaderCheckBox);
        }

        private void ResetHeaderCheckBoxLocation(int ColumnIndex, int RowIndex)
        {
            //Get the column header cell bounds
            Rectangle oRectangle = this.dgvSelectAll.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

            Point oPoint = new Point();

            oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox.Height) / 2 + 1;

            //Change the location of the CheckBox to make it stay on the header
            HeaderCheckBox.Location = oPoint;
        }

        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            IsHeaderCheckBoxClicked = true;
            ChatSelecteds = new Dictionary<string, bool>();
            foreach (DataGridViewRow Row in dgvSelectAll.Rows)
            {
                ((DataGridViewCheckBoxCell)Row.Cells["chkBxSelect"]).Value = HCheckBox.Checked;
                if (HCheckBox.Checked)
                {
                    ChatSelecteds.Add(((DataGridViewTextBoxCell)Row.Cells["Id"]).Value.ToString()!, true);
                }
            }

            dgvSelectAll.RefreshEdit();

            TotalCheckedCheckBoxes = HCheckBox.Checked ? TotalCheckBoxes : 0;

            IsHeaderCheckBoxClicked = false;
        }

        private void RowCheckBoxClick(DataGridViewCheckBoxCell RCheckBox, string id)
        {
            if (RCheckBox != null)
            {
                //Modifiy Counter;            
                if ((bool)RCheckBox.Value)
                {
                    ChatSelecteds.Add(id, (bool)RCheckBox.Value);
                    if (TotalCheckedCheckBoxes < TotalCheckBoxes)
                    {
                        TotalCheckedCheckBoxes++;
                    }
                }
                else
                {
                    ChatSelecteds.Remove(id);
                    if (TotalCheckedCheckBoxes > 0)
                        TotalCheckedCheckBoxes--;
                }

                //Change state of the header CheckBox.
                if (TotalCheckedCheckBoxes < TotalCheckBoxes)
                    HeaderCheckBox.Checked = false;
                else if (TotalCheckedCheckBoxes == TotalCheckBoxes)
                    HeaderCheckBox.Checked = true;
            }
        }

        private void radioCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioCustom.Checked)
            {
                this.lblFrom.Enabled = true;
                this.lblTo.Enabled = true;
                this.dtFrom.Enabled = true;
                this.dtTo.Enabled = true;

                this.lblDays.Enabled = false;
                this.inputDay.Enabled = false;
            }
            else
            {
                this.lblFrom.Enabled = false;
                this.lblTo.Enabled = false;
                this.dtFrom.Enabled = false;
                this.dtTo.Enabled = false;

                this.lblDays.Enabled = true;
                this.inputDay.Enabled = true;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                await BindGridView();

                this.btnExport.Enabled = true;
                this.btnExportVtp.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor = Cursors.Arrow;
        }


        private async Task<DataTable> GetDataSource(List<Chat> chats)
        {
            DataTable dTable = new DataTable();

            DataRow dRow = null;
            DateTime dTime;
            Random rnd = new Random();

            dTable.Columns.Add("IsChecked", System.Type.GetType("System.Boolean"));
            dTable.Columns.Add("STT");
            dTable.Columns.Add("CustomerName");
            dTable.Columns.Add("ProductCode");
            dTable.Columns.Add("Size");
            dTable.Columns.Add("Price");
            dTable.Columns.Add("Phone");
            dTable.Columns.Add("Address");
            dTable.Columns.Add("CreatedTime");
            dTable.Columns.Add("Note");
            dTable.Columns.Add("Id");


            foreach (var message in chats)
            {
                dRow = dTable.NewRow();
                dTime = DateTime.Now;

                dRow["IsChecked"] = "false";
                dRow["STT"] = chats.IndexOf(message) + 1;
                dRow["CreatedTime"] = message.MessageCreatedDate.ToString("dd/MM/yyyy HH:mm");
                dRow["CustomerName"] = message.CustomerName;
                dRow["ProductCode"] = message.Product.Name;
                dRow["Size"] = message.Product.Size;
                dRow["Price"] = message.Product.Price;
                dRow["Phone"] = message.Phone;
                dRow["Address"] = message.Address;
                dRow["Note"] = message.Note;
                dRow["Id"] = message.ConversationId;

                dTable.Rows.Add(dRow);
                dTable.AcceptChanges();
            }

            return dTable;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                    // Set the header
                    worksheet.Cells[1, 1].Value = "Ngày tạo";
                    worksheet.Cells[1, 2].Value = "Tên khách hàng";
                    worksheet.Cells[1, 3].Value = "Tên sản phẩm";
                    worksheet.Cells[1, 4].Value = "Size";
                    worksheet.Cells[1, 5].Value = "Giá";
                    worksheet.Cells[1, 6].Value = "SĐT";
                    worksheet.Cells[1, 7].Value = "Địa chỉ";
                    worksheet.Cells[1, 8].Value = "Ghi chú";

                    // Style the header
                    using (var headerRange = worksheet.Cells[1, 1, 1, 8]) // Range for the header
                    {
                        headerRange.Style.Font.Bold = true; // Bold text
                        headerRange.Style.Font.Size = 12; // Font size
                        headerRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        headerRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue); // Background color

                        // Set borders
                        headerRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        headerRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        headerRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        headerRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;

                        // Center align the text
                        headerRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    }
                    var chatSelecteds = Chats;
                    if (TotalCheckedCheckBoxes < TotalCheckBoxes)
                    {
                        chatSelecteds = Chats.Where(x => ChatSelecteds.ContainsKey(x.ConversationId)).ToList();
                    }
                    chatSelecteds.Reverse();
                    // Fill the data
                    for (int i = 0; i < chatSelecteds.Count; i++)
                    {
                        worksheet.Cells[i + 2, 1].Value = chatSelecteds[i].MessageCreatedDate.ToString("dd/MM/yyyy HH:mm");
                        worksheet.Cells[i + 2, 2].Value = chatSelecteds[i].CustomerName;
                        worksheet.Cells[i + 2, 3].Value = chatSelecteds[i].Product.Name;
                        worksheet.Cells[i + 2, 4].Value = chatSelecteds[i].Product.Size;
                        worksheet.Cells[i + 2, 5].Value = chatSelecteds[i].Product.Price;
                        worksheet.Cells[i + 2, 6].Value = chatSelecteds[i].Phone;
                        worksheet.Cells[i + 2, 7].Value = chatSelecteds[i].Address;
                        worksheet.Cells[i + 2, 8].Value = chatSelecteds[i].Note;
                    }

                    // Auto-fit columns
                    worksheet.Cells.AutoFitColumns();


                    using (var saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel Files|*.xlsx";
                        saveFileDialog.Title = "Save an Excel File";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            var excelFile = new FileInfo(saveFileDialog.FileName);
                            package.SaveAs(excelFile);
                            MessageBox.Show("Export successful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor = Cursors.Arrow;
        }

        private void btnExportVtp_Click(object sender, EventArgs e)
        {
            try
            {
                var templateFileInfo = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Template", "vpt_template.xlsx"));
                using var package = new ExcelPackage(templateFileInfo);
                ExcelWorksheet wsEstimate = package.Workbook.Worksheets["Danh sách"];
                var chatSelecteds = Chats;
                if (TotalCheckedCheckBoxes < TotalCheckBoxes)
                {
                    chatSelecteds = Chats.Where(x => ChatSelecteds.ContainsKey(x.ConversationId)).ToList();
                }

                // Fill the data
                for (int i = 0; i < chatSelecteds.Count; i++)
                {
                    var index = i + 8;
                    wsEstimate.Cells[$"C{index}"].Value = chatSelecteds[i].CustomerName;
                    wsEstimate.Cells[$"D{index}"].Value = chatSelecteds[i].Phone;
                    wsEstimate.Cells[$"E{index}"].Value = chatSelecteds[i].Address;
                    wsEstimate.Cells[$"F{index}"].Value = $"{chatSelecteds[i].Product.Name}-{chatSelecteds[i].Product.Size}";
                    wsEstimate.Cells[$"G{index}"].Value = 1;
                    wsEstimate.Cells[$"H{index}"].Value = 400;
                    wsEstimate.Cells[$"I{index}"].Value = double.Parse(chatSelecteds[i].Product.Price.Replace(".", "").Trim());
                    wsEstimate.Cells[$"J{index}"].Value = double.Parse(chatSelecteds[i].Product.Price.Replace(".", "").Trim());
                    wsEstimate.Cells[$"K{index}"].Value = "Bưu kiện";
                    wsEstimate.Cells[$"M{index}"].Value = "LCOD - Chuyển phát tiết kiệm";
                    wsEstimate.Cells[$"N{index}"].Value = "XMG";
                    wsEstimate.Cells[$"O{index}"].Value = 35000;
                    wsEstimate.Cells[$"S{index}"].Value = "Người nhận trả";
                    wsEstimate.Cells[$"T{index}"].Value = chatSelecteds[i].Note;
                }

                using var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Save an Excel File";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var excelFile = new FileInfo(saveFileDialog.FileName);
                    package.SaveAs(excelFile);
                    MessageBox.Show("Export successful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            var input = textBox1.Text;
            if (string.IsNullOrEmpty(input))
            {
                dgvSelectAll.DataSource = await GetDataSource(Chats);
                AutoSelectAll();
                return;
            }
            var chatSearched = Chats.Where(x => x.Message.Contains(input) || x.CustomerName.Contains(input));
            if (chatSearched.Any())
            {
                dgvSelectAll.DataSource = await GetDataSource(chatSearched.ToList());
                AutoSelectAll();
            }
        }

        private async Task LoadData()
        {
            var toDate = DateTime.Now;
            var fromDate = DateTime.Now.Date;

            if (radioLast.Checked)
            {
                fromDate = toDate.AddDays(-(int)inputDay.Value).Date;
            }
            else
            {
                fromDate = dtFrom.Value.Date;
                toDate = dtTo.Value.AddDays(1).Date.AddTicks(-1);
            }

            var conversations = await Client.getListConversation(fromDate, toDate);

            Chats = await Client.getListMessage(conversations, fromDate, toDate);
        }

        private void AutoSelectAll()
        {
            HeaderCheckBox.Checked = true;
            HeaderCheckBoxClick(HeaderCheckBox);
            TotalCheckBoxes = dgvSelectAll.RowCount;
            TotalCheckedCheckBoxes = 0;
        }
    }
}
