using OfficeOpenXml;
using OfficeOpenXml.Style;
using OrderTool;
using OrderTool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public List<Chat> Chats { get; set; }
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
            dgvSelectAll.DataSource = await GetDataSource();

            TotalCheckBoxes = dgvSelectAll.RowCount;
            TotalCheckedCheckBoxes = 0;
        }

        private async Task<DataTable> GetDataSource()
        {
            DataTable dTable = new DataTable();

            DataRow dRow = null;
            DateTime dTime;
            Random rnd = new Random();

            dTable.Columns.Add("IsChecked", System.Type.GetType("System.Boolean"));
            dTable.Columns.Add("CustomerName");
            dTable.Columns.Add("ProductCode");
            dTable.Columns.Add("Phone");
            dTable.Columns.Add("Address");
            dTable.Columns.Add("CreatedTime");
            dTable.Columns.Add("Note");
            dTable.Columns.Add("Id");

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
            foreach (var message in Chats)
            {
                dRow = dTable.NewRow();
                dTime = DateTime.Now;

                dRow["IsChecked"] = "false";
                dRow["CreatedTime"] = message.MessageCreatedDate.ToString("dd/MM/yyyy HH:mm");
                dRow["CustomerName"] = message.From;
                dRow["ProductCode"] = message.Phone;
                dRow["Phone"] = message.Phone;
                dRow["Address"] = message.Message;
                dRow["Note"] = message.Phone;
                dRow["Id"] = message.ConversationId;

                dTable.Rows.Add(dRow);
                dTable.AcceptChanges();
            }

            return dTable;
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

            foreach (DataGridViewRow Row in dgvSelectAll.Rows)
                ((DataGridViewCheckBoxCell)Row.Cells["chkBxSelect"]).Value = HCheckBox.Checked;

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
                else if (TotalCheckedCheckBoxes > 0)
                {
                    ChatSelecteds.Remove(id);
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

            await BindGridView();

            //HeaderCheckBox.Checked = true;
            //HeaderCheckBoxClick(HeaderCheckBox);
            this.btnExport.Enabled = true;
            Cursor = Cursors.Arrow;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Set the header
                worksheet.Cells[1, 1].Value = "CreatedTime";
                worksheet.Cells[1, 2].Value = "CustomerName";
                worksheet.Cells[1, 3].Value = "ProductCode";
                worksheet.Cells[1, 4].Value = "Phone";
                worksheet.Cells[1, 5].Value = "Address";
                worksheet.Cells[1, 6].Value = "Note";

                // Style the header
                using (var headerRange = worksheet.Cells[1, 1, 1, 6]) // Range for the header
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

                // Fill the data
                for (int i = 0; i < chatSelecteds.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = chatSelecteds[i].MessageCreatedDate.ToString("dd/MM/yyyy HH:mm");
                    worksheet.Cells[i + 2, 2].Value = chatSelecteds[i].From;
                    worksheet.Cells[i + 2, 3].Value = chatSelecteds[i].Phone;
                    worksheet.Cells[i + 2, 4].Value = chatSelecteds[i].Phone;
                    worksheet.Cells[i + 2, 5].Value = chatSelecteds[i].Message;
                    worksheet.Cells[i + 2, 6].Value = chatSelecteds[i].Phone;
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
            Cursor = Cursors.Arrow;
        }
    }
}
