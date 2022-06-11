using AspSneakers.Application.UseCases;
using AspSneakers.DataAccess;
using AspSneakers.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.UseCases.UseCaseLogger
{
    public class EfUseCaseLogger : IUseCaseLogger 
    {
        private SneakersDbContext _context;

        public EfUseCaseLogger(SneakersDbContext context)
        {
            _context = context;
        }

        public void Log(UseCaseLog log)
        {
            var userUseCaseLog = new UserUseCaseLog
            {
                UseCaseName = log.UseCaseName,
                UserId = log.UserId,
                Username = log.User,
                ExecutionTime = log.ExecutionDateTime,
                Data = log.Data,
                isAuthorize = log.IsAuthorized
            };

            _context.UserUseCaseLogs.Add(userUseCaseLog);
            _context.SaveChanges();
        }
    }
}
