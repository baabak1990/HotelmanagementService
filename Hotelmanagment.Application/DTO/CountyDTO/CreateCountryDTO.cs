using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelmanagment.Application.DTO.CountyDTO
{
    public class CreateCountryDTO:ICountryDTO
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
