using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Application.UseCases.DTO.Searches
{
    public class OrderSearch : PagedSearch
    {
        public int? userId { get; set; }
    }
}
