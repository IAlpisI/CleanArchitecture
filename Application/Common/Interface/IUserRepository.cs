using Domain.Entities.Particapant;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Common.Interface
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<IEnumerable<Role>> GetRoles(int userId);
        Task<User> GetUserByName(string userName);
    }
}
