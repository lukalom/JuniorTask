using Newtonsoft.Json;

namespace JuniorTask.Application.Activity_Service.DTO
{
    public class ActivityJsonDto
    {
        [JsonProperty("activity")]
        public string Activity { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("participants")]
        public long Participants { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("link")]
        public Uri Link { get; set; }

        [JsonProperty("key")]
        public long Key { get; set; }

        [JsonProperty("accessibility")]
        public double Accessibility { get; set; }
    }
}
