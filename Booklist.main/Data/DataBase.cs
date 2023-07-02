using SQLite;

namespace Booklist.main.Data
{
    public class Database : IDatabase
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, AppDatabase.DbName);
            return new SQLiteAsyncConnection(path);
        }
    }
}