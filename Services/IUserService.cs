using JobHunt.DTO;
using JobHunt.DTO.Identity;
using JobHunt.Wrappers;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using IResult = JobHunt.Wrappers.IResult;

namespace JobHunt.Services
{
    public interface IUserService
    {
        Task<UserDto> GetCurrentUserAsync();

        Task<PaginatedResult<UserDto>> GetAllAsync(int pageNumber, int pageSize, string sortField,
            string sortOrder, string searchText);

        Task<IResult> ChangePasswordAsync(ChangePasswordRequest model);

        Task<IResult> RegisterAsync(RegisterUser request, string origin);

        Task<int> GetCountAsync();
        Task<Result<TokenResponse>> Login(TokenRequest model);

        Task<IResult> CreateProfileAsync(UserProfileDto profile);
        //Task<int?> GetProfileIdByUserID(int userId);
        Task<IResult> UpdateProfileAsync(UserProfileDto profile);
        Task<IResult> UploadFile(int userId, IFormFile file);
        Task<Result<UserProfileDto>> GetProfileAsync(int userId);

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