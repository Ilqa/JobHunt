using GenPsych.Application.Responses.Identity;
using JobHunt.DTO.Identity;
using MovieReviews.DTO.Identity;
using MovieReviews.Wrappers;
using System.Threading.Tasks;

namespace MovieReviews.Services
{
    public interface IUserService
    {
        Task<UserDto> GetCurrentUserAsync();

        Task<PaginatedResult<UserDto>> GetAllAsync(int pageNumber, int pageSize, string sortField,
            string sortOrder, string searchText);

        Task<string> ChangePasswordAsync(ChangePasswordRequest model);

        Task<string> RegisterAsync(RegisterUser request, string origin);
        Task<int> GetCountAsync();

        //Task<IResult<UserResponse>> GetAsync(string userId);

       

        //Task<IResult<string>> CreateUser(CreateUpdateUserRequest request);

        //Task<IResult> ToggleUserStatusAsync(ToggleUserStatusRequest request);

        //Task<IResult<UserRolesResponse>> GetRolesAsync(string id);

        //Task<IResult> UpdateRolesAsync(UpdateUserRolesRequest request);

        //Task<IResult<string>> ConfirmEmailAsync(string userId, string code);

        //Task<IResult> ConfirmEmailAndSetPasswordAsync(ResetPasswordRequest request);

        //Task<IResult> ForgotPasswordAsync(ForgotPasswordRequest request, string origin);

        //Task<IResult> ResetPasswordAsync(ResetPasswordRequest request);

        //Task<IResult> UpdateUserAsync(string id, CreateUpdateUserRequest request);

        //Task<IResult> InactiveDeleteUserAsync(string id, bool inactive,  bool delete);

        //Task<IResult> DeleteAsync(string id);

        //Task<string> ExportToExcelAsync(string searchString = "");
    }
}