namespace PolicyService.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IOfferRepository Offers { get; }

        IPolicyRepository Policies { get; }

        Task CommitChanges();
    }
}
