using JuniorTask.Application.Activity_Service.DTO;

namespace JuniorTask.Application.Activity_Service
{
    public interface IActivityService
    {
        Task<ActivityJsonDto?> FetchData();
    }
}
