
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Academy.Models;

namespace Academy.Data
{
	public class AcademyContext : DbContext
	{
		public AcademyContext(DbContextOptions<AcademyContext> options)
			: base(options)
		{
		}

		// --- DbSet для всех сущностей ---
		public DbSet<Academy.Models.Discipline> Disciplines { get; set; } = default!;
		public DbSet<Academy.Models.Student> Students { get; set; } = default!;
		public DbSet<Academy.Models.Group> Groups { get; set; } = default!;
		public DbSet<Academy.Models.Direction> Directions { get; set; } = default!;
		public DbSet<Academy.Models.Teacher> Teachers { get; set; } = default!;
		// ---------------------------------

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Явное определение связи между Group и Direction
			modelBuilder.Entity<Group>()
				.HasOne(g => g.Direction)          // У Группы есть одно Направление
				.WithMany(d => d.Groups)           // У Направления много Групп
				.HasForeignKey(g => g.direction_id) // Внешний ключ в таблице Group называется direction_id
				.IsRequired();

			// Явное определение связи между Student и Group
			modelBuilder.Entity<Student>()
				.HasOne(s => s.Group)              // У Студента есть одна Группа
				.WithMany(g => g.Students)         // У Группы много Студентов
				.HasForeignKey(s => s.group_id)    // Внешний ключ в таблице Student называется group_id
				.IsRequired();

			// Вызываем базовую реализацию в конце
			base.OnModelCreating(modelBuilder);
		}
	}
}