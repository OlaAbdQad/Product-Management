
using Assessment_Task.Dtos;
using Assessment_Task.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assessment_Task.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [Authorize(Roles = "Super-Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequestModel request)
        {
            await _productService.AddAsync(request);
            return Ok();
        }
        [Authorize(Roles = "Super-Admin")]
        [HttpPost("create-bulk")]
        public async Task<IActionResult> CreateBulk(IList<CreateProductRequestModel> requests)
        {
            await _productService.AddRangeAsync(requests);
            return Ok();
        }
        [Authorize(Roles = "Super-Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAllAsync());
        }
        [Authorize(Roles = "Super-Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _productService.GetByIdAsync(id));
        }
        [Authorize(Roles = "Super-Admin")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductRequestModel request)
        {
            await _productService.UpdateAsync(request);
            return Ok();
        }
        [Authorize(Roles = "Super-Admin")]
        [HttpPut("update-bulk")]
        public async Task<IActionResult> UpdateBulk(IList<UpdateProductRequestModel> requests)
        {
            await _productService.UpdateRangeAsync(requests);
            return Ok();
        }
        [Authorize(Roles = "Super-Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _productService.DeleteAsync(id);
            return Ok();
        }
        [Authorize(Roles = "Super-Admin,Admin")]
        [HttpPut("update-status/{id}")]
        public async Task<IActionResult> UpdateStatus(Guid id, bool status)
        {
            await _productService.UpdateProductStatusAsync(id,status);
            return Ok();
        }
        [Authorize(Roles = "Super-Admin")]
        [HttpGet("disabled-products")]
        public async Task<IActionResult> GetAllDisabledProducts()
        {
            return Ok(await _productService.GetAllDisabledProductAsync());
        }
        [Authorize(Roles = "Super-Admin")]
        [HttpGet("sum-of-product-created-lastweek")]
        public async Task<IActionResult> GetSumOfProducts()
        {
            return Ok(await _productService.GetSumOfAllProductsCreatedLastWeek());
        }
    }
}