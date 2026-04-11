namespace Portal.Blazor.Services;

public enum ToastLevel
{
    Info,
    Success,
    Warning,
    Error
}

public class ToastService
{
    private INotificationService? _notificationService;

    public static Dictionary<ToastLevel, string> Icons { get; } = new();

    public void Initialize(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public async void ShowToast(string message, ToastLevel level, string? title = null)
    {
        if (_notificationService == null)
        {
            Console.WriteLine($"[{level}] {title}: {message}");
            return;
        }

        var notificationType = level switch
        {
            ToastLevel.Success => NotificationType.Success,
            ToastLevel.Warning => NotificationType.Warning,
            ToastLevel.Error => NotificationType.Error,
            _ => NotificationType.Info
        };
        //await _notificationService.Info(title ?? "Notification", message, notificationType);

        await _notificationService.Info(title ?? "Notification", message);
    }
}

