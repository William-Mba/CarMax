namespace CarMax.Application.Interfaces.appSettings
{
    public interface ICosmosDbSettings
    {
        string ConnectionString { get; }
        string DatabaseName { get; }
        string CarContainerName { get; }
        string CarContainerPartitionKeyPath { get; }
    }
}
