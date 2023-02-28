using System.ComponentModel.DataAnnotations;

namespace CloudCustomer.API.Models
{
    public class Address
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
    }
}
