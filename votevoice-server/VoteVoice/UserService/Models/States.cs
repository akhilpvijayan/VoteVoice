using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserService.Business.Entities;

namespace UserService.Models
{
    public class States : IStates
    {
        [Key]
        public long StateId { get; set; }

        public string StateName { get; set; }

        [ForeignKey("Country")]
        public long CountryId { get; set; }

        public Countries Country { get; set; }
    }
}
