using Microsoft.AspNetCore.Mvc;
using MovieSearchWebApp.Data;
using MovieSearchWebApp.Models;
using System.Diagnostics;

namespace MovieSearchWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        //public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> SearchMovieClass(SearchMovie searchMovie)
        {
            try
            {
                var client = new HttpClient();

                
                client.BaseAddress = new Uri("http://www.omdbapi.com/");

                MovieSearchResponse? movieInfo = await client
                    .GetFromJsonAsync<MovieSearchResponse>($"?t={searchMovie.Title}&apikey=7c8092b9");

                
               
               // var movieInfo = _db.movies.Where(x => x.Title == searchMovie.Title).FirstOrDefault();
                return View("DisplayMovieInfo", movieInfo);
            }
            catch (Exception)
            {

                return View();
            }

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