namespace UserService.Business.Entities
{
    public interface IStates
    {
        long StateId { get; set; }
        string StateName { get; set; }
    }
}
