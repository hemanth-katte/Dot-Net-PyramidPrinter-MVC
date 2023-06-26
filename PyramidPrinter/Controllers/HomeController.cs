using Microsoft.AspNetCore.Mvc;
using PyramidPrinter.Models;
using System.Diagnostics;
using System.Text;

namespace PyramidPrinter.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
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

		public IActionResult PyramidPage()
		{
			return View();
		}

		public IActionResult printP(int height)
		{
            int increment = 1;
            List<String> render = new List<String>();
            for (int i = 0; i < height; i++)
            {
                StringBuilder ret = new StringBuilder();
                for (int j = 0; j < height - i - 1; j++)
                {
                    ret.Append("&nbsp;");
                }
                for (int k = i + increment; k > 0; k--)
                {
                    ret.Append("*");
                }
                increment++;
                render.Add(ret.ToString());	
            }

			ViewBag.Pyramid = render;

			return View("PyramidPage");
        }
	}
}