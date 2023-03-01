using Hotlemanagment.Domain.Entity.Entities;

namespace Hotelmanagment.Application.Contract.Repository;

public interface IUnitOfWork:IDisposable
{
     IGenericRepository<Country> Countries { get;}
     IGenericRepository<Hotel> Hotel { get;  }

    Task Save();
}