using SQLite;

namespace StorageAppMAUI.Models;

public class StoredObject
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Name { get; set; } = "Default name";
}
