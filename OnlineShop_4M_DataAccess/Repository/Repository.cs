using Microsoft.EntityFrameworkCore;
using OnlineShop_4M_DataAccess.Data;
using OnlineShop_4M_DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop_4M_DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        private DbSet<T> dbSet;
        public Repository(ApplicationDbContext context)
        {
            this.context = context;

            this.dbSet = context.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }
        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public T Find(int id)
        {
            return dbSet.Find(id);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null, bool IsTracking = true)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(','))
                {
                    query = query.Include(includeProp);
                }
            }
            
            if (!IsTracking)
            {
                query = query.AsNoTracking();
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null, bool IsTracking = true)
        {
            IQueryable<T> query = dbSet;
            if(filter!= null)
            {
                query = query.Where(filter);
            }
            if(includeProperties!= null)
            {
                foreach(var includeProp in includeProperties.Split(','))
                {
                    query=query.Include(includeProp);
                }
            }
            if(orderBy!= null)
            {
                query =orderBy(query);
            }
            if(!IsTracking)
            {
                query=query.AsNoTracking();
            }
            return query.ToList();
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
