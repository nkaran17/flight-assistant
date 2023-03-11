namespace FlightAssistant.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IAirportRepository Airports { get; }
        ICurrencyRepository Currencies { get; }
        IFlightRepository Flights { get; }
        Task<int> Complete();
    }
}
