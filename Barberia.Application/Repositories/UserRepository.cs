using Barberia.Application.Repositories.IRepositories;
using Barberia.Core.Entities;
using Barberia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barberia.Application.Repositories
{
    public class UserRepository : Repository<AppUser>,IUserRepository
    {
        private readonly BarberiaDbContext _db;
        public UserRepository(BarberiaDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<AppUser?> GetUserByEmail(string userEmail)
        {
            return await _db.AppUsers.Where(x => x.Email == userEmail).FirstOrDefaultAsync();
        }
    }
}
