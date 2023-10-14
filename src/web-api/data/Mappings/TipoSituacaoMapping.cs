using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class TipoSituacaoMapping : IEntityTypeConfiguration<TipoSituacao>
    {

        public void Configure(EntityTypeBuilder<TipoSituacao> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.NomeTipoSituacao)
                    .IsRequired()
                    .HasColumnType("varchar(250)");
        }

    }
}
