using Assessment_Task.Dtos;

namespace Assessment_Task.Auth
{
    public interface IJwtManager
    {
        public string GenerateToken(UserDto user);

    }
}