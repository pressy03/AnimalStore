using AnimalStore.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalStore.DataOperators
{
    public class Repository
    {
        private AnimalStoreContext context;

        public Repository()
        {
            this.context = new AnimalStoreContext();
        }

        public DbSet<T> All<T>()
            where T : class
        {
            return context.Set<T>();
        }

        public void Add<T>(T entry)
            where T : class
        {
            context.Set<T>().Add(entry);
        }

        public void Remove<T>(T entry)
            where T : class
        {
            context.Set<T>().Remove(entry);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
