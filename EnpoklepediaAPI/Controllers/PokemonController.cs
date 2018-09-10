using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EnpoklepediaAPI.Models;

namespace EnpoklepediaAPI.Controllers
{
    public class PokemonController : ApiController
    {
		private readonly EnpoklepediaContext _ctx;

		public PokemonController(EnpoklepediaContext ctx)
			: base()
		{
			_ctx = ctx;
		}

		// GET api/pokemon
		[HttpGet]
		public List<Pokemon> Get()
		{
			return _ctx.Pokemon.ToList();
		}

		// GET api/pokemon/number
		[HttpGet]
		public Pokemon Get(int number)
		{
			return _ctx.Pokemon.FirstOrDefault(p => p.Number == number);
		}
    }
}
