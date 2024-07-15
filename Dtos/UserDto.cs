namespace Assessment_Task.Dtos
{
    public class UserDto
    {
        public Guid Id {get;set;}
        public string Name {get;set;}
        public string Email {get;set;}
        public string RoleName {get;set;}
    }
    public class CreateUserRequestModel
    {
        public string Name {get;set;}
        public string Email {get;set;}
        public string Password {get;set;}
    }
    public class LoginRequestModel
    {
        public string Email {get;set;}
        public string Password {get;set;}
    }
}