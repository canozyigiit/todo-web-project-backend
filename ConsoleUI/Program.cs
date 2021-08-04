using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ToDoManager toDoManager = new ToDoManager(new EfToDoDal());
            foreach (var todo in toDoManager.GetAll())
            {
                Console.WriteLine(todo.Description);   
                
            }
        }
    }
}
