using SQLite;

// [assembly: Dependency(typeof(Database))]
namespace Booklist.main.Data
{
    public interface IDatabase
    {
        SQLiteAsyncConnection GetConnection();
    }
}