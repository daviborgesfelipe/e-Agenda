using e_Agenda.WinApp.Compartilhado.Interfaces;
using e_Agenda.WinApp.ModuloContato.Entidades;
using e_Agenda.WinApp.ModuloTarefa.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.WinApp.ModuloContato.Interfaces
{
    public interface IRepositorioContato : IRepositorioBase<Contato>
    {
        void Inserir(Contato novoContato);
        void Editar(int id, Contato contato);
        void Excluir(Contato contatoSelecionada);
        Contato SelecionarPorId(int id);
    }
}
