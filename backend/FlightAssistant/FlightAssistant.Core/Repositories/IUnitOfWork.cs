namespace FlightAssistant.Core.Repositories
{
    public interface IUnitOfWork
    {
        ILogRepository LogRepo { get; }
    }
}
