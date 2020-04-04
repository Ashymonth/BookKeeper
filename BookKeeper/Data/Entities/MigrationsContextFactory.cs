using System.Configuration;
using System.Data.Entity.Infrastructure;

namespace BookKeeper.Data.Data.Entities
{
    public class MigrationsContextFactory : IDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext Create()
        {
            return new ApplicationDbContext(ConfigurationManager.ConnectionStrings["BookKeeper"].ConnectionString);
        }
    }
}
