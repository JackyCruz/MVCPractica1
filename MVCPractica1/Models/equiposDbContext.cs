using Microsoft.EntityFrameworkCore;

namespace MVCPractica1.Models
{
	public class equiposDbContext : DbContext
	{
		public equiposDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<marcas> marcas { get; set; }
		public DbSet<tipo_equipo> tipo_Equipo { get; set; }
		public DbSet<estados_equipo> estados_equipo { get; set; }
		public DbSet<equipos> equipos { get; set; }
	}
}
