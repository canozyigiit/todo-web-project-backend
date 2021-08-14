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
        public static string UnfinishedTodosListed = "Tamamlanmış todolar listelendi";
        internal static string FinishedTodosListed = "Tamamlanmış todolar listelendi";
        internal static string ToDoDeleted = "Todo silindi";
        public static string AppointedTodosListed = "Atanmış todolar listelendi";
        public static string UnAppointedTodosListed = "Atanmamış todolar listelendi";
        public static string ToDoFound = "Todo bulundu";
        public static string ToDoAppointed = "Todo atandı";
        public static string ToDoUpdated = "Todo güncellendi";

        public static string EmployeeAdded = "Yeni çalışan eklendi";
        public static string EmployeeListed = "Çalışanlar listelendi";
        public static string EmployeeFound = "Çalışan bulundu";
        public static string EmployeeNotFound = "Çalışan bulunamadı";

        public static string ManagerFound = "Manager bulundu";
        public static string ManagerAdded = "Manager eklendi";
        public static string ManagerListed = "Managerlar listelendi";


        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";


        public static string UserFound = "Kullanıcı bulundu";
        public static string UserAdded = "Kullanıcı sisteme eklendi";
        public static string UserUpdated = "Kullanıcı güncellendi";

        public static string UserClaimsListed = "Kullanıcı rolleri listelendi";
        public static string UserOperationClaimAdded = "Kullanıcıya yeni rol eklendi";
        public static string UserOperationClaimDeleted = "Kullanıcıya ait rol silindi";
        public static string UserOperationClaimUpdated = "Kullanıcının rolü güncellendi";
        public static string UserOperationClaimListed = "Kullanıcı rolleri listelendi";
        public static string UserOperationClaimFound = "Kullanıcıya ait rol bulundu";

        public static string OperationClaimAdded = "Yeni rol sisteme eklendi";
        public static string OperationClaimUpdated = "Rol güncellendi";
        public static string OperationClaimDeleted = "Rol silindi";
        public static string OperationClaimFound = "Rol bulundu";
        public static string OperationClaimListed = "Sistemdeki roller listelendi";


        public static string UserMadeEmployee = "Kullanıcı çalışan yapıldı";
        public static string UserMadeManager = "Kullanıcı yetkili yapıldı";
        public static string UserMadeDirector = "Kullanıcıya director rolü verildi";
    }
}
