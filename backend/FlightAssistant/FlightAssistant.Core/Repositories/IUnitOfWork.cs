namespace FlightAssistant.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IAirportRepository Airports { get; }
        ICurrencyRepository Currencies { get; }
        Task<int> Complete();
    }
}
