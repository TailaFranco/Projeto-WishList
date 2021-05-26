using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishList.webApi.Domains;

namespace WishList.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> ListarTodos();

        Usuario BuscarPorId(int id);

        void Cadastrar(Usuario novoUsuario);

        void Deletar(int id);

        void Atualizar(int id, Usuario usuarioAtualizado);
    }
}
