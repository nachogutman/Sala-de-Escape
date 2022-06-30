using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalaDeEscape.Models;
using System.Timers;

namespace SalaDeEscape.Controllers
{

    public class EscapeController : Controller
    {
        Timer reloj;
        private readonly ILogger<EscapeController> _logger;

        public EscapeController(ILogger<EscapeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            Escape.ReiniciarSala();
            return View();
        }

        public IActionResult Comenzar(string nombre){
            ViewBag.EstadoJuego = Escape.EstadoJuego;
            Escape.ReiniciarSala();
            Escape.Nombre = nombre;
            Escape.ComenzarTimer();
            return View("Habitacion1");
        }

        [HttpPost]

        public IActionResult Habitacion(int sala, string clave, int pistas){
            if(Escape.Segundos >= 3600){
                return View("Perdiste");
            }
            Escape.Pistas += pistas;
            bool res = Escape.ResolverSala(sala, clave);
            ViewBag.EstadoJuego = Escape.EstadoJuego;
            if(res == true){
                if(sala == 4){
                    Escape.FinalizarTimer();
                    return View("Victoria");
                }else{
                    return View($"Habitacion{Escape.EstadoJuego}");
                }
            }
            else{
                return View($"Habitacion{sala}");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
