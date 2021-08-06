using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Constants
{
   public static class Messages
    {
        public static string ToDoAdded = "ToDo eklendi";
        public static string ToDoListed = "Todolar listelendi";
        public static string EmployeeToDoListed = "Çalışana ait todolar listelendi";
        public static string ManagerToDoListed = "Yetkilinin atadığı todolar listelendi";
        public static string UnfinishedTodosListed = "Henüz bitmemiş todolar listelendi";
        public static string AppointedTodosListed = "Atanmış todolar listelendi";
        public static string UnAppointedTodosListed = "Atanmamış todolar listelendi";
        public static string ToDoFound = "Todo bulundu";
        internal static string ToDoAppointed = "Todo atandı";

        internal static string EmployeeAdded;
        internal static string EmployeeListed;
        internal static string EmployeeFound;

        internal static string ToDoUpdated;
        internal static string ManagerFound;
        internal static string ManagerAdded;
        internal static Expression<Func<Manager, bool>> ManagerListed;
    }
}
