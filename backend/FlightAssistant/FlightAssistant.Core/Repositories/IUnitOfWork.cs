namespace FlightAssistant.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IAirportRepository Airports { get; }
        Task<int> Complete();
    }
}
