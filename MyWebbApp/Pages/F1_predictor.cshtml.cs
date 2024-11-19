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
        public List<RaceData> QualiDataList { get; set; } = new List<RaceData>();

        [BindProperty]
        public int SelectedRaceNumber { get; set; }
        [BindProperty]
        public int SelectedSeasonNumber { get; set; }
        [BindProperty]
        public bool IsLoadedData { get; set; }
        [BindProperty]
        public bool IsChecked { get; set; }
        [BindProperty]
        public string QualiDataListJson { get; set; } = string.Empty; // Initialize to an empty string

        public Dictionary<int, string> DriverNames { get; set; } = new Dictionary<int, string>
        {
            { 1, "L.Hamilton" },
            { 4, "F.Alonso" },
            { 858, "L.Sargeant" },
            { 857, "O.Piastri" },
            { 856, "N.De Vries" },
            { 855, "G.Zhou" },
            { 852, "Y.Tsunoda" },
            { 830, "M.Verstappen" },
            { 815, "S.Perez" },
            { 844, "C.Leclerc" },
            { 832, "C.Sainz" },
            { 840, "L.Stroll" },
            { 846, "L.Norris" },
            { 847, "G.Russell" },
            { 839, "E.Ocon" },
            { 842, "P.Gasly" },
            { 822, "V.Bottas" },
            { 807, "N.Hulkenberg" },
            { 825, "K.Magnussen" },
            { 848, "A.Albon" },
            { 817, "D.Ricciardo" },
            { 859, "L.Lawson" },
            { 860, "F.Colapinto" },
            { 861, "O.Bearman" }
        };

        public F1PredictorModel(F1PredictorController f1PredictorController)
        {
            _f1PredictorController = f1PredictorController;
        }

        public async Task<IActionResult> OnPostGetRaceDataAsync()
        {
            QualiDataList = new List<RaceData>();

            if (TempData["QualiDataList"] is string qualiDataFromTempData)
            {
                var tempDataList = JsonConvert.DeserializeObject<List<RaceData>>(qualiDataFromTempData);
                if (tempDataList != null)
                {
                    QualiDataList.AddRange(tempDataList);
                }
            }

            List<RaceData> updatedQualiData = new();
            if (!string.IsNullOrEmpty(QualiDataListJson))
            {
                updatedQualiData = JsonConvert.DeserializeObject<List<RaceData>>(QualiDataListJson) ?? new List<RaceData>();
            }

            var updatedQualiDict = updatedQualiData.ToDictionary(r => r.driver , r => r.position_quali);
            foreach (var raceData in QualiDataList)
            {
                if (updatedQualiDict.TryGetValue(raceData.driver, out int updatedPosition))
                {
                    raceData.position_quali = updatedPosition; 
                }

                if (DriverNames.TryGetValue(raceData.Id, out string driverName))
                {
                    raceData.driver = driverName;
                }
                else
                {
                    raceData.driver = "Unknown Driver"; 
                }
            }

            RaceDataList = await _f1PredictorController.GetRaceData(
                SelectedRaceNumber,
                SelectedSeasonNumber,
                IsChecked,
                QualiDataList
            );

            return Page();
        }



        public async Task<IActionResult> OnPostGetQualificationFormAsync()
        {
            // Handle the logic for getting qualification
            
            QualiDataList = await _f1PredictorController.GetDriversDataForm(SelectedRaceNumber, SelectedSeasonNumber);
            TempData["QualiDataList"] = JsonConvert.SerializeObject(QualiDataList);
            
            IsLoadedData = true;
            return Page();
        }

    }
}