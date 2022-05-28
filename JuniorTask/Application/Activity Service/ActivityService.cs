using JuniorTask.Application.Activity_Service.DTO;
using JuniorTask.Shared;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace JuniorTask.Application.Activity_Service
{
    public class ActivityService : IActivityService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly Activity _activityConfig;

        public ActivityService(IHttpClientFactory httpClientFactory,
            IOptionsMonitor<Activity> optionsMonitor)
        {
            _httpClientFactory = httpClientFactory;
            _activityConfig = optionsMonitor.CurrentValue;
        }
        public async Task<ActivityJsonDto?> FetchData()
        {
            try
            {
                var result = await _httpClientFactory.CreateClient().GetAsync(_activityConfig.Url);
                result.EnsureSuccessStatusCode();
                var responseAsString = await result.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<ActivityJsonDto>(responseAsString);
                return json;
            }
            catch (Exception e)
            {
                throw new AppException(e.Message);
            }
        }
    }
}
