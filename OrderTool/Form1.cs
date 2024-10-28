using System.Data;

namespace OrderTool
{
    public partial class Form1 : Form
    {
        public FacebookClient Client { get; set; }
        public Form1()
        {
            InitializeComponent();
            Client = new FacebookClient();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
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
            //var columns = from t in conversations
            //              select new
            //              {
            //                  Id = t.Id,
            //                  UpdatedTime = t.UpdatedTime
            //              };

            var messages = await Client.getListMessage(conversations, fromDate, toDate);

            var columns = from t in messages
                          select new
                          {
                              CustomerName = t.From,
                              Phone = t.Phone,
                              Address = t.Message,
                              Date = t.MessageCreatedDate.ToShortDateString()
                          };

            this.dataGridView1.DataSource = columns.ToList();
            Cursor = Cursors.Arrow;
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
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
    }
}