using Ardalis.Specification;
using Domain.Entities.Particapant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Specification
{
    public class UserByIdWithRoles: Specification<User>, ISingleResultSpecification
    {
        public UserByIdWithRoles(int userId)
        {
            Query.Where(x => x.Id == userId)
                .Include(x => x.Roles);
        }
    }
}
