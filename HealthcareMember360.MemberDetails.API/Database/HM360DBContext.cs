using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthcareMember360.MemberDetails
{
    public class HM360DBContext : DbContext
    {
        public HM360DBContext(DbContextOptions<HM360DBContext> options) : base(options)
        {
        }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<Physican> Physican { get; set; }
    }
}
