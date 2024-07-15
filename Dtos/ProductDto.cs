namespace Assessment_Task.Dtos
{
    public record ProductDto
    {
        public Guid Id {get;set;}
        public string ProductName {get;set;}
        public decimal Price {get;set;}
        public DateTime CreatedDate {get;set;}
        public bool IsDisabled {get;set;} = false;

    }
    public record CreateProductRequestModel
    {
        public string ProductName {get;set;}
        public decimal Price {get;set;}

    }
    public record UpdateProductRequestModel
    {
        public Guid Id {get;set;}
        public string ProductName {get;set;}
        public decimal Price {get;set;}

    }
}