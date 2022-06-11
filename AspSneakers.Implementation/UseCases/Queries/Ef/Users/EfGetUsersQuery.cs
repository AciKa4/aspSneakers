using AspSneakers.Application.UseCases.DTO;
using AspSneakers.Application.UseCases.DTO.Searches;
using AspSneakers.Application.UseCases.Queries;
using AspSneakers.Application.UseCases.Queries.Users;
using AspSneakers.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.UseCases.Queries.Ef.Users
{
    public class EfGetUsersQuery : EfUseCase, IGetUsersQuery
    {
        public EfGetUsersQuery(SneakersDbContext context) : base(context)
        {
        }

        public int Id => 18;

        public string Name => "Search users.";

        public string Description => "";

        public PagedResponse<UserDto> Execute(BasePagedSearch search)
        {
            var query = Context.Users.AsQueryable();
            var keyword = search.Keyword;

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.FirstName.Contains(keyword) || x.LastName.Contains(keyword) || x.Username.Contains(keyword));
            }

            if (search.PerPage == null || search.PerPage < 1)
            {
                search.PerPage = 10;
            }

            if (search.Page == null || search.Page < 1)
            {
                search.PerPage = 1;
            }

            var toSkip = (search.Page.Value - 1) * search.PerPage.Value;

            var response = new PagedResponse<UserDto>();
            response.TotalCount = query.Count();
            response.Data = query.Skip(toSkip).Take(search.PerPage.Value).Select(x => new UserDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address = x.Address,
                Username = x.Username,
                Email = x.Email
            }).ToList();

            response.CurrentPage = search.Page.Value;
            response.ItemsPerPage = search.PerPage.Value;

            return response;
        }
    }
}
