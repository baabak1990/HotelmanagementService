using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotelmanagment.Application.DTO.CountyDTO;

namespace Hotelmanagment.Application.DTO.HotleDTO
{
    public class CreateHotelDTo : IHotelDTo
    {
        public string Name { get; set; }
        public double Rate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int CountryId { get; set; }
    }
}
