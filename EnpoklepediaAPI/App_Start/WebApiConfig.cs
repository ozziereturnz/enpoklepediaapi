using System;
using System.Web.Http;
using EnpoklepediaAPI.Controllers;
using EnpoklepediaAPI.Models;

namespace EnpoklepediaAPI
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services
			EnpoklepediaContext ctx = new EnpoklepediaContext(Environment.GetEnvironmentVariable("SQLCONNSTR_enpoklepedia"));

			config.DependencyResolver = new EnpoklepediaDependencyResolver(config.DependencyResolver)
				.Add(typeof(PokemonController), () => new PokemonController(ctx));

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}
