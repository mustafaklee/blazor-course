using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunController : ControllerBase
    {

        private readonly UrunService _servis;
        public UrunController(UrunService servis)
        {
            _servis = servis;
        }


        [HttpGet("/urunlerigetir")]
        public async Task<List<Urun>> Get()
        {
            return await _servis.UrunleriGetir();
        }

        [HttpPost("/urunekle")]
        public async Task<IActionResult> UrunEkle(Urun urun)
        {
            await _servis.UrunEkle(urun);
            return Ok("Ürün Başarıyla Eklendi.");
        }




    }
}
