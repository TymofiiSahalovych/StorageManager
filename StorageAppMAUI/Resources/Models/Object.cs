using SQLite;

namespace StorageAppMAUI.Models;

public class Object
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Name { get; set; }
}
