using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoDespesas.Models.Mapping
{
    public class SalarioMap : IEntityTypeConfiguration<Salario>
    {
        public void Configure(EntityTypeBuilder<Salario> builder)
        {
            builder.ToTable("Salario");

            builder.HasKey(x => x.SalarioId);

            builder.Property(x => x.Valor).HasColumnType("decimal(9,2)").IsRequired();
            
            builder.HasOne(x => x.Mes).WithOne(x => x.Salario).HasForeignKey<Salario>(x => x.MesId);
        }
    }
}