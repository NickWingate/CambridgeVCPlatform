using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Address
{
    public class AddressUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string LineOne { get; set; }

        public string? LineTwo { get; set; }

        [Required]
        public string Town { get; set; }

        [Required]
        public string County { get; set; }

        [Required]
        public string PostCode { get; set; }
    }
}
