namespace FlightAssistant.Core.Repositories
{
    public interface IUnitOfWork
    {
        ILogRepository LogRepo { get; }
        IAirportRepository AirportRepo { get; }
        Task<int> CommitAsyncAppDbContext();
    }
}
