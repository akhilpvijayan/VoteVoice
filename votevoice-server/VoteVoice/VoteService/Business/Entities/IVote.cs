namespace VoteService.Business.Entities
{
    public interface IVote
    {
        long VoteId { get; set; }
        long PollOptionId { get; set; }
        long UserId { get; set; }
        long PollId { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
