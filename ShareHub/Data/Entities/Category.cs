using System.ComponentModel.DataAnotations;
using static ShareHub.Data.DataConstants.Category;

namespace ShareHub.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public IEnumarable<Book> Books { get; init; } = new List<Book>();
    }
}