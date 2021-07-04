using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Tournament: ModificationEntity
    {
        public string Name { get; private set; }
        public string GameName { get; private set; }
        public int PlayerCount { get; private set; }
        public bool OpenSignUp { get; private set; }
        public List<User> Players { get; private set; } = new List<User>();
        public List<Match> Matches { get; private set; } = new List<Match>();
    }
}
