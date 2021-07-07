using Domain.Entities.Common;
using System.Collections.Generic;

namespace Domain.Entities.Particapant
{
    public class User : ModificationEntity
    {
        public string Name { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public List<Role> Roles { get; private set; } = new List<Role>();

        public User(string name, byte[] passwordHash)
        {
            Name = name;
            PasswordHash = passwordHash;
        }

        public User() { }
    }
}
