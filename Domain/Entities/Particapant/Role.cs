using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Particapant
{
    public class Role : BaseEntity
    {
        public string Name { get; private set; }
        public List<User> Users { get; private set; } = new List<User>();

        public Role() { }
    }
}
