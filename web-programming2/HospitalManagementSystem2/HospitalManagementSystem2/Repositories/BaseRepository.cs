using HospitalManagementSystem2.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HospitalManagementSystem2.Repositories
{
    public class BaseRepository<T> where T : BaseEntity
    {
        

        protected  DbContext Context { get; private set; }
        protected DbSet<T> Items { get; set; }

       

        public BaseRepository(DbContext DBContext)
        {
            Context = DBContext;
            Items = Context.Set<T>();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            return Items.Where(filter).FirstOrDefault();
        }
        public T GetById(int id)
        {

            return Items.Where(i => i.Id == id)
                                .FirstOrDefault();
        }
        public List<T> GetAll(Expression<Func<T, bool>> filter = null, int page = 1, int pageSize = int.MaxValue)
        {
            IQueryable<T> query = Items;
            
            if (filter != null)
            {
                query = query.Where(filter);
            }
            page = page <= 0 ? 1 : page;
            pageSize = pageSize <= 0 ? 10 : pageSize;

            query = query.OrderBy(i => i.Id).Skip((page - 1) * pageSize).Take(pageSize);

            return query.ToList();
        }
        public int Count(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = Items;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.Count();
        }
        public void Save(T item)
        {
            if (item.Id <= 0)
                Insert(item);
            else
                Update(item);
        }
        public void Insert(T item)
        {
            Items.Add(item);

            Context.SaveChanges();
        }
        public void Update(T item)
        {

            Context.Entry(item).State = EntityState.Modified;

            Context.SaveChanges();
        }
        public void Delete(T item)
        {
            Items.Remove(item);
            Context.SaveChanges();
        }
    }
}