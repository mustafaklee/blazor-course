using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Hafta10webapiler.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BizimController : ControllerBase
	{

		[HttpGet("Fonksiyon")]
		public string Merhaba()  //senkron calısır return parameter seklınde oldugu ıcın  senkron oldugu ıcın bırı ıstek yaparsa merhaba fonksıyonuna dıger bır kullanıcıda ıstek yaparsa bekler ılk merhabaya basanın bıtmesını bekelr.
		{
			return "Merhaba Bizim Controller";
		}

		//return parametre  senkron calısır   fonksıyonda belırtılen tıp doner 
		//IActionResult , IActionResult     senktron calısır   fonksıyonu boyle tanımlarsam http kodları 100 200 300 400 500 bunlarla beraber kullanabılıyorum.
		//Task , async   Asenkron calısmak ıcın kullanılır      




		/// <summary>
		///	
		/// </summary>
		/// <param name="id">Tam sayı alan parametre</param>
		/// <returns></returns>
		[HttpGet("Deneme2")]
		public List<string> Deneme2(int id)
		{
			return new List<string>() {"Deneme 2 çalıştı"};
		}

		[HttpGet("Deneme10/{id:int?}")]
		public ActionResult<List<string>> Deneme10(int id)
		{

			if (id == 0) {

				return BadRequest("id 0 olamaz");

			
			}

			return new List<string>() { "Deneme 10 çalıştı" };
			//return Ok(new List<string>() {"" });
		}

		//haftaya hatırlat  alttakı denemeasync aynı zamanda 
		//public async Task<List<string>> DenemeAsync()
		//{
		//	await Task.Delay(1000);
		//}

		//async Task 
		//post object
		//http client servis tanımlama
		//frombody  from header fromquery
		//entityFramework

		[HttpPost()]
		public void Deneme3()
		{

		}



		[HttpGet()]
		public void Deneme4()
		{

		}
		//[HttpGet()]
		//public void Deneme5()
		//{

		//}
	}
}
