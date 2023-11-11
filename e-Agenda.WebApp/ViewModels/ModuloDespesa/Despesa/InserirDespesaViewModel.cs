using eAgenda.Dominio.ModuloDespesa;

namespace e_Agenda.WebApp.ViewModels.ModuloDespesa.Despesa
{

    public class InserirDespesaViewModel
    {
        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public DateTime Data { get; set; }

        public FormaPgtoDespesaEnum FormaPagamento { get; set; }

        public List<Guid> CategoriasSelecionadas { get; set; }
    }
}
