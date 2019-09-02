using Tracker.Api.Context;
using Tracker.Entity.Entities;

namespace Tracker.IntegrationTests
{
    public class DataSeeder
    {

        public static void Seed(ApplicationDbContext context)
        {
            context.Billses.Add(new Bills
            {
                Price = 123,
                CategoryId = 1
            });
            
            context.Billses.Add(new Bills
            {
                Price = 11425,
                CategoryId = 2
            });

            context.Billses.Add(new Bills
            {
                Price = 12332,
                CategoryId = 1
            });

            context.Categories.Add(new Category
            {
                Title = "Shop"
            });

            context.Categories.Add(new Category
            {
                Title = "Marked"
            });
            
            context.Categories.Add(new Category
            {
                Title = "Manager"
            });
        }
        
    }
}