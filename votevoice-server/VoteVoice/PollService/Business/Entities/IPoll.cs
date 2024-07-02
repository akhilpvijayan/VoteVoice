using System.ComponentModel.DataAnnotations;

namespace PollService.Business.Entities
{
    public interface IPoll
    {
        long PollId { get; set; }

        long UserId { get; set; }

        string Title { get; set; }

        string Description { get; set; }

        bool IsActive { get; set; }
    }
}
