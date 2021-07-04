using Domain.Entities.Player;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infastructure.Services
{
    public class UserService
    {
        public async Task<User> AddUSerAsync(string userName, string password, CancellationToken cancellationToken)
        {
            byte[] passwordHash = await ComputePassowrd(password).ConfigureAwait(false);
            var newUser = new User(userName, passwordHash);


            return newUser;
        }

        private async Task<byte[]> ComputePassword(string password, CancellationToken cancellationToken)
        {
            using SHA256 sha256 = SHA256.Create();
            using Stream passwordStream = password.ToStream();
            byte[] passwordHash = await sha256.ComputeHashAsync(
                passwordStream, cancellationToken).ConfigureAwait(false);
            return passwordHash;
        }
    }
}
