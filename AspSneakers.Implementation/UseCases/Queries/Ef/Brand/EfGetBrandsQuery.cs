using AspSneakers.Application.UseCases.DTO;
using AspSneakers.Application.UseCases.DTO.Searches;
using AspSneakers.Application.UseCases.Queries;
using AspSneakers.Application.UseCases.Queries.Brand;
using AspSneakers.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.UseCases.Queries.Ef.Brand
{
    public class EfGetBrandsQuery : EfUseCase, IGetBrandsQuery
    {
        public EfGetBrandsQuery(SneakersDbContext context) : base(context)
        {
        }

        public int Id => 6;

        public string Name => "Search brands.";

        public string Description => "";

        public PagedResponse<BrandDto> Execute(BasePagedSearch search)
        {
            var query = Context.Brands.AsQueryable();
            var keyword = search.Keyword;

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            };

            if (search.PerPage == null || search.PerPage < 1)
            {
                search.PerPage = 10;
            }

            if (search.Page == null || search.Page < 1)
            {
                search.PerPage = 1;
            }

            var toSkip = (search.Page.Value - 1) * search.PerPage.Value;

            var response = new PagedResponse<BrandDto>();
            response.TotalCount = query.Count();
            response.Data = query.Skip(toSkip).Take(search.PerPage.Value).Select(x => new BrandDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            response.CurrentPage = search.Page.Value;
            response.ItemsPerPage = search.PerPage.Value;

            return response;
        }
    }
}
