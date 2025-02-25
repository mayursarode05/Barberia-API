using Barberia.Application.Repositories.IRepositories;
using Barberia.Infrastructure.Data;
using System;

namespace Barberia.Application.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BarberiaDbContext _context;

        public IUserRepository UserRepository { get; private set; }
        public UnitOfWork(BarberiaDbContext appDbContext)
        {
            _context = appDbContext;
            UserRepository = new UserRepository(_context);
        }
        public IUserRepository userRepository 
        {
            get
            {
                return UserRepository ??= new UserRepository(_context);
            }
        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }

        public IRepository<T> Repository<T>() where T : class
        {
            throw new NotImplementedException();
        }
    }
}
