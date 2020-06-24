namespace MongoPOC.Models
{
    public class AnimestoreDatabaseSettings : IAnimestoreDatabaseSettings
    {
        public string AnimesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IAnimestoreDatabaseSettings
    {
        string AnimesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
