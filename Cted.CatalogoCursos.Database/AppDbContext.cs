using Cted.CatalogoCursos.Models;
using Microsoft.EntityFrameworkCore;

namespace Cted.CatalogoCursos.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Curso> Cursos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Modalidade> Modalidades { get; set; }
    public DbSet<Status> Status { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Curso>(entity =>
        {
            entity.ToTable("Cursos");
            entity.HasKey(e => e.IdCurso);

            entity.Property(e => e.NomeCompleto)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(e => e.NomeBreve)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Descricao)
                .HasColumnType("TEXT");

            entity.Property(e => e.CargaHoraria)
                .IsRequired();

            entity.Property(e => e.DataDisponibilizacao)
                .HasColumnType("TEXT");

            entity.Property(e => e.IdCategoria)
                .IsRequired();

            entity.Property(e => e.IdModalidade)
                .IsRequired();

            entity.Property(e => e.IdStatus)
                .IsRequired();
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.ToTable("Categorias");
            entity.HasKey(e => e.IdCategoria);

            entity.Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(150);
        });

        modelBuilder.Entity<Modalidade>(entity =>
        {
            entity.ToTable("Modalidades");
            entity.HasKey(e => e.IdModalidade);

            entity.Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(150);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");
            entity.HasKey(e => e.IdStatus);

            entity.Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(150);
        });

        base.OnModelCreating(modelBuilder);
    }
}
