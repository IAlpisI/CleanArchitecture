using Application.Common.Interface;
using Application.Extensions;
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
    public class UserService : IUserService
    {
        public async Task<User> AddUserAsync(string userName, string password, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new System.ArgumentException($"'{nameof(userName)}' cannot be null or empty", nameof(userName));
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new System.ArgumentException($"'{nameof(password)}' cannot be null or empty", nameof(password));
            }
            byte[] passwordHash = await ComputePassword(password, cancellationToken).ConfigureAwait(false);
            var newUser = new User(userName, passwordHash);


            return newUser;
        }

        private static async Task<byte[]> ComputePassword(string password, CancellationToken cancellationToken)
        {
            using SHA256 sha256 = SHA256.Create();
            using Stream passwordStream = password.ToStream();
            byte[] passwordHash = await sha256.ComputeHashAsync(
                passwordStream, cancellationToken).ConfigureAwait(false);
            return passwordHash;
        }
    }
}
