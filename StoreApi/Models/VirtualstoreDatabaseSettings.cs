namespace StoreApi.Models
{
    public class VirtualstoreDatabaseSettings : IDatabaseSettings
    {
        public string StoreCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDatabaseSettings
    {
        string StoreCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}