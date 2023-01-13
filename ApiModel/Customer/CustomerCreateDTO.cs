using System.ComponentModel.DataAnnotations;

namespace SampleCommerce.API.ApiModel.Customer
{
    public class CustomerCreateDTO
    {
       
        public string Name { get; set; }
        public string Code { get; set; }

        public string Phone { get; set; }

        public string? Address { get; set; }
    }
}
