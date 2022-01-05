using Microsoft.EntityFrameworkCore;
using RestWithASP.Model.Base;
using RestWithASP.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASP.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySqlContext _context;
        private DbSet<T> _dataSet;

        public GenericRepository(MySqlContext context)
        {
            _context = context;
            _dataSet = context.Set<T>();
        }
        public T Create(T item)
        {
            try
            {
                _dataSet.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void Delete(long id)
        {
            var result = _dataSet.SingleOrDefault(x => x.Id.Equals(id));

            if (result == null) return;

            try
            {
                _dataSet.Remove(result);
                _context.SaveChanges();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public bool Exists(long id)
        {
            return _dataSet.Any(p => p.Id.Equals(id));
        }

        public IEnumerable<T> FindAll()
        {
            return _dataSet.ToList();
        }

        public T FindById(long id)
        {
            return _dataSet.SingleOrDefault(x => x.Id.Equals(id));
        }

        public T Update(T item)
        {
            var result = _dataSet.SingleOrDefault(x => x.Id.Equals(item.Id));

            if (result == null) return null;

            try
            {
                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();
                return result;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
