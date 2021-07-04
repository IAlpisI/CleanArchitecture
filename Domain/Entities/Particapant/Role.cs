using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Player
{
    public class Role : BaseEntity
    {
        public string Name { get; }
        public List<User> Users { get; } = new List<User>();
    }
}
