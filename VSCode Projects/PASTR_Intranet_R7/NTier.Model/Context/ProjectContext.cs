using NTier.Core.Entity;
using NTier.Core.Enums;
using NTier.Model.Entities;
using NTier.Model.Maps;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace NTier.Model.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = @"Server=ceoee\SQLEXPRESS;DataBase=Human;UID=sa;PWD=cEr10SQL";
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Directory> Directories { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(IMappingMarker).Assembly);
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
