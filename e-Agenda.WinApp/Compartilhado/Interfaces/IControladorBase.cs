using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.WinApp.Compartilhado.Interfaces
{
    public interface IControladorBase
    {
        public void Filtrar();
        public void Inserir();
        public void Editar();
        public void Excluir();
        public UserControl ObterListagem();
        public string ObterTipoCadastro();
    }
}
