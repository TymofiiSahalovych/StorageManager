using SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using StorageAppMAUI.Models;

namespace StorageAppMAUI.Services;
public class DatabaseService
{
    private SQLiteAsyncConnection _database;

    public DatabaseService()
    {
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "object.db3");
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<StoredObject>().Wait();
    }

    public Task<List<StoredObject>> GetObjectAsync()
    {
        return _database.Table<StoredObject>().ToListAsync();
    }

    public Task<StoredObject> GetObjectAsync(int id)
    {
        return _database.Table<StoredObject>().Where(p => p.Id == id).FirstOrDefaultAsync();
    }

    public Task<int> SaveObjectAsync(StoredObject storedObject)
    {
        if (storedObject.Id != 0)
            return _database.UpdateAsync(storedObject);
        else
            return _database.InsertAsync(storedObject);
    }

    public Task<int> DeleteObjectAsync(StoredObject person)
    {
        return _database.DeleteAsync(person);
    }
}
