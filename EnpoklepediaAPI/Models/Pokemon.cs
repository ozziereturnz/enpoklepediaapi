using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnpoklepediaAPI.Models
{
	/// <summary>
	/// A record of a Pokemon
	/// </summary>
	[Table("Pokemon")]
	public class Pokemon
	{
		public Guid ID { get; set; }
		public short Number { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		[StringLength(500)]
		public string ImageURL { get; set; }
	}
}