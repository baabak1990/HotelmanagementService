using Hotelmanagment.Application.DTO.UserDTO;

namespace HotelListingInfrastructure.cs.Services;

public interface IAuthManager
{
    Task<bool> ValidateUser(LoginDTO loginDTO);
    Task<string> CreateToken();
}