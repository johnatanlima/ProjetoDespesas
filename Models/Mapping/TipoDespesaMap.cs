using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoDespesas.Models.Mapping
{
    public class TipoDespesaMap : IEntityTypeConfiguration<TipoDespesa>
    {
        public void Configure(EntityTypeBuilder<TipoDespesa> builder)
        {
            builder.ToTable("TipoDespesa");

            builder.HasKey(x => x.TipoDespesaId);
            
            builder.Property(x => x.Nome).HasColumnType("varchar(50)").IsRequired();

            builder.HasMany(x => x.Despesas)
                .WithOne(x => x.TipoDespesa)
                    .HasForeignKey(x => x.TipoDespesaId);

        }
    }
}