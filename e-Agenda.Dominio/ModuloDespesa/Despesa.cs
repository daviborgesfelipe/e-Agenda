﻿using e_Agenda.Dominio.Compartilhado;
using eAgenda.Dominio.ModuloDespesa;

namespace e_Agenda.Dominio.ModuloDespesa
{
    public class Despesa : EntidadeBase<Despesa>
    {
        public Despesa()
        {
            Data = DateTime.Now;
            Categorias = new List<Categoria>();
        }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public DateTime Data { get; set; }

        public FormaPgtoDespesaEnum FormaPagamento { get; set; }

        public List<Categoria> Categorias { get; set; }

        public override void Atualizar(Despesa registro)
        {
            Descricao = registro.Descricao;
            Valor = registro.Valor;
            Data = registro.Data;
            FormaPagamento = registro.FormaPagamento;
            Categorias = registro.Categorias;
        }

        public override string ToString()
        {
            return $"{Descricao} feita no dia {Data.ToShortDateString()}";
        }

        public Despesa Clonar()
        {
            return MemberwiseClone() as Despesa;
        }

        public void AtribuirCategoria(Categoria categoria)
        {
            if (Categorias.Contains(categoria) == false)
            {
                Categorias.Add(categoria);
                categoria.RegistrarDespesa(this);
            }
        }

        public void RemoverCategoria(Categoria categoria)
        {
            Categorias.Remove(categoria);
        }
    }
}
