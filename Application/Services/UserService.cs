using Application.Common.Interface;
using Application.Extensions;
using Domain.Entities.Particapant;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
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

            await _userRepository.AddAsync(newUser, cancellationToken);

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

        public async Task<User> GetValidUserAsync(string userName, string clearTextPassword, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByName(userName);
            byte[] passwordHash = await ComputePassword(clearTextPassword, cancellationToken).ConfigureAwait(false);
            if(passwordHash.SequenceEqual(user.PasswordHash))
            {
                return user;
            }
            return null;


        }
    }
}
