using Microsoft.AspNetCore.SignalR;

namespace MyWebbApp.Hubs;

public class ChartHub : Hub
{
    public const string Url = "/chart";
}
