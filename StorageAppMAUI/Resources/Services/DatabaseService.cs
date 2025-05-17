using SQLite;
using StorageAppMAUI.Models;

namespace StorageAppMAUI.Services;

public class DatabaseService
{
    private readonly SQLiteAsyncConnection _database;

    public DatabaseService(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<ObjectItem>().Wait();
    }

    public Task<List<ObjectItem>> GetObjectsAsync()
    {
        return _database.Table<ObjectItem>().ToListAsync();
    }

    public Task<int> SaveObjectAsync(ObjectItem item)
    {
        return _database.InsertAsync(item);
    }
}
