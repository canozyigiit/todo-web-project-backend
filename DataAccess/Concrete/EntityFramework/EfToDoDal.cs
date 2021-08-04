using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfToDoDal:IToDoDal
    {
        public void Add(Todo entity)
        {
            using (TodoContext context = new TodoContext())
            {
                var addedEntity = context.Entry(entity);//referansı yakala  
                addedEntity.State = EntityState.Added;//eklenecek nesne
                context.SaveChanges();//işlemleri kaydet
            }
        }

        public void Update(Todo entity)
        {
            using (TodoContext context = new TodoContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Todo entity)
        {
            using (TodoContext context = new TodoContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Todo> GetAll(Expression<Func<Todo, bool>> filter = null)
        {
            using (TodoContext context = new TodoContext())
            {
                return filter == null ? context.Set<Todo>().ToList() : context.Set<Todo>().Where(filter).ToList();
            }
        }

        public Todo Get(Expression<Func<Todo, bool>> filter)
        {
            using (TodoContext context = new TodoContext())
            {
                return context.Set<Todo>().SingleOrDefault(filter);
            }
        }
    }
}
