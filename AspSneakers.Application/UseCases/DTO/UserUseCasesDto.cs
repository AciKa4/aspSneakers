using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Application.UseCases.DTO
{
    public class UserUseCasesDto
    {
        public int UserId { get; set; }
        public IEnumerable<int> UseCaseIds { get; set; }
    }
    public class UserUseCasesSearch
    {
        public string UseCaseName { get; set; }
        public string Email { get; set; }
    }
    public class GetUserUseCasesDto
    {
        public string UseCaseName { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public DateTime ExecutionTime { get; set; }
        public string Data { get; set; }
        public bool isAuthorize { get; set; }
    }
}
