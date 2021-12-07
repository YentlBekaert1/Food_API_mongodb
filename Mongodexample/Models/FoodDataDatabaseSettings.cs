
    namespace Mongodexample.Models;

    public class FoodStoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string FoodCollectionName { get; set; } = null!;
    }

