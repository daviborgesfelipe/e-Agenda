using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using e_Agenda.Dominio.ModuloTarefa;

namespace e_Agenda.Infra.Orm.ModuloTarefa
{
    public class MapeadorTarefaOrm : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("TBTarefa");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Titulo).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.Prioridade).HasConversion<int>();
            builder.Property(x => x.DataCriacao).IsRequired();
            builder.Property(x => x.DataConclusao).IsRequired(required: false);
            builder.Property(x => x.PercentualConcluido);

            builder.HasMany(x => x.Itens)
                .WithOne(x => x.Tarefa)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
