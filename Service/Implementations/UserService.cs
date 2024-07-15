using Assessment_Task.Dtos;
using Assessment_Task.Entities;
using Assessment_Task.Repository.Contracts;
using Assessment_Task.Service.Contracts;
using Mapster;

namespace Assessment_Task.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _repo;

        public UserService(IGenericRepository<User> repo)
        {
            _repo = repo;
        }

        public async Task AddAsync(CreateUserRequestModel request)
        {
            await _repo.AddAsync(request.Adapt<User>());
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _repo.GetAllAsync();
            return users.Adapt<IEnumerable<UserDto>>();
        }

        public async Task<UserDto> LoginAsync(LoginRequestModel request)
        {
            var user = await _repo.GetAsync(a => a.Email == request.Email && a.Password == request.Password);
            return user.Adapt<UserDto>();
        }
    }
}