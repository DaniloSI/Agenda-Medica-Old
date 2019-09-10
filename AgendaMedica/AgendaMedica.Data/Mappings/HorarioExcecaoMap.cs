using AgendaMedica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaMedica.Data.Mappings
{
    public class HorarioExcecaoMap : IEntityTypeConfiguration<HorarioExcecao>
    {
        public void Configure(EntityTypeBuilder<HorarioExcecao> builder)
        {
            builder.HasKey(c => c.HorarioExcecaoId);

            builder.HasOne(h => h.Profissional)
                .WithMany(p => p.HorariosExcecoes)
                .HasForeignKey(h => h.ProfissionalId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(nameof(HorarioExcecao));
        }
    }
}
