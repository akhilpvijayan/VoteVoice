using System.ComponentModel.DataAnnotations;
using UserService.Business.Entities;

namespace UserService.Models
{
    public class Countries : ICountries
    {
        [Key]
        public long CountryId { get; set; }

        public string CountryName { get; set; }
    }
}
