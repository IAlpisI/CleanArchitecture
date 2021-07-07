using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interface
{
    public interface ITokenService
    {
        Task<string> GetAccessTokenAsync(string userName, string clearTextPassword, CancellationToken cancellationToken = default);
    }
}
