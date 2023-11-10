using e_Agenda.Dominio.ModuloDespesa;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace e_Agenda.Infra.Orm.ModuloDespesa
{
    public class MapeadorCategoriaOrm : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("TBCategoria");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Titulo).HasColumnType("varchar(200)").IsRequired();

            builder.HasMany(x => x.Despesas);
        }
    }
}