using YesterdaylandAPI.Models;
using System.Linq;

//Put data on database to test
namespace YesterdaylandAPI.Data
{
    public static class DataSeeder
    {
        public static void Seed(YesterdaylandContext context)
        {
            if (!context.Customers.Any())
            {
                context.Customers.AddRange(
                    new Customer { Name = "John Doe", Email = "john.doe@example.com" },
                    new Customer { Name = "Jane Smith", Email = "jane.smith@example.com" }
                );
                context.SaveChanges();
            }
        }
    }
}
