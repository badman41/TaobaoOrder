using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OrderTool.Models
{
    public class ConversationResponse
    {
        public List<Conversation> Data { get; set; }
        public Paging Paging { get; set; }
    }

    public class Conversation
    {
        [JsonProperty("updated_time")]
        public DateTime UpdatedTime { get; set; }
        public string Id { get; set; }
        public ConversationMessage Messages { get; set; } = new();
    }

    public class ConversationMessage
    {
        public List<MessageObj> Data { get; set; }
    }

    public class Paging
    {
        public string Next { get; set; } = string.Empty;
    }
}
