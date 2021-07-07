using Domain.Entities.Particapant;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interface
{
    public interface IUserService
    {
        Task<User> AddUserAsync(string userName, string password, CancellationToken cancellationToken = default);
        Task<User> GetValidUserAsync(string userName, string clearTextPassword, CancellationToken cancellationToken = default);
    }
}
