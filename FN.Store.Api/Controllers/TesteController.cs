using Microsoft.AspNetCore.Mvc;

namespace FN.Store.Api.Controllers
{
	public class TesteController
    {
		[HttpGet("ping")]
		public string Ping() => "Pong";



    }
}
