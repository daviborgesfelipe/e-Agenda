using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using e_Agenda.Dominio.ModuloTarefa;

namespace e_Agenda.Infra.Orm.ModuloTarefa
{
    public class MapeadorItemTarefaOrm : IEntityTypeConfiguration<ItemTarefa>
    {
        public void Configure(EntityTypeBuilder<ItemTarefa> builder)
        {
            builder.ToTable("TBItemTarefa");

            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Titulo).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.Concluido);

            builder.HasOne(x => x.Tarefa)
                .WithMany().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
