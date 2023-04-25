namespace TestTesk.Application.Interfaces
{
    public interface IExperimentRepository
    {
        Task<List<string>> GetAllExperimentsAsync();
    }
}
