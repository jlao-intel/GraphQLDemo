using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConferencePlanner.GraphQL.Data;
using GreenDonut;
using HotChocolate.DataLoader;
using NLog;
using GraphQL.Utilities;

namespace ConferencePlanner.GraphQL.DataLoader
{
    public class SessionByIdDataLoader : BatchDataLoader<int, Session>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        public SessionByIdDataLoader(
            IBatchScheduler batchScheduler,
            IDbContextFactory<ApplicationDbContext> dbContextFactory)
            : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<int, Session>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            await using ApplicationDbContext dbContext =
                _dbContextFactory.CreateDbContext();
            var sessions = await dbContext.Sessions
                .Where(s => keys.Contains(s.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);

            //error handling in graphql
            if (sessions.Count == 0)
            {
                NetLogger.GetInstance().Error("Exception: Cannot find data with corresponding ID");
                throw new ApplicationException($"Cannot find session with Id"); 
            }
            else
            {
                NetLogger.GetInstance().Info("Session data found.");
                return sessions;
            }

        }
    }
}