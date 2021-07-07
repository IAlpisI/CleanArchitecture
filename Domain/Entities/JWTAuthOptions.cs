using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class JWTAuthOptions
    {
        public const string SectionName = "JWTAuth";
        public string Secret { get; set; }
    }
}
