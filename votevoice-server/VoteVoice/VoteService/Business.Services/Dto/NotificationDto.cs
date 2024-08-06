using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VoteService.Business.Services.Dto
{
    public class NotificationDto
    {
        public long TargetUserId { get; set; }

        public long? UserId { get; set; }

        public long? PollId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? profileImage { get; set; }

        public long NotificationTypeId { get; set; }
    }
}
