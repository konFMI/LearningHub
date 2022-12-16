using System.ComponentModel.DataAnotations;
using static ShareHub.Data.DataConstants.Book;

namespace ShareHub.Data.Entities
{
    // TODO: Need to refactor fields.
    public class Book
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(LocationMinLength)]
        [MaxLength(LocationMaxLength)]
        public string Location { get; set; }

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl {get; set; }

        [Required]
        [MinLength(PricePerMonthMinValue)]
        [MaxLength(PricePerMonthMaxValue)]
        public decimal PricePerMonth { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        public int AgentId { get; set; }

        public Agent Agent { get; set; }

        public string RenterId { get; set; }
    }
}