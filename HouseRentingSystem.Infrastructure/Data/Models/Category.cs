using HouseRentingSystem.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Infrastructure.Data.Models
{
    [Comment("House category")]
    public class Category
    {

        [Key]
        [Comment("Category identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Category name")]
        [MaxLength(DataConstants.NameMaxLength)]
        public string Name { get; set; }

        public IEnumerable<House> Houses { get; set; } = new List<House>();
    }
}
