﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using e_Agenda.Dominio.ModuloCompromisso;

namespace e_Agenda.Infra.Orm.ModuloCompromisso
{
    public class MapeadorCompromissoOrm : IEntityTypeConfiguration<Compromisso>
    {
        public void Configure(EntityTypeBuilder<Compromisso> builder)
        {
            builder.ToTable("TBCompromisso");

            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Assunto).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Local).HasColumnType("varchar(300)").IsRequired(required: false);
            builder.Property(x => x.Link).HasColumnType("varchar(1000)").IsRequired(required: false);
            builder.Property(x => x.Data).IsRequired();
            builder.Property(x => x.HoraInicio).HasColumnType("bigint").IsRequired();
            builder.Property(x => x.HoraTermino).HasColumnType("bigint").IsRequired();

            builder.HasOne(x => x.Contato)
                .WithMany(x => x.Compromissos)
                .IsRequired(false)
                .HasForeignKey(x => x.ContatoId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
