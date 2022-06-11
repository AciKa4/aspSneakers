using AspSneakers.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        protected EfUseCase(SneakersDbContext context)
        {
            Context = context;
        }

        protected SneakersDbContext Context { get; }
    }
}
