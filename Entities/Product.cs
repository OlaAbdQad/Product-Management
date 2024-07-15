namespace Assessment_Task.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName {get;set;}
        public decimal Price {get;set;}
        public DateTime CreatedDate {get;set;} = DateTime.UtcNow;
        public bool IsDisabled {get;set;} = false;

    }
}