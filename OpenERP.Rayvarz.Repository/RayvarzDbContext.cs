using AbrPlus.Integration.OpenERP.Rayvarz.Models;
using Microsoft.EntityFrameworkCore;
using SeptaKit.Repository.EFCore;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Repository
{
    public partial class RayvarzDbContext : BaseSqlServerDbContext<RayvarzDbContext>
    {
        public virtual DbSet<Customer> Accounts { get; set; }

        //new changes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Test", "dbo");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
