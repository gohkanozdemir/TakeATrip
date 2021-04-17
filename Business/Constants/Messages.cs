using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AddedMessage = "added successfully.";
        public static string UpdatedMessage = "updated successfully.";
        public static string DeletedMessage = "deleted successfully.";
        public static string ListedMessage= "Urunler listelendi.";
        public static string FetchedMessage = "Kayit getiridi.";
        public static string CarNameInvalid = "Operation failed. The car name must be greater then 2 chcracters.";
        public static string CarDailyPriceInvalid = "Operation failed. The car daily price must be greater then 0.";
        public static string CarImageLimitedExceded = "Bu araba icin daha fazla resim yukleyemezsiniz!";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserRegistered = "Kullanici kaydedildi.";
        public static string PasswordError = "Hatali sifre.";
        public static string UserNotFound = "Kullanici bulunalamadi";
        public static string SuccessfulLogin = "Basarili giris.";
        public static string UserAlreadyExists = "Kullanici mevcut.";
        public static string AccessTokenCreated = "Token olusturuldu.";
        public static string MakeMessage(string message1, string message2)
        {
            return (message1 + " " + message2);
        }
    }
}
