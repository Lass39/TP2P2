using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public class Movimento
        {
            public List<Voo> voo { get; set; }
        }

        public class Root
        {
            public Movimento movimento { get; set; }
        }

        public class Voo
        {
            public string codigo { get; set; }
            public string origem { get; set; }
            public string destino { get; set; }
            public string horario { get; set; }
            public string compania { get; set; }
            public string operando { get; set; }
            
        }
        public IActionResult Index()
        {

            string entrada;
            using (StreamReader lido = new StreamReader("G:\\IFSP\\TP02\\TP02.json"))
            {


                entrada = lido.ReadToEnd();
            }

            
            Root dyn = JsonConvert.DeserializeObject<Root>(entrada);

       

            ViewData.Add("result", dyn.movimento);

            return View(dyn);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}