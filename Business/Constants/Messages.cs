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
        public static string CarNameInvalid = "Operation failed. The car name must be greater then 2 chcracters.";
        public static string CarDailyPriceInvalid = "Operation failed. The car daily price must be greater then 0.";
        public static string MakeMessage(string message1, string message2)
        {
            return (message1 + " " + message2);
        }
    }
}
