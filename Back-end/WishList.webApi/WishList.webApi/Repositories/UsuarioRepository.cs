using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishList.webApi.Contexts;
using WishList.webApi.Domains;
using WishList.webApi.Interfaces;

namespace WishList.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        WishListContext ctx = new WishListContext();
        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = BuscarPorId(id);
            if (usuarioAtualizado.Senha != null)
            {
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
            }
            ctx.Usuarios.Update(usuarioBuscado);
            ctx.SaveChanges();
        }

        

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(d => d.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);
            ctx.SaveChanges();
        }

        

        public void Deletar(int id)
        {
            ctx.Usuarios.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios.ToList();
        }

        
    }
}
