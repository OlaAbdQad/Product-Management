using Assessment_Task.Dtos;

namespace Assessment_Task.Service.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task AddAsync(CreateUserRequestModel request);
        Task<UserDto> LoginAsync(LoginRequestModel request);

        
    }
}