using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Presistance.Context;
using Hotelmanagment.Application.Contract.Repository;
using Hotlemanagment.Domain.Entity.Entities;
using Microsoft.EntityFrameworkCore.Design.Internal;

namespace HotelManagement.Presistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DefaultContext _context;
        private IGenericRepository<Country> _countries;
        private IGenericRepository<Hotel> _hotel;

        public UnitOfWork(DefaultContext context)
        {
            _context = context;

        }

        public IGenericRepository<Country> Countries => _countries ??= new GenericRepository<Country>(_context);
        public IGenericRepository<Hotel> Hotel => _hotel ??= new GenericRepository<Hotel>(_context);

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
