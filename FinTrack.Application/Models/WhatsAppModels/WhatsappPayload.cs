using FinTrack.Application.Services.Queries.WhatsappQueries.WhatsappReceiveMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace FinTrack.Core.WhatsappModels
{
    public class WhatsappPayload
    {
        public string ContactName { get; set; }
        public string WaId { get; set; }
        public string MessageBody { get; set; }
        public string Timestamp { get; set; }
        public string MessageType { get; set; }

        public static WhatsappPayload FromWhatsAppRequest(WhatsappReceiveMessageQuery request)
        {
            var entry = request.Entry?.FirstOrDefault();
            var change = entry?.Changes?.FirstOrDefault();
            var value = change?.Value;
            var contact = value?.Contacts?.FirstOrDefault();
            var message = value?.Messages?.FirstOrDefault();
            if (contact == null || message == null)
                return null;
            return new WhatsappPayload
            {
                ContactName = contact.Profile?.Name,
                WaId = contact.Wa_Id,
                MessageBody = message.Text?.Body,
                Timestamp = message.Timestamp,
                MessageType = message.Type
            };
        }
        public static string ConvertTojson(WhatsappPayload whatsappPayload)
        {
            return JsonSerializer.Serialize(whatsappPayload);
        }
        public static WhatsappPayload ConvertFromJson(string json)
        {
            return JsonSerializer.Deserialize<WhatsappPayload>(json);
        }

    }
}
