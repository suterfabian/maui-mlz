using SQLite;

namespace Booklist.main.Models
{
    [Table("Book")]
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } = 0;

        [MaxLength(255)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(255)]
        public string Subtitle { get; set; } = string.Empty;

        [MaxLength(255)]
        public string Author { get; set; } = string.Empty;

        [MaxLength(32)]
        public string ISBN { get; set; } = string.Empty;

        [MaxLength(255)]
        public string Publisher { get; set; } = string.Empty;

        [MaxLength(255)]
        public string Image { get; set; } = string.Empty;

        public int Rating { get; set; } = 0; // 1-6

        public DateTime? CreateDate { get; set; }

        public DateTime? ChangeDate { get; set; }
    }
}