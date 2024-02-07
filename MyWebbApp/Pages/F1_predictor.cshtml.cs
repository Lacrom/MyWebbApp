using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;

namespace MyWebbApp.Pages

{
    public class F1PredictorModel : PageModel
    {
        private readonly IHubContext<ChartHub> _hubContext;

        public F1PredictorModel(IHubContext<ChartHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task OnGet()
        {
            await _hubContext.Clients.All.SendAsync("ReceiveChartData", "Nowe dane");
        }
    }
}