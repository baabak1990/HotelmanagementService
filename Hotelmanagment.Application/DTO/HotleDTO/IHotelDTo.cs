using Hotelmanagment.Application.DTO.CountyDTO;
using Hotlemanagment.Domain.Entity.Entities;

namespace Hotelmanagment.Application.DTO.HotleDTO;

public interface IHotelDTo
{
    public string Name { get; set; }
    public double Rate { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public int CountryId { get; set; }
}