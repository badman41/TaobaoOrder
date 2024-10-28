using Newtonsoft.Json;

namespace OrderTool.Models
{
    public class MessageObj
    {
        public string Id { get; set; } = string.Empty;

        [JsonProperty("created_time")]
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
