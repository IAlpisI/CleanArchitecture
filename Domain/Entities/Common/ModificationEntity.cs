using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Common
{
    public abstract class ModificationEntity : BaseEntity
    {
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}
