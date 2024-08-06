namespace NotificationService.Business.Entities
{
    public interface INotificationType
    { 
        long NotificationTypeId { get; set; }

        string NotificationTypeName { get; set; }

        string NotificationMessage { get; set; }
    }
}
