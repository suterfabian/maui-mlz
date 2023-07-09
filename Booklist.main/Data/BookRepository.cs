using SQLite;
using Booklist.main.Models;

namespace Booklist.main.Data
{
    public class BookRepository
    {
        // private IDatabase database;
        private SQLiteAsyncConnection connection;
        public string StatusMessage { get; set; }

        public BookRepository(IDatabase database)
        {
            this.connection = database.GetConnection();
        }

        private async Task Init()
        {
            if (this.connection == null) return;

            await this.connection.CreateTableAsync<Book>();
            // this.connection = new SQLiteAsyncConnection(this.dbPath);
        }

        public async Task SaveBook(Book book)
        {
            int result = 0;
            try
            {
                await Init();

                if (book == null)
                    throw new Exception("Valid name required");

                if(book.Id == 0) result = await this.connection.InsertAsync(book);
                else result = await this.connection.UpdateAsync(book);

                StatusMessage = string.Format("Das Buch \"{0}\" wurde gespeichert.", book.Title);
            }
            catch (Exception exeption)
            {
                StatusMessage = string.Format("Fehler! Das Buch \"{0}\" konnte nicht gespeichert werden.", book.Title);
            }
        }

        public async Task<List<Book>> GetAllBooks()
        {
            try
            {
                await Init();
                return await this.connection.Table<Book>().ToListAsync();
            }
            catch (Exception exeption)
            {
                // TODO: Log Exeption5

                StatusMessage = string.Format("Fehler! Die Bücher können nicht abgefragt werden. {0}");
            }

            return new List<Book>();
        }

        /*
        public async Task<List<Book>> SaveBook(Book book)
        {
            try
            {
                await Init();
                return await this.connection.Table<Book>().ToListAsync();
            }
            catch (Exception exeption)
            {
                // TODO: Log Exeption

                StatusMessage = string.Format("Fehler! Die Bücher können nicht abgefragt werden. {0}");
            }

            return new List<Book>();
        }

        public async Task<List<Book>> DeleteBook()
        {
            try
            {
                await Init();
                return await this.connection.Table<Book>().ToListAsync();
            }
            catch (Exception exeption)
            {
                // TODO: Log Exeption

                StatusMessage = string.Format("Fehler! Die Bücher können nicht abgefragt werden. {0}");
            }

            return new List<Book>();
        }
        */
    }
}