using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using System.Diagnostics;

namespace Portafolio.Controllers
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
            //ViewBag.Nombre = "Raúl Company 122";
            //ViewBag.Edad = "25";

            /*
            var persona = new Persona()
            {
                Nombre = "Raulin",
                Edad = 15
            };

            return View(persona);
            */
            var proyectos = ObtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndexViewModel() { Proyectos = proyectos };
            return View(modelo);
        }

        private List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>() { 
                new Proyecto
                    {
                        Titulo = "Amazon",
                        Descripcion = "E-Commerce realizado en ASP.NET Core",
                        Link = "https://amazon.es",
                        ImagenUrl = "/img/amazon.png"
                    },
            
                new Proyecto
                    {
                        Titulo = "New York Times",
                        Descripcion = "Pa´gina de noticias en React",
                        Link = "https://nytimes.com",
                        ImagenUrl = "/img/nyt.png"
                    },
                new Proyecto
                    {
                        Titulo = "Reddir",
                        Descripcion = "Red social para compartir en comunidades",
                        Link = "https://amazon.es",
                        ImagenUrl = "/img/reddit.png"
                    },
                new Proyecto
                    {
                        Titulo = "Steam",
                        Descripcion = "Tienda en línea para comprar videojuegos",
                        Link = "https://store.steampowered.es",
                        ImagenUrl = "/img/steam.png"
                    },

            };

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