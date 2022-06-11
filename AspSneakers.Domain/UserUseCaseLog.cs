using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Domain
{
    public class UserUseCaseLog : Entity
    {
        public string UseCaseName { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
        public DateTime ExecutionTime { get; set; }
        public string Data { get; set; }
        public bool isAuthorize { get; set; }
    }
}
