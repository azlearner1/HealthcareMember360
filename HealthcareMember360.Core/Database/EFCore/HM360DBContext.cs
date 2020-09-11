using Microsoft.EntityFrameworkCore;

namespace HealthcareMember360.Core
{
    public class HM360DBContext : DbContext
    {
        public HM360DBContext(DbContextOptions<HM360DBContext> options) : base(options)
        {
        }

        public virtual DbSet<Claims> Claims { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<Physican> Physican { get; set; }
        public virtual DbSet<ClaimTypes> ClaimTypes { get; set; }
    }
}
