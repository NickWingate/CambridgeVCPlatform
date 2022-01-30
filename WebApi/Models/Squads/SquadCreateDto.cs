using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Squads
{
    public class SquadCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
