using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EnpoklepediaAPI.Typings;

namespace EnpoklepediaAPI.Controllers
{
    public class PokemonController : ApiController
    {
		// GET api/pokemon
		[HttpGet]
		public IEnumerable<Pokemon> Get()
		{
			return new Pokemon[] { new Pokemon() };
		}

		// GET api/pokemon/ID
		[HttpGet]
		public Pokemon Get(Guid ID)
		{
			return new Pokemon();
		}
    }
}
