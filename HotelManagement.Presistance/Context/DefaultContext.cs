using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Presistance.Configuration.CountryConfiguration;
using HotelManagement.Presistance.Configuration.HotelConfigurations;
using HotelManagement.Presistance.Configuration.RoleConfiguration;
using Hotlemanagment.Domain.Entity.Common;
using Hotlemanagment.Domain.Entity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HotelManagement.Presistance.Context
{
    public class DefaultContext:IdentityDbContext<ApiUser>
    {
        public DefaultContext(DbContextOptions<DefaultContext> options):base(options)
        {
            
        }

        #region ModelBuilderConfigs
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DefaultContext).Assembly);
            //modelBuilder.ApplyConfiguration(new HotelConfiguration());
            //modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

        #endregion
        #region Dbset

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        #endregion
    }
}
