using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.SessionTimings
{
    public class SessionTimingUpdateDto
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }
    }
}
