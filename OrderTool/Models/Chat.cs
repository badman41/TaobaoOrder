
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
        public string From { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
