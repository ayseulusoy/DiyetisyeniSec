using DiyetisyeniSec.Domain.Nutritionist;
using Microsoft.EntityFrameworkCore;


namespace DiyetisyeniSec.Data
{
    public class DiyetisyenDbContext:DbContext
    {
        public DiyetisyenDbContext(DbContextOptions<DiyetisyenDbContext> test) : base(test) //test parametredir ve startuptaki options ı karşılar.
        {

        }
        public DbSet<Nutritionist> Nutritionists { get; set; }
    }
}
