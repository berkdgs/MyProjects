using NTier.Core.Entity;
using NTier.Core.Enums;
using NTier.Maintenance.Model.Entities;
using NTier.Maintenance.Model.Maps;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NTier.Maintenance.Model.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = @"Server=CEOEE\SQLEXPRESS;DataBase=Maintenance;UID=sa;PWD=cEr10SQL";
        }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(WorkerMap).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified).ToList();
            foreach (var item in modifiedEntries)
            {
                CoreEntity nesne = (CoreEntity)item.Entity;
                if (item != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        nesne.CreatedDate = DateTime.Now;
                        nesne.CreatedComputerName = HttpContext.Current.Request.UserHostName; //Environment.MachineName;
                        nesne.CreatedUserName = HttpContext.Current.User.Identity.Name;
                        nesne.Status = Status.Active;
                    }
                    else if (item.State == EntityState.Modified)
                    {
                        nesne.ModifiedDate = DateTime.Now;
                        nesne.ModifiedComputerName = HttpContext.Current.Request.UserHostName;//  Environment.MachineName;
                        nesne.ModifiedUserName = HttpContext.Current.User.Identity.Name; //WindowsIdentity.GetCurrent().Name;
                        if (nesne.Status != Status.Deleted)
                            nesne.Status = Status.Updated;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
