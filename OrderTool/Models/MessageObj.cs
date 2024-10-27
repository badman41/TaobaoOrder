using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OrderTool.Models
{
    public class MessageObj
    {
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("created_time")]
        public DateTime CreatedTime { get; set; }
        public string Message { get; set; } = string.Empty;
        public MessageFrom From { get; set; } = new();
    }

    public class MessageFrom
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
    }
}
