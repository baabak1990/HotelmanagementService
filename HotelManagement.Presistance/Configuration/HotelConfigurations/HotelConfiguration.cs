using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotlemanagment.Domain.Entity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagement.Presistance.Configuration.HotelConfigurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(new List<Hotel>()
            {
                new Hotel
                {
                    Id = 1,
                    CountryId = 1,
                    Name = "Homa",
                    Address = "Tehran Azadi",
                    PhoneNumber = "02188888888",
                    Rate = "5"

                },
                new Hotel
                {
                    Id = 2,
                    CountryId = 2,
                    Name = "Esteghlal",
                    Address = "Tehran Esteghlal",
                    PhoneNumber = "0216666666",
                    Rate = "2"

                },
                new Hotel()
                {
                    Id = 3,
                    CountryId = 1,
                    Name = "Espinas",
                    Address = "Shiraz ",
                    PhoneNumber = "01355555588",
                    Rate = "5"

                }
            });
        }
    }
}
