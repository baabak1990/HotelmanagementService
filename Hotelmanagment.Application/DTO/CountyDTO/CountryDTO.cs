using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotelmanagment.Application.DTO.Common;
using Hotelmanagment.Application.DTO.HotleDTO;
using Hotlemanagment.Domain.Entity.Entities;

namespace Hotelmanagment.Application.DTO.CountyDTO
{
    public class CountryDTO : CommonBaseDTO, ICountryDTO
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public List<HotelDTo>? Hotels { get; set; }
    }
}
