using AppMercado.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AppMercado.Repositories
{
    public class BaseRepository<T> where T : class
    {

        protected readonly appDbContext _contexto;
        protected readonly DbSet<T> dbSet;
        public BaseRepository(appDbContext contexto)
        {
            this._contexto = contexto;
            dbSet =_contexto.Set<T>();
        }
        public List<T> getAll()
        {
            
            return dbSet.ToList();
        }
    }
}
