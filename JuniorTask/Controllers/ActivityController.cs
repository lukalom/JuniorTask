using JuniorTask.Application.Activity_Service;
using JuniorTask.Application.Activity_Service.DTO;
using Microsoft.AspNetCore.Mvc;

namespace JuniorTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        public async Task<ActionResult<ActivityJsonDto>> FetchActivityApi() =>
            Ok(await _activityService.FetchData());

    }
}
