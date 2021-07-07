using Application.Common.Interface;
using Domain.Entities.Particapant;
using Infastructure.Data.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Data.Repositories.UserRepository
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Role>> GetRoles(int userId)
        {
            var user = await _dbContext.Users.Include(x => x.Roles)
                .SingleOrDefaultAsync(x => x.Id == userId);

            return user.Roles;
        }

        public async Task<User> GetUserByName(string userName)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(x => string.Equals(userName, x.Name));
        }
    }
}
