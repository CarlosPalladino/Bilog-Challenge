using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class EspecialidadConfiguration : IEntityTypeConfiguration<Especialidad>
    {
        public void Configure(EntityTypeBuilder<Especialidad> builder)
        {
            builder.ToTable("Especialidades");

            builder.HasKey(e => e.id_especialidad);

            builder.Property(e => e.cod_especialidad)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(e => e.descripcion)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(e => e.rowversion)
                   .IsRowVersion();

            builder.HasIndex(e => e.cod_especialidad)
                   .IsUnique();

            builder.HasIndex(e => e.descripcion)
                   .IsUnique();
        }
    }
}

