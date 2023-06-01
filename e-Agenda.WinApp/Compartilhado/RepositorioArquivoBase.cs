using e_Agenda.WinApp.Compartilhado.Interfaces;
using e_Agenda.WinApp.ModuloContato;
using e_Agenda.WinApp.ModuloTarefa.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.WinApp.Compartilhado
{
    public abstract class RepositorioArquivoBase<IEntidadeBase> : IRepositorioBase<IEntidadeBase>
        where IEntidadeBase : EntidadeBase<IEntidadeBase>
    {
        protected static int contador;
        protected List<IEntidadeBase> listaRegistros;

        public virtual void Inserir(IEntidadeBase novaEntidade)
        {
            contador++;
            novaEntidade.id = contador;
            listaRegistros.Add(novaEntidade);
            AdicionarEntidadeNoArquivo();
        }
        public virtual void Editar(int id, IEntidadeBase entidadeAtualizada)
        {
            IEntidadeBase entidadeSelecionada = SelecionarPorId(id);
            entidadeSelecionada.AtualizarInformacoes(entidadeAtualizada);
            AdicionarEntidadeNoArquivo();
        }
        public virtual void Editar(IEntidadeBase entidadeSelecionado, IEntidadeBase entidadeAtualizado)
        {
            entidadeSelecionado.AtualizarInformacoes(entidadeAtualizado);
            AdicionarEntidadeNoArquivo();

        }
        public virtual void Excluir(IEntidadeBase entidadeSelecionada)
        {
            listaRegistros.Remove(entidadeSelecionada);
            AdicionarEntidadeNoArquivo();

        }
        public virtual void Excluir(int id)
        {
            IEntidadeBase entidadeSelecionado = SelecionarPorId(id);
            listaRegistros.Remove(entidadeSelecionado);
            AdicionarEntidadeNoArquivo();

        }
        public virtual IEntidadeBase SelecionarPorId(int id)
        {
            IEntidadeBase entidade = listaRegistros.FirstOrDefault(x => x.id == id);

            return entidade;
        }
        public virtual List<IEntidadeBase> SelecionarTodos()
        {
            return listaRegistros;
        }
        public bool TemRegistros()
        {
            return listaRegistros.Count > 0;
        }
        public abstract void AdicionarEntidadeNoArquivo();
        public abstract void LerEntidadeNoArquivo();
    }
}
