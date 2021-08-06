using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.Serialization;
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
        public static string ToDoAppointed = "Todo atandı";
        public static string ToDoUpdated = "Todo güncellendi";

        public static string EmployeeAdded = "Yeni çalışan eklendi";
        public static string EmployeeListed = "Çalışanlar listelendi";
        public static string EmployeeFound = "Çalışan bulundu";
        internal static string EmployeeNotFound = "Çalışan bulunamadı";

        public static string ManagerFound = "Manager bulundu";
        public static string ManagerAdded = "Manager eklendi";
        public static string ManagerListed = "Managerlar listelendi";


        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

       
        internal static string UserFound;

        internal static string UserClaimsListed;
        internal static string UserOperationClaimAdded;
        internal static string UserOperationClaimDeleted;
        internal static string UserOperationClaimUpdated;
        internal static string UserOperationClaimListed;
        internal static string UserOperationClaimFound;

        internal static string OperationClaimAdded;
        internal static string OperationClaimUpdated;
        internal static string OperationClaimDeleted;
        internal static string OperationClaimFound;
        internal static string OperationClaimListed;
       
    }
}
