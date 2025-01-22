using Microsoft.EntityFrameworkCore;
using OnlineSurvey.Repos;
using OnlineSurvey.Services.Contract;
using System;
using System.Linq;


namespace OnlineSurvey.Services.Implementation
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entities;

        public GenericRepo(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        void IGenericRepo<T>.Delete(object entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            T existing = _entities.Find(entity);
            _entities.Remove(existing);
        }

        async Task<T> IGenericRepo<T>.Get(int id)
        {
            //return entities.SingleOrDefault(s => s.Id == id);
            return null;
        }

        async Task<IEnumerable<T>> IGenericRepo<T>.GetAll()
        {
            return _entities.AsEnumerable();
        }

        void IGenericRepo<T>.Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                _entities.Add(entity);
                _context.Entry(entity).State = EntityState.Added;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        void IGenericRepo<T>.Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
        }

        void IGenericRepo<T>.SaveChanges()
        {
            _context.SaveChanges();
        }
        async Task IGenericRepo<T>.SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        void IGenericRepo<T>.Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task<T> GetBy(object entity)
        {
            return await _entities.FindAsync(entity);
        }
    }
}
