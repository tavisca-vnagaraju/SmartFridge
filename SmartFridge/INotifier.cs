namespace SmartRefridgerator
{
    public interface INotifier
    {
        string Message { get; }
        string NotifyUser();
    }
}
