using Assessment_Task.Dtos;

namespace Assessment_Task.Service.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(Guid id);
        Task AddAsync(CreateProductRequestModel request);
        Task UpdateAsync(UpdateProductRequestModel request);
        Task DeleteAsync(Guid id);
        Task UpdateProductStatusAsync(Guid id, bool status);
        Task<decimal> GetSumOfAllProductsCreatedLastWeek();
        Task<IEnumerable<ProductDto>> GetAllDisabledProductAsync();

        Task AddRangeAsync(IEnumerable<CreateProductRequestModel> requests);
        Task UpdateRangeAsync(IEnumerable<UpdateProductRequestModel> requests);

    }
}