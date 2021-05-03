using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QCP.Trading.ProductManagement.DataAccessComponent.DataContext
{
    public partial class ProductManagementDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string filePath = Path.GetFullPath("appConfig.json");

                JObject dbInfo = null;
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string json = reader.ReadToEnd();
                    dbInfo = JsonConvert.DeserializeObject<JObject>(json);
                }

                optionsBuilder.UseSqlServer(Convert.ToString(dbInfo.GetValue("ConnectionString")));
            }
        }
    }
}
