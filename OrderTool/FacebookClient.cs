using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OrderTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderTool
{
    public class FacebookClient
    {
        public HttpClient HttpClient { get; set; }

        public const int LIMiT = 200;
        public const string PAGE_ID = "411613095848376";
        public const string ACCESS_TOKEN = "EAAIjQtDKHq4BOxgyPKawZBnkuC5drkrVLS0jvyfJlbGOoBOnpLdeZAkv219TZBZCAQg8ykheNLzyytbyuyJ4yOeb81tOGiWDMRAIuFwNJ9UNru4ktPRG6nFRZBfLA0YKxSOTjDX1z0FKdhCdj76UJ4X0b9bY8lhcWVTpt0Jw8vYsJJEAE0mxzJfqd2Rb9XY6r";



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
                var url = $"{HttpClient.BaseAddress}/{PAGE_ID}/conversations?platform=messenger&access_token={ACCESS_TOKEN}&fields=updated_time,messages.fields(message, from, created_time).limit(1000)&limit(100)";

                while (result.Count == 0 || result[result.Count - 1].UpdatedTime > fromDate)
                {
                    var httpResponse = await HttpClient.GetAsync(url);
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    var conversationResponse = JsonConvert.DeserializeObject<ConversationResponse>(content);
                    result.AddRange(conversationResponse!.Data);
                    url = conversationResponse.Paging.Next;
                }

                return result.Where(x => x.UpdatedTime >= fromDate && x.UpdatedTime <= toDate).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Chat>> getListMessage(List<Conversation> conversations, DateTime fromDate, DateTime toDate)
        {
            List<Chat> result = new List<Chat>();

            var lstOrdered = conversations.Where(x => x.Messages.Data.Any(x => x.Message.Contains("đã đặt hàng") && x.CreatedTime >= fromDate && x.CreatedTime <= toDate));
            foreach (var conversation in lstOrdered)
            {
                var doneMessage = conversation.Messages.Data.FirstOrDefault(x => !string.IsNullOrEmpty(findPhone(x.Message)));
                if (doneMessage is not null)
                {
                    var chat = new Chat()
                    {
                        ConversationId = conversation.Id,
                        Message = doneMessage.Message,
                        From = doneMessage.From.Name,
                        UpdatedTime = conversation.UpdatedTime,
                        MessageCreatedDate = doneMessage.CreatedTime,
                        Phone = findPhone(doneMessage.Message)
                    };
                    result.Add(chat);
                } 
                
            }


            return result;
        }
        private string findPhone(string text)
        {
            const string MatchPhonePattern =
                   @"(84|0[3|5|7|8|9])+([0-9]{8})\b";

            Regex rx = new Regex(MatchPhonePattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // Find matches.
            MatchCollection matches = rx.Matches(text);

            // Report the number of matches found.
            int noOfMatches = matches.Count;


            //Do something with the matches

            foreach (Match match in matches)
            {
                //Do something with the matches
                string tempPhoneNumber = match.Value.ToString();
                return tempPhoneNumber;
            }
            return "";
        }
    }


}
