using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using BAI_3_UPDATE.Models;
using Newtonsoft.Json;
using BAI_3_UPDATE.Services;

namespace BAI_3_UPDATE.Services
{
    static class SetupDataServices
    {
        public static Shop SetupData()
        {
            Shop newShop = new Shop();
            if (File.Exists(FilePath.StrDataFileFullPath))
            {
                newShop = JsonConvert.DeserializeObject<Shop>(FileJsonServices.ReadFileJson(FilePath.StrDataFileFullPath));
            }
            if (File.Exists(FilePath.StrOrderHistoryFileFullPath))
            {
                newShop.OrderHistoryOfShop = JsonConvert.DeserializeObject<OrderHistory>(FileJsonServices.ReadFileJson(FilePath.StrOrderHistoryFileFullPath));
            }
            return newShop;
        }
    }
}
