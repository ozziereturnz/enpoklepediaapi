using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EnpoklepediaAPI.Models
{
	public partial class EnpoklepediaContext : DbContext
	{
		public EnpoklepediaContext(string connectionString)
			: base(connectionString)
		{
		}

		public virtual DbSet<Pokemon> Pokemon { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}
	}
}
