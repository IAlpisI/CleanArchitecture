using Domain.Entities.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interface
{
    public interface IUserService
    {
        Task<User> AddUserAsync(string userName, string password, CancellationToken cancellationToken = default);
    }
}
