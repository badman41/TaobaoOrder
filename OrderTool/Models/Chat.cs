
namespace OrderTool.Models
{
    public class ChatConversation
    {
        public string ConversationId { get; set; } = string.Empty;
        public DateTime UpdatedTime { get; set; }
        public List<Chat> Chats { get; set; } = new List<Chat>();
    }

    public class Chat
    {
        public string ConversationId { get; set; } = string.Empty;
        public DateTime UpdatedTime { get; set; }
        public DateTime MessageCreatedDate { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ProductDetail { get; set; } = string.Empty;
        public Product Product { get; set; } = new();
        public string Note { get; set; } = string.Empty;
    }
    public class Product
    {
        public string Name { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
    }
}
