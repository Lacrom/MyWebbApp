using Microsoft.AspNetCore.SignalR;



public class ChartHub : Hub
{
    public async Task SendChartData(string data)
    {
        await Clients.All.SendAsync("ReceiveChartData", data);
    }
}
