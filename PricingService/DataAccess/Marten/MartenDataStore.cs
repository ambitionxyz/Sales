using Marten;
using PricingService.Domain;

namespace PricingService.DataAccess.Marten
{
    public class MartenDataStore : IDataStore
    {
        private readonly IDocumentSession _session;

        public MartenDataStore(IDocumentStore documentStore)
        {
            _session = documentStore.LightweightSession();
            Tariffs = new MartenTariffRepository(_session);
        }
        public ITariffRepository Tariffs { get; }

        public async Task CommitChanges()
        {
            await _session.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) _session.Dispose();
        }
    }
}
