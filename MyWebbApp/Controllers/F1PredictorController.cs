using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyWebbApp
{
public class F1PredictorController : Controller
    {
        // POST: HomeController/HandleRadioButton
        [HttpPost]
        public IActionResult HandleRadioButton(string typeModel)
        {
            return View();
        }
    }
}