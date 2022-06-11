using AspSneakers.Application.UseCases.DTO;
using AspSneakers.Application.UseCases.DTO.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Application.UseCases.Queries.Roles
{
    public interface IGetRolesQuery : IQuery<BasePagedSearch, PagedResponse<RoleDto>>
    {
    }
}
