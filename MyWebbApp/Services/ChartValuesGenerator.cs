using System.Globalization;
using System.Security.Cryptography;
using MyWebbApp.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace MyWebbApp.Services;

public class ChartValuesGenerator : BackgroundService
{
    private readonly IHubContext<ChartHub> _hub;
    private readonly Buffer<Point> _data;

    public ChartValuesGenerator(IHubContext<ChartHub> hub, Buffer<Point> data)
    {
        _hub = hub;
        _data = data;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _hub.Clients.All.SendAsync(
                "addChartData",
                _data.AddNewRandomPoint(), 
                cancellationToken: stoppingToken
            );

            await Task.Delay(TimeSpan.FromSeconds(2), stoppingToken);
        }
    }
}