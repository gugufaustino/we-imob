using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class TipoCastingMapping : IEntityTypeConfiguration<TipoCasting>
    {
        public void Configure(EntityTypeBuilder<TipoCasting> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedNever();

            builder.Property(p => p.NomeTipoCasting)
                    .IsRequired()
                    .HasColumnType("varchar(250)");


        }

    }
}
