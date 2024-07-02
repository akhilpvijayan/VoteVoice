using Microsoft.EntityFrameworkCore;
using PollService.Models;
using System.ComponentModel.DataAnnotations;

namespace PollService.Business.Services.Dto
{
    [Keyless]
    public class PollDetailsDto : BaseEntity
    {
        public long PollId { get; set; }
        public long UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] profileImage { get; set; }

        public List<PollOptions> PollOptions { get; set; }
    }
}
