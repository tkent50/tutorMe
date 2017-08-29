using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
	public class HelloWorldController : Controller
	{
		// 
		// GET: /HelloWorld/

		/*public string Index()
		{
			return "This is my default action...";
		}*/

		public IActionResult Index()
		{
			return View();
		}

		// GET: /HelloWorld/Welcome/ 
		// Requires using System.Text.Encodings.Web;
		public string Welcome(string name, int numTimes = 1)
		{
			return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
		}

		// GET: /HelloWorld/NoView
		public string NoView()
		{
			return "This page has no view file.";
		}

        // GET: /HelloWorld/coker
        public IActionResult Coker() {
            return View();
        }
	}
}