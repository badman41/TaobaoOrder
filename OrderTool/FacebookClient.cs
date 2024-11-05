using Microsoft.VisualBasic;
using Newtonsoft.Json;
using OrderTool.Models;

namespace OrderTool
{
    public class FacebookClient
    {
        public HttpClient HttpClient { get; set; }

        public const int LIMiT = 200;
        public const string PAGE_ID = "411613095848376";
        public const string ACCESS_TOKEN = "EAAIjQtDKHq4BOxgyPKawZBnkuC5drkrVLS0jvyfJlbGOoBOnpLdeZAkv219TZBZCAQg8ykheNLzyytbyuyJ4yOeb81tOGiWDMRAIuFwNJ9UNru4ktPRG6nFRZBfLA0YKxSOTjDX1z0FKdhCdj76UJ4X0b9bY8lhcWVTpt0Jw8vYsJJEAE0mxzJfqd2Rb9XY6r";
        public const string MESSAGE_ORDERED = "Dạ shop xin xác nhận lại đơn hàng của mình nha";


        public FacebookClient()
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri("https://graph.facebook.com/v21.0");
        }

        public async Task<List<Conversation>> getListConversation(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var result = new List<Conversation>();
                var url = $"{HttpClient.BaseAddress}/{PAGE_ID}/conversations?platform=messenger&access_token={ACCESS_TOKEN}&fields=updated_time,messages.fields(message, to, created_time).limit(100)&limit(100)";

                while (result.Count == 0 || result[result.Count - 1].UpdatedTime > fromDate)
                {
                    var httpResponse = await HttpClient.GetAsync(url);
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    var conversationResponse = JsonConvert.DeserializeObject<ConversationResponse>(content);
                    result.AddRange(conversationResponse!.Data);
                    url = conversationResponse.Paging.Next;
                }

                return result.Where(x => x.UpdatedTime >= fromDate).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Chat>> getListMessage(List<Conversation> conversations, DateTime fromDate, DateTime toDate)
        {
            List<Chat> result = new List<Chat>();

            foreach (var conversation in conversations)
            {
                var doneMessage = conversation.Messages.Data.FirstOrDefault(x => x.Message.Contains(MESSAGE_ORDERED) && x.CreatedTime >= fromDate && x.CreatedTime <= toDate);
                if (doneMessage is not null)
                {
                    var chat = findOrderInfo(doneMessage.Message);
                    chat.ConversationId = conversation.Id;
                    chat.MessageCreatedDate = doneMessage.CreatedTime;
                    chat.CustomerName = doneMessage.To.Data.FirstOrDefault()?.Name ?? "";
                    result.Add(chat);
                } 
                
            }


            return result;
        }
        private Chat findOrderInfo(string input)
        {
            const string productKey = "- Mẫu:";
            const string phoneKey = "- SĐT:";
            const string addressKey = "- Địa chỉ nhận hàng:";
            const string noteKey = "*";
            const string endKey = "Hàng shop chuyển từ Quảng Châu";

            int productKeyIndex = input.IndexOf(productKey);
            int phoneKeyIndex = input.IndexOf(phoneKey);
            int addressKeyIndex = input.IndexOf(addressKey);
            int noteKeyIndex = input.IndexOf(noteKey);
            int endKeyIndex = input.IndexOf(endKey);

            var productDetail = input.Substring(productKeyIndex + productKey.Length + 1, phoneKeyIndex - (productKeyIndex + productKey.Length) - 2);
            var productObj = productDetail.Split('-');
            var noteLength = endKeyIndex -(noteKeyIndex + noteKey.Length) - 1;
            return new Chat()
            {
                Message = input,
                ProductDetail = productDetail,
                Phone = input.Substring(phoneKeyIndex + phoneKey.Length + 1, addressKeyIndex - (phoneKeyIndex + phoneKey.Length) - 2),
                Address = input.Substring(addressKeyIndex + addressKey.Length + 1, (noteKeyIndex > 0 ? noteKeyIndex : endKeyIndex) - (addressKeyIndex + addressKey.Length) - 2),
                Note = noteKeyIndex > 0 && noteLength > 0 ? input.Substring(noteKeyIndex + noteKey.Length, noteLength) : "",
                Product = new Product()
                {
                    Name = productObj[0],
                    Size = productObj[1] ?? "",
                    Price = productObj[2] ?? "0",
                }
            };
        }
    }


}
