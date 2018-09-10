using System;

namespace EnpoklepediaAPI.Typings
{
	/// <summary>
	/// A record of a Pokemon
	/// </summary>
	public class Pokemon
	{
		public Guid ID { get; set; }
		public short Number { get; set; }
		public string Name { get; set; }
		public string ImageURL { get; set; }
	}
}