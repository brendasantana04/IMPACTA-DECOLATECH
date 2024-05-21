using Microsoft.EntityFrameworkCore;
using ProjetoMyRh.API.Models.Contexts;

namespace ProjetoMyRh.API.DAL
{
    public class GenericDao<T, K> where T : class
    {
        public MyRhContext Context { get; set; }

        public GenericDao(MyRhContext context)
        {
            this.Context = context;
        }

        //listando todas as entidades
        public IEnumerable<T> Listar()
        {
            return Context.Set<T>().ToList();
        }
        //BUSCANDO UMA ENTIDADE PELO ID
        public T? Buscar(K id)
        {
            return Context.Set<T>().Find(id);
        }
        //adicionar entidades
        public void Adicionar(T item)
        {
            Context.Add<T>(item).State = EntityState.Added;
            Context.SaveChanges();
        }

        //alterar entidades
        public void Alterar(T item)
        {
            Context.Entry<T>(item).State = EntityState.Modified;
            Context.SaveChanges();
        }

        //remover entidades
        public void Remover(T item)
        {
            Context.Entry<T>(item).State = EntityState.Deleted;
            Context.SaveChanges();
        }
    }
}
