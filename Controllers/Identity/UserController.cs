using JobHunt.DTO.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReviews.DTO.Identity;
using MovieReviews.Services;
using MovieReviews.Wrappers;
using System.Threading.Tasks;

namespace GenPsych.Api.Controllers.Identity
{
    //[Authorize]
    [Route("api/identity/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) => _userService = userService;


        [HttpGet("current")]
        [ProducesResponseType(typeof(UserDto), 200)]
        public async Task<UserDto> GetCurrentUser() => await _userService.GetCurrentUserAsync();


        //[Authorize(Policy = Permissions.Users.View)]
        [HttpGet]
        public async Task<PaginatedResult<UserDto>> GetAll(int? pageNumber, int? pageSize, string sortField, string sortOrder, string searchText)
        { 
            return await _userService.GetAllAsync(pageNumber ?? 1, pageSize ?? 10, sortField ?? "UserName", sortOrder ?? "ASC", searchText ?? "");
        }


        ////[Authorize(Policy = Permissions.Users.View)]
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(string id)
        //{
        //    var user = await _userService.GetAsync(id);
        //    return Ok(user);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateUserAsync(string id, CreateUpdateUserRequest request)
        //{
        //    return Ok(await _userService.UpdateUserAsync(id,  request));
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(string id) => Ok(await _userService.DeleteAsync(id));



        [AllowAnonymous]
        [HttpPost]
        public async Task<string> RegisterAsync(RegisterUser request)
        {
            var origin = Request.Headers["origin"];
            return await _userService.RegisterAsync(request, origin);
        }

        
        [HttpPost("ChangePassword")]
        public async Task<string> ChangePassword(ChangePasswordRequest request)
        {
            //var origin = Request.Headers["origin"];
            return await _userService.ChangePasswordAsync(request);
        }

        //[HttpPost("create-user")]
        //public async Task<IActionResult> CreateUser(CreateUpdateUserRequest request)
        //{
        //    return Ok(await _userService.CreateUser(request));
        //}


        //[HttpGet("confirm-email")]
        //[AllowAnonymous]
        //public async Task<IActionResult> ConfirmEmailAsync([FromQuery] string userId, [FromQuery] string code)
        //{
        //    return Ok(await _userService.ConfirmEmailAsync(userId, code));
        //}

        //[HttpPost("confirm-email-and-set-password")]
        //[AllowAnonymous]
        //public async Task<IActionResult> ConfirmEmailAsync(ResetPasswordRequest request)
        //{
        //    return Ok(await _userService.ConfirmEmailAndSetPasswordAsync(request));
        //}

        //[HttpPost("toggle-status")]
        //public async Task<IActionResult> ToggleUserStatusAsync(ToggleUserStatusRequest request)
        //{
        //    return Ok(await _userService.ToggleUserStatusAsync(request));
        //}


        //[HttpPost("forgot-password")]
        //[AllowAnonymous]
        //public async Task<IActionResult> ForgotPasswordAsync(ForgotPasswordRequest request)
        //{
        //    var origin = Request.Headers["origin"];
        //    return Ok(await _userService.ForgotPasswordAsync(request, origin));
        //}


        //[HttpPost("reset-password")]
        //[AllowAnonymous]
        //public async Task<IActionResult> ResetPasswordAsync(ResetPasswordRequest request)
        //{
        //    return Ok(await _userService.ResetPasswordAsync(request));
        //}



        ////[Authorize(Policy = Permissions.Users.View)]
        //[HttpGet("roles/{id}")]
        //public async Task<IActionResult> GetRolesAsync(string id)
        //{
        //    var userRoles = await _userService.GetRolesAsync(id);
        //    return Ok(userRoles);
        //}



        //[Authorize(Policy = Permissions.Users.Edit)]
        //[HttpPut("roles/{id}")]
        //public async Task<IActionResult> UpdateRolesAsync(UpdateUserRolesRequest request)
        //{
        //    return Ok(await _userService.UpdateRolesAsync(request));
        //}

    }
}