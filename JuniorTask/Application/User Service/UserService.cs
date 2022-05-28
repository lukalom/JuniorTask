using AutoMapper;
using JuniorTask.Application.User_Service.DTO;
using JuniorTask.Infrastructure.Entities;
using JuniorTask.Infrastructure.IConfiguration;
using JuniorTask.Shared;
using Microsoft.EntityFrameworkCore;

namespace JuniorTask.Application.User_Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<AddUserResponseDto>> CreateUser(AddUserRequestDto requestDto)
        {
            var result = new Result<AddUserResponseDto>();
            var errors = new List<string>();

            if (requestDto.PersonalNumber.Length != 11) errors.Add("Personal Number Should contain 11 symbols");

            var user = await _unitOfWork.User
                .FindByCondition(x => x.PersonalNumber == requestDto.PersonalNumber)
                .FirstOrDefaultAsync();

            if (user != null) errors.Add("Invalid Personal Number");

            var gender = await _unitOfWork.Gender
                .FindByCondition(x => x.Id == requestDto.GenderId)
                .FirstOrDefaultAsync();

            if (gender == null) errors.Add("Invalid Gender");

            if (errors.Any())
            {
                result.Errors = errors;
                return result;
            }

            var mappedUser = _mapper.Map<User>(requestDto);

            if (await _unitOfWork.User.AddAsync(mappedUser))
            {
                await _unitOfWork.SaveAsync();
                result.Content = _mapper.Map<AddUserResponseDto>(mappedUser);

                return result;
            }

            throw new AppException("Something Went Wrong");
        }

        public async Task<Result<bool>> EditUser(EditUserRequestDto requestDto)
        {
            var result = new Result<bool>();
            var errors = new List<string>();

            var user = await _unitOfWork.User
                .FindByCondition(x => x.PersonalNumber == requestDto.PersonalNumber)
                .FirstOrDefaultAsync();

            if (user == null) errors.Add("Invalid Personal Number");

            if (errors.Any())
            {
                result.Errors = errors;
                return result;
            }

            if (requestDto.Status != null)
            {
                user.Status = !user.Status;
            }

            if (requestDto.BirthDate != null)
            {
                user.BirthDate = requestDto.BirthDate.Value;
            }

            await _unitOfWork.SaveAsync();
            result.Content = true;
            return result;
        }

        public async Task<Result<List<FilteredUserResponseDto>>> FilterUsers(FilterUsersRequestDto requestDto)
        {
            var result = new Result<List<FilteredUserResponseDto>>();
            var usersQuery = _unitOfWork.User.Query();

            if (!string.IsNullOrEmpty(requestDto.Name))
            {
                var filteredUsers = await usersQuery.Where(u =>
                        u.Name.Contains(requestDto.Name!.ToLowerInvariant()) && u.IsDeleted == false)
                    .Include(x => x.Gender)
                    .ToListAsync();

                result.Content = _mapper.Map<List<FilteredUserResponseDto>>(filteredUsers);
                return result;
            }

            if (!string.IsNullOrEmpty(requestDto.LastName))
            {
                var filteredUsers = await usersQuery.Where(u =>
                        u.LastName.Contains(requestDto.LastName!.ToLowerInvariant()))
                    .Include(x => x.Gender)
                    .ToListAsync();

                result.Content = _mapper.Map<List<FilteredUserResponseDto>>(filteredUsers);
                return result;

            }

            if (!string.IsNullOrEmpty(requestDto.PersonalNumber))
            {
                var filteredUsers = await _unitOfWork.User
                    .FindByCondition(x => x.PersonalNumber == requestDto.PersonalNumber && x.IsDeleted == false)
                    .Include(x => x.Gender)
                    .ToListAsync();
                result.Content = _mapper.Map<List<FilteredUserResponseDto>>(filteredUsers);
                return result;
            }

            var mappedUsers = _mapper.Map<List<FilteredUserResponseDto>>(await _unitOfWork.User
                                        .Query()
                                        .Where(x => x.IsDeleted == false)
                                        .Include(x => x.Gender)
                                        .ToListAsync());
            result.Content = mappedUsers;
            return result;
        }
    }
}
