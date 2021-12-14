using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebSales.Shared.Response;
using WebSales.Domain.Services.Interfaces;
using WebSales.Domain.Models;

namespace WebSales.Application.Controllers
{
    [ApiController]
    [Route("Product")]
    public class ProductController : APIResponse
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService) => _productService = productService;

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id) => CreateAPIResult(await _productService.Get(id));

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get() => CreateAPIResult(await _productService.Get());

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(ProductModel productModel) => CreateAPIResult(await _productService.Post(productModel));
        
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put(ProductModel productModel) => CreateAPIResult(await _productService.Put(productModel));

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id) => CreateAPIResult(await _productService.Delete(id));

    }
}
