using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using MyWebbApp.Controllers;

namespace MyWebbApp.Pages
{
    public class F1PredictorModel : PageModel
    {
        private readonly F1PredictorController _f1PredictorController;

        public List<RaceData> RaceDataList { get; set; } = new List<RaceData>();

        [BindProperty]
        public int SelectedRaceNumber { get; set; }

        public F1PredictorModel(F1PredictorController f1PredictorController)
        {
            _f1PredictorController = f1PredictorController;
        }

        //public async Task OnGetAsync()
        //{
            // Default load data for race 1, or show an empty list
        //}

        public async Task<IActionResult> OnPostAsync()
        {
            // Fetch data for the selected race number
            RaceDataList = await _f1PredictorController.GetRaceData(SelectedRaceNumber);
            return Page();
        }

        
    }
}