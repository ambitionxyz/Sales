using AuthService.Domain;
using System.Collections.Concurrent;

namespace AuthService.DataAccess
{
    public class InsuranceAgentsInMemoryDb : IInsuranceAgents
    {

        private readonly IDictionary<string, InsuranceAgent> _db = new ConcurrentDictionary<string, InsuranceAgent>();

        public InsuranceAgentsInMemoryDb()
        {
            Add(new InsuranceAgent("jimmy", "secret", "https://images.pexels.com/photos/19501713/pexels-photo-19501713/free-photo-of-th-i-trang-dan-ba-dem-t-i.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2",
    new List<string> { "TRI", "HSI", "FAI", "CAR" }));
            Add(new InsuranceAgent("danny", "secret", "https://images.pexels.com/photos/18897390/pexels-photo-18897390/free-photo-of-th-i-trang-dan-ba-ngoai-d-ng.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load",
                new List<string> { "TRI", "HSI", "FAI", "CAR" }));
            Add(new InsuranceAgent("admin", "admin", "https://images.pexels.com/photos/9180717/pexels-photo-9180717.jpeg?auto=compress&cs=tinysrgb&w=800",
                new List<string> { "TRI", "HSI", "FAI", "CAR" }));
        }
        public void Add(InsuranceAgent agent)
        {
            _db[agent.Login] = agent;
        }

        public InsuranceAgent FindByLogin(string login)
        {
            return _db[login];
        }
    }
}
