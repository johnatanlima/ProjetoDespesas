using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoDespesas.Models.Mapping
{
    public class MesMap : IEntityTypeConfiguration<Mes>
    {
        public void Configure(EntityTypeBuilder<Mes> builder)
        {
            builder.ToTable("Mes");

            builder.HasKey(x => x.MesId);
            builder.Property(x => x.MesId).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(50)").IsRequired();

            builder.HasMany(x => x.Despesas)
                .WithOne(x => x.Mes)
                .HasForeignKey(x => x.MesId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Salario)
                .WithOne(x => x.Mes)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}