using Microsoft.AspNetCore.Mvc;
using WebApiRecargas.Data;
using WebApiRecargas.Model;

namespace WebApiRecargas.Controllers
{
    [Route("api/Ventatotal")]
    [ApiController]
    public class VentaTotalController : ControllerBase
    {
        private readonly IVentaTotalRepository _ventaTotalRepository;

        public VentaTotalController(IVentaTotalRepository ventaTotalRepository)
        {
            _ventaTotalRepository = ventaTotalRepository;
        }

        [HttpGet("GetVentaTotal")]
        public async Task<IActionResult> GetAllReferencesByBrand()
        {
            return Ok(await _ventaTotalRepository.GetVentaTotal());
        }

        [HttpPost("AgregaRecarga")]
        public async Task<ActionResult<string>> AgregaRecarga(AgregaRecarga agregaRecarga)
        {
            string result = string.Empty;
            try
            {
                result = await _ventaTotalRepository.AgregaRecarga(agregaRecarga);
                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }
        }

        [HttpGet("GetVendedores")]
        public async Task<IActionResult> GetVendedores()
        {
            return Ok(await _ventaTotalRepository.GetVendedores());
        }

        [HttpGet("GetOperadores")]
        public async Task<IActionResult> GetOperadores()
        {
            return Ok(await _ventaTotalRepository.GetOperadores());
        }

    }
}
