using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages//newlemeye gerek kalmadan kullanmak için böyle static koyuyoruz
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "sistem bakımda";
        public static string ProductsListed = "ürünler listelendi";

        public static string ProductCountOfCategoryError = "Categorideki ürün sayısı max 10 olmalı";

        public static string ProductNameAlreadyExist = "Bu isimde zaten başka bir ürün var ";
        public static string CategoryLimitExceed = "Kategori limiti aşıldığı için yeni bir ürün eklenemiyor";

        public static string AuthorizationDenied = "yetkiniz yok";
    }
}
