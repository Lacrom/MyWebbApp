using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;


namespace MyWebbApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class F1PredictorController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public F1PredictorController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpPost("GetRaceData")]
    public async Task<List<RaceData>> GetRaceData(int raceNumber, int seasonNumber)
    {
        var requestPayload = new { race_number = raceNumber, season_number = seasonNumber };
        var jsonContent = new StringContent(JsonSerializer.Serialize(requestPayload), Encoding.UTF8, "application/json");

        // Send POST request to the Flask API
        var response = await _httpClient.PostAsync("http://127.0.0.1:5000/predictF1results", jsonContent);
        response.EnsureSuccessStatusCode();

        // Deserialize the response to a list of RaceData
        var responseData = await response.Content.ReadAsStringAsync();
        var raceData = JsonSerializer.Deserialize<List<RaceData>>(responseData);
        return raceData ?? new List<RaceData>();

        ///HttpContext.Session.SetString("RaceData", JsonSerializer.Serialize(raceData));
        // RedirectToAction("ShowRaceData");

    }

    /*[HttpGet("ShowRaceData")]
    public IActionResult ShowRaceData()
    {
        // read session data
        var raceDataJson = HttpContext.Session.GetString("RaceData");
        if (string.IsNullOrEmpty(raceDataJson))
        {
            
            return RedirectToAction("GetRaceData"); 
        }

        // Deserializacja danych do modelu List<RaceData>
        var raceData = JsonSerializer.Deserialize<List<RaceData>>(raceDataJson);

        // Przekazanie danych do widoku
        return View(raceData);
    }*/

}

public class RaceData
{
    public int Id { get; set; }
    public int IdCon { get; set; }
    public string? Idcircuit { get; set; }
    public string? driver { get; set; }
    public int is_home_race_constr { get; set; }
    public int is_home_race_driv { get; set; }
    public int position_constructors { get; set; }
    public int position_drivers { get; set; }
    public int position_quali { get; set; }
    public int pred_pos_rf { get; set; }
    public int pred_pos_svc { get; set; }
    public string? team { get; set; }
}