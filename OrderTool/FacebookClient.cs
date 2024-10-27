using Microsoft.VisualBasic;
using Newtonsoft.Json;
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
        public const string ACCESS_TOKEN = "EAAIjQtDKHq4BO1xuVBo9vgBmqybGvHTdZAGhYWysYZCyMbhEavcDot7MinN89cCd3ixy6esdQyDHwngkNyPengkBvhTIUWTiQzvX2k5ARaBZAmwYerAq9Ny8vF4LH7C93UMs8lGZAZAeUXw7rtdCUOSnevaYLnUpujdYwVrlGf6vBWzoT0Qqyg5h024E9SHo7sJaGTa3WZAIZCgD4JZCNA9HdenD";



        public FacebookClient()
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri("https://graph.facebook.com/v21.0");
        }

        public async Task<ConversationResponse> getListConversation()
        {
            try
            {
                var httpResponse = await HttpClient.GetAsync($"{HttpClient.BaseAddress}/{PAGE_ID}/conversations?platform=messenger&access_token={ACCESS_TOKEN}&fields=updated_time,messages.fields(message, from)");
                var content = await httpResponse.Content.ReadAsStringAsync();
                var lstConversation = JsonConvert.DeserializeObject<ConversationResponse>(content);

                return lstConversation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Chat>> getListMessage(List<Conversation> conversations)
        {
            List<Chat> result = new List<Chat>();

            var lstOrdered = conversations.Where(x => x.Messages.Data.Any(x => x.Message.Contains("đã đặt hàng")));
            foreach (var conversation in lstOrdered)
            {
                var doneMessage = conversation.Messages.Data.FirstOrDefault(x => !string.IsNullOrEmpty(findPhone(x.Message)));
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
