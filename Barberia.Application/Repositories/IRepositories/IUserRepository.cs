using Barberia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barberia.Application.Repositories.IRepositories
{
    public interface IUserRepository : IRepository<AppUser>
    {
        Task<AppUser?> GetUserByEmail(string userEmail);
    }
}
