using AspSneakers.Domain;
using System.Collections.Generic;

namespace AspSneakers.Api.Core
{
    public class JwtUser : IApplicationUser
    {
        public string Identity { get; set; }

        public int Id { get; set; }
        public IEnumerable<int> UseCaseIds { get; set; } = new List<int>();
        public string Email { get; set; }
    }

    public class AnonimousUser : IApplicationUser
    {
        public string Identity => "Anonymous";

        public int Id => 0;

        public IEnumerable<int> UseCaseIds => new List<int> { 1,3,6,10,15,21,25 };

        public string Email => "anonymous@gmail.com";
    }
}
