﻿using Microsoft.EntityFrameworkCore;
using ClienteAPI.Modelo;

namespace ClienteAPI.DAL
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
		}

		public DbSet<Cliente> Clientes { get; set; }
	}
}
