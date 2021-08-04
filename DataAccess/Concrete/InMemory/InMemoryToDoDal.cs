using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.InMemory
{
   public class InMemoryToDoDal:IToDoDal
   {
       private List<Todo> _todos;

       public InMemoryToDoDal()
       {
           
       }
        public List<Todo> GetAll()
        {
            return _todos;
        }

        public List<Todo> GetAllByEmployee(int employeeId)
        {
           return _todos.Where(t => t.EmployeeId == employeeId).ToList();
        }

        public List<Todo> GetAllByManager(int managerId)
        {
            return _todos.Where(t => t.ManagerId == managerId).ToList();
        }

        public List<Todo> GetAllByIsEnded(bool isEnded)
        {
            return _todos.Where(t => t.IsEnded == isEnded).ToList();
        }

        public void Add(Todo todo)
        {
            _todos.Add(todo);
        }

        public void Update(Todo todo)
        {
            Todo toDoToUpdate = _todos.SingleOrDefault(t => t.ToDoId == todo.ToDoId);
         
        }

        public void Delete(Todo todo)
        {
            //LINQ - Language Integrated Query
            Todo toDoToDelete = _todos.SingleOrDefault(t =>t.ToDoId == todo.ToDoId);
            _todos.Remove(toDoToDelete);
        }

        public List<Todo> GetAll(Expression<Func<Todo, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Todo Get(Expression<Func<Todo, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ToDoDto> GetToDoDetails()
        {
            throw new NotImplementedException();
        }
   }
}
