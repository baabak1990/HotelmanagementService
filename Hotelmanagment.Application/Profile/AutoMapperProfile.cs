using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotelmanagment.Application.DTO.CountyDTO;
using Hotelmanagment.Application.DTO.HotleDTO;
using Hotlemanagment.Domain.Entity.Entities;

namespace Hotelmanagment.Application.Profile
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            #region Hotel

            CreateMap<Hotel, HotelDTo>().ReverseMap();
            CreateMap<Hotel, CreateHotelDTo>().ReverseMap();

            #endregion
            #region Country

            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, CreateCountryDTO>().ReverseMap();

            #endregion
        }
    }
}
