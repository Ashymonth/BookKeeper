using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
