using AspSneakers.Application.UseCases.DTO;
using AspSneakers.Application.UseCases.DTO.Searches;
using AspSneakers.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Application.UseCases.Queries
{
    public interface IGetUserUseCasesQuery : IQuery<UserUseCasesSearch,IEnumerable<GetUserUseCasesDto>>
    {
    }
    
}
