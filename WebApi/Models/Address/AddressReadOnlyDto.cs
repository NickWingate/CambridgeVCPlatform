namespace WebApi.Models.Address
{
    public class AddressReadOnlyDto
    {
        public int Id { get; set; }
        public string LineOne { get; set; }
        public string LineTwo { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
    }
}
