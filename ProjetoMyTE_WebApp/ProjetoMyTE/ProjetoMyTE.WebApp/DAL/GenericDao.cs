using Microsoft.EntityFrameworkCore;
using ProjetoMyTE.WebApp.Models.Contexts;

namespace ProjetoMyTE.WebApp.DAL
{
    //paramentrização com classes
    public class GenericDao<T> where T : class
    {
        public MyTEContext Context { get; set; }

        //construtor
        public GenericDao(MyTEContext context)
        {
            this.Context = context;
        }

        //listando entidades, metodo generico para se aplicar a todos os models
        public IEnumerable<T> Listar()
        {
            return Context.Set<T>().ToList();
        }

        //buscando a entidade pelo id dela
        public T? Buscar(int id)
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
