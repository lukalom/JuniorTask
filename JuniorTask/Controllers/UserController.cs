using JuniorTask.Application.User_Service;
using JuniorTask.Application.User_Service.DTO;
using Microsoft.AspNetCore.Mvc;

namespace JuniorTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromQuery] AddUserRequestDto requestDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.CreateUser(requestDto)!;
                if (result.IsSuccess)
                {
                    return Ok(result.Content);
                }

                return BadRequest(result.Errors);
            }

            return BadRequestModelState();
        }

        [HttpPut]
        public async Task<IActionResult> AddUser([FromQuery] EditUserRequestDto requestDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.EditUser(requestDto)!;
                if (result.IsSuccess)
                {
                    return Ok(result.Content);
                }

                return BadRequest(result.Errors);
            }

            return BadRequestModelState();
        }

        [HttpGet]
        public async Task<IActionResult> FilterUser([FromQuery] FilterUsersRequestDto requestDto)
        {
            var result = await _userService.FilterUsers(requestDto);

            if (result.IsSuccess)
            {
                return Ok(result.Content);
            }

            return BadRequest(result.Errors);
        }

        private IActionResult BadRequestModelState()
        {
            var errorMessages = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));

            return BadRequest(new { error = errorMessages });
        }
    }
}
