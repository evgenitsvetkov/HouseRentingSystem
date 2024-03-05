using HouseRentingSystem.Infrastructure.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseRentingSystem.Infrastructure.Data.Models
{
    [Comment("House agent")]
    public class Agent
    {
        [Key]
        [Comment("Agent identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.AgentPhoneNumberMaxLength)]
        [Comment("Agent's phone")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty; 

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        public List<House> Houses { get; set; } = new List<House>();
    }
}
