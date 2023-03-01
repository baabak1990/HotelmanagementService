using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotlemanagment.Domain.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagement.Presistance.Configuration.CountryConfiguration
{
    public class CountryConfiguration:IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(new List<Country>()
            {
                new Country()
                {
                    Id = 1,
                    Name = "Iran",
                    ShortName = "IR"
                },
                new Country()
                {
                    Id = 2,
                    Name = "United States Of America",
                    ShortName = "USA"
                }
            });
        }
    }
}
