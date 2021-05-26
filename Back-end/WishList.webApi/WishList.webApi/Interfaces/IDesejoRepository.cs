using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishList.webApi.Domains;

namespace WishList.webApi.Interfaces
{
    interface IDesejoRepository
    {
        List<Desejo> ListarTodos();

        Desejo BuscarPorId(int id);

        void Cadastrar(Desejo novoDesejo);

        void Deletar(int id);

        void Atualizar(int id, Desejo desejoAtualizado);
    }
}
