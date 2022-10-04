using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WEA.Persistance.Entity;

namespace WEA.Persistance.WEADbContext
{
    public class WEAContext:DbContext
    {
        public WEAContext(DbContextOptions<WEAContext> options):base(options)
        {

        }
        public DbSet<User> TblUser { get; set; }
        public DbSet<SavingAccount> TblSavingAccount { get; set; }
        public DbSet<NGO> TblNGO { get; set; }
        public DbSet<FAQ> TblFAQ { get; set; }
        public DbSet<Course> TblCourse { get; set; }
        public DbSet<Children> TblChildren { get; set; }
        public DbSet<BasicInfo> TblBasicInfo { get; set; }
        public DbSet<UserQualification> TblQualification { get; set; }
        public DbSet<CourseJoining> TblCourseJoining { get; set; }

    }
}
