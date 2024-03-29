﻿using NHibernate.Linq;
using PolicyService.Domain;
using ISession = NHibernate.ISession;
namespace PolicyService.DataAccess.NHibernate
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly ISession session;

        public PolicyRepository(ISession session)
        {
            this.session = session;
        }

        public void Add(Policy policy)
        {
            session.Save(policy);
        }

        public async Task<Policy> WithNumber(string number)
        {
            return await session.Query<Policy>().FirstOrDefaultAsync(p => p.Number == number);
        }
    }
}
