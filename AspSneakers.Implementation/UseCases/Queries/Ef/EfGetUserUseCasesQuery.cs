using AspSneakers.Application.UseCases.DTO;
using AspSneakers.Application.UseCases.DTO.Searches;
using AspSneakers.Application.UseCases.Queries;
using AspSneakers.DataAccess;
using AspSneakers.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.UseCases.Queries.Ef
{
    public class EfGetUserUseCasesQuery : EfUseCase, IGetUserUseCasesQuery
    {
        public EfGetUserUseCasesQuery(SneakersDbContext context) : base(context)
        {
        }

        public int Id => 31;

        public string Name => "Search user use cases by username or by name of use case.";

        public string Description => "";

        public IEnumerable<GetUserUseCasesDto> Execute(UserUseCasesSearch search)
        {
            var query = Context.UserUseCaseLogs.AsQueryable();

            if (!string.IsNullOrEmpty(search.UseCaseName))
            {
                query = query.Where(x => x.UseCaseName.Contains(search.UseCaseName));
            }

            if (!string.IsNullOrEmpty(search.Email))
            {
                query = query.Where(x => x.Username.Contains(search.Email));
            }

            var usecases = query.Select(x => new GetUserUseCasesDto
            {

                UseCaseName = x.UseCaseName,
                Email = x.Username,
                UserId = x.UserId,
                Data = x.Data,
                isAuthorize = x.isAuthorize,
                ExecutionTime = x.ExecutionTime
            });

            return usecases;
        }
    }
}
