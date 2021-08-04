using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ToDoTest();
            
        }

        private static void ToDoTest()
        {
            ToDoManager toDoManager = new ToDoManager(new EfToDoDal());
            foreach (var todo in toDoManager.GetAllToDoDetails())
            {
                Console.WriteLine(todo.Description);
            }
        }
    }
}
