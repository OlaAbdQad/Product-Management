using Assessment_Task.Dtos;
using Assessment_Task.Entities;
using Assessment_Task.Repository.Contracts;
using Assessment_Task.Service.Contracts;
using Mapster;

namespace Assessment_Task.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _repo;

        public ProductService(IGenericRepository<Product>  repo)
        {
            _repo = repo;
        }

        public async Task AddAsync(CreateProductRequestModel request)
        {
            await _repo.AddAsync(request.Adapt<Product>());
        }

        public async Task AddRangeAsync(IEnumerable<CreateProductRequestModel> requests)
        {
            await _repo.AddRangeAsync(requests.Adapt<IEnumerable<Product>>());
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _repo.GetAllAsync();
            return products.Adapt<IEnumerable<ProductDto>>();
        }

        public async Task<IEnumerable<ProductDto>> GetAllDisabledProductAsync()
        {
           var products =  await _repo.GetAllAsync(a => a.IsDisabled);
           return products.OrderByDescending(a => a.CreatedDate).Adapt<IEnumerable<ProductDto>>();
        }

        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var product = await _repo.GetByIdAsync(id);
            return product.Adapt<ProductDto>();
        }

        public async Task<decimal> GetSumOfAllProductsCreatedLastWeek()
        {
            var lastWeek = DateTime.UtcNow.AddDays(-7);
            return await _repo.SumAsync(a => a.CreatedDate >= lastWeek, a => a.Price);
        }


        public async Task UpdateAsync(UpdateProductRequestModel request)
        {
            var product = await _repo.GetByIdAsync(request.Id);
            request.Adapt(product);
            await _repo.UpdateAsync(product);

        }

        public async Task UpdateProductStatusAsync(Guid id , bool status)
        {
            var product = await _repo.GetByIdAsync(id);
            if(product != null)
            {
                Console.WriteLine(status);
                product.IsDisabled = status;
               await _repo.UpdateAsync(product);
            }
        }

        public async Task UpdateRangeAsync(IEnumerable<UpdateProductRequestModel> requests)
        {
            var ids = requests.Select(r => r.Id).ToList();
            var products = await _repo.GetByIdsAsync(ids);
            foreach (var request in requests)
            {
                var product = products.FirstOrDefault(p => p.Id == request.Id);
                if (product != null)
                {
                    request.Adapt(product);
                }
            }

            await _repo.UpdateRangeAsync(products);
        }
    }
}