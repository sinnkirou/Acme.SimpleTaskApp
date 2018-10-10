using Abp.EntityFrameworkCore;
using Acme.SimpleTaskApp.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Acme.SimpleTaskApp.EntityFrameworkCore
{
    public class SimpleTaskAppDbContext : AbpDbContext
    {

        public SimpleTaskAppDbContext(DbContextOptions<SimpleTaskAppDbContext> options) 
            : base(options)
        {

        }
    }
}
