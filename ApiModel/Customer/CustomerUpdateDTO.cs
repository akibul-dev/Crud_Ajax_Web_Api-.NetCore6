namespace SampleCommerce.API.ApiModel.Customer
{
    public class CustomerUpdateDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public string Phone { get; set; }

        public string? Address { get; set; }
    }
}
