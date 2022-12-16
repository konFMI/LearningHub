using System.ComponentModel.DataAnotations;
using static ShareHub.Data.DataConstants.Agent;

namespace ShareHub.Data.Entities
{
    public class Agent
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MinLength(PhoneNumberMinLength)]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        [Required]
        public string UserId { get; set; }

        public IdentityUser User { get; set; }
    }
}