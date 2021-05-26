using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishList.webApi.Contexts;
using WishList.webApi.Domains;
using WishList.webApi.Interfaces;

namespace WishList.webApi.Repositories
{
    public class DesejoRepository : IDesejoRepository
    {
        WishListContext ctx = new WishListContext();
        public void Atualizar(int id, Desejo desejoAtualizado)
        {
            Desejo desejoBuscado = BuscarPorId(id);
            if(desejoAtualizado.Descricao != null)
            {
                desejoBuscado.Descricao = desejoAtualizado.Descricao;
            }
            ctx.Desejos.Update(desejoBuscado);
            ctx.SaveChanges();
        }

        public Desejo BuscarPorId(int id)
        {
            return ctx.Desejos.FirstOrDefault(d => d.IdDesejo == id);
        }

        public void Cadastrar(Desejo novoDesejo)
        {
            ctx.Desejos.Add(novoDesejo);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Desejos.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Desejo> ListarTodos()
        {
            return ctx.Desejos.ToList();
        }
    }
}
