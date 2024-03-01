namespace PaymentService.Domain
{
    public interface IDataStore : IDisposable
    {
        IPolicyAccountRepository PolicyAccounts { get; }

        Task CommitChanges();
    }
}
