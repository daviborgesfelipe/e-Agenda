﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using e_Agenda.Dominio.ModuloContato;

namespace e_Agenda.Infra.Orm.ModuloContato
{
    public class MapeadorContatoOrm : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("TBContato");

            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(200)").IsRequired(required: false);
            builder.Property(x => x.Telefone).HasColumnType("varchar(20)").IsRequired(required: false);
            builder.Property(x => x.Empresa).HasColumnType("varchar(200)").IsRequired(required: false);
            builder.Property(x => x.Cargo).HasColumnType("varchar(200)").IsRequired(required: false);
        }
    }
}
