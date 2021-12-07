using Mongodexample.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Mongodexample.Services;

public class FoodService
{
    private readonly IMongoCollection<Food> _foodCollection;

    public FoodService(
        IOptions<FoodStoreDatabaseSettings> foodStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            foodStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            foodStoreDatabaseSettings.Value.DatabaseName);

        _foodCollection = mongoDatabase.GetCollection<Food>(
            foodStoreDatabaseSettings.Value.FoodCollectionName);
    }

    public async Task<List<Food>> GetAsync() =>
        await _foodCollection.Find(_ => true).ToListAsync();

    public async Task<Food?> GetAsync(string id) =>
        await _foodCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Food newFood) =>
        await _foodCollection.InsertOneAsync(newFood);

    public async Task UpdateAsync(string id, Food updatedFood) =>
        await _foodCollection.ReplaceOneAsync(x => x.Id == id, updatedFood);

    public async Task RemoveAsync(string id) =>
        await _foodCollection.DeleteOneAsync(x => x.Id == id);
}