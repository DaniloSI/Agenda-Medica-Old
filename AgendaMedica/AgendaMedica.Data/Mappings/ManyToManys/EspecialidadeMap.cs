using AgendaMedica.Domain.Entities.ManyToManys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaMedica.Data.Mappings.ManyToManys
{
    public class UsuarioProfissionalEspecialidadeMap : IEntityTypeConfiguration<UsuarioProfissionalEspecialidade>
    {
        public void Configure(EntityTypeBuilder<UsuarioProfissionalEspecialidade> builder)
        {
            builder.HasKey(c => new { c.EspecialidadeId, c.Id });

            builder.HasOne(x => x.Especialidade)
                .WithMany()
                .HasForeignKey(x => x.EspecialidadeId);

            builder.HasOne(x => x.UsuarioProfissional)
                .WithMany(y => y.Especialidades)
                .HasForeignKey(x => x.Id);

            builder.ToTable(nameof(UsuarioProfissionalEspecialidade));
        }
    }
}
