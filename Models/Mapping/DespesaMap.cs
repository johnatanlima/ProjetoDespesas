using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoDespesas.Models.Mapping
{
    public class DespesaMap : IEntityTypeConfiguration<Despesa>
    {
        public void Configure(EntityTypeBuilder<Despesa> builder)
        {
            builder.ToTable("Despesa");

            builder.HasKey(x => x.DespesaId);

            builder.Property(x => x.Valor).HasColumnType("decimal(9,2)").IsRequired();

            builder.HasOne(x => x.Mes).WithMany(x => x.Despesas).HasForeignKey(x => x.MesId);
            builder.HasOne(x => x.TipoDespesa).WithMany(x => x.Despesas).HasForeignKey(x => x.TipoDespesaId);
        }
    }
}