namespace Assessment_Task.Entities
{
    public class User : BaseEntity
    {
        public string Name {get;set;}
        public string Email {get;set;}
        public string Password {get;set;}
        public string RoleName {get;set;} = "Admin";

    }
}