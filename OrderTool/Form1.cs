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
            var conversations = await Client.getListConversation();
            var messages = await Client.getListMessage(conversations.Data);

            var columns = from t in messages
                          select new
                          {
                              CustomerName = t.From,
                              Phone = t.Phone,
                              Address = t.Message
                          };

            this.dataGridView1.DataSource = columns.ToList();
            ;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}