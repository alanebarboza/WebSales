using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebSales.Shared.Response;
using WebSales.Domain.Services.Interfaces;
using WebSales.Domain.Models;

namespace WebSales.Application.Controllers
{
    [ApiController]
    [Route("Sale")]
    public class SaleController : APIResponse
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService) => _saleService = saleService;

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id) => CreateAPIResult(await _saleService.Get(id));

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get() => CreateAPIResult(await _saleService.Get());

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(SaleModel saleModel) => CreateAPIResult(await _saleService.Post(saleModel));

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put(SaleModel saleModel) => CreateAPIResult(await _saleService.Put(saleModel));

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id) => CreateAPIResult(await _saleService.Delete(id));
    }
}
