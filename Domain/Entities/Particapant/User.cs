using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Player
{
    public class User : ModificationEntity
    {
        public string Name { get; }
        public byte[] PasswordHash { get; }
        public List<Role> Roles { get; } = new List<Role>();

        public User(string name, byte[] passwordHash)
        {
            Name = name;
            PasswordHash = passwordHash;
        }
    }
}
