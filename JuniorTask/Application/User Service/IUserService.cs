using JuniorTask.Application.User_Service.DTO;
using JuniorTask.Shared;

namespace JuniorTask.Application.User_Service
{
    public interface IUserService
    {
        Task<Result<AddUserResponseDto>>? CreateUser(AddUserRequestDto requestDto);
        Task<Result<bool>> EditUser(EditUserRequestDto requestDto);
        Task<Result<List<FilteredUserResponseDto>>> FilterUsers(FilterUsersRequestDto requestDto);
    }
}
