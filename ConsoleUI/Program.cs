using System;
using Business.Concrete;
using Core.Utilities.Results;
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
            var result = toDoManager.GetAll();
            if (result.Success == true)
            {
                foreach (var todo in result.Data)
                {
                    Console.WriteLine(result.Data + result.Message + result.Success);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
    }
}
