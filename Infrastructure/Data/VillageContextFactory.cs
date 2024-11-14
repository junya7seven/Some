/*using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class VillageContextFactory : IDesignTimeDbContextFactory<VillageContext>
    {
        public VillageContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Path.Combine("..", "RestApiCRUD", "appsettings.json")) // Укажите путь к appsettings.json
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<VillageContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("VillageContext"));

            return new VillageContext(optionsBuilder.Options);
        }
    }
}
*/