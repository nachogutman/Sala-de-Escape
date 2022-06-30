using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;

namespace SalaDeEscape.Models
{
    public static class Escape
    {
        private static List<string> _incognitasSalas = new List<string>();
        private static int _estadoJuego = 0;
        private static int _erroresSala = 0;
        private static int _errores = 0;
        private static int _pistas = 0;
        private static string _nombre = "Ingrese su nombre en la seccion jugar";
        private static System.Timers.Timer aTimer;
        private static int segundos = 0;


        public static int Segundos{
            get{return segundos;}
        }

        public static int Pistas{
            get{return _pistas;}
            set{_pistas = value;}
        }
        public static string Nombre{
            get{return _nombre;}
            set{_nombre = value;}
        }
        public static List<string> IncognitasSalas{
            get{return _incognitasSalas;}
        }

        public static int EstadoJuego{
            get{return _estadoJuego;}
        }

        public static int Errores{
            get{return _errores;}
        }

        public static int ErroresSala{
            get{return _erroresSala;}
        }

        public static bool ResolverSala(int Sala, string Incognita){

            if(_incognitasSalas.Count == 0){
                _incognitasSalas.Add("moriste en madrid");
                _incognitasSalas.Add("Martinez Perez Casco");
                _incognitasSalas.Add("2018-11-24");
                _incognitasSalas.Add("912");
            }

            if(_incognitasSalas[Sala - 1] == Incognita){
                _estadoJuego = Sala + 1;
                _erroresSala = 0;
                return true;
            }else{
                _estadoJuego = Sala;
                _errores++;
                _erroresSala++;
                return false;
            }
        }

        public static void ReiniciarSala(){
            _estadoJuego = 1;
            _errores = 0;
            _erroresSala = 0;
            _pistas = 0;
            segundos = 0;   
        }

        public static void ComenzarTimer()
        {
            aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += Tick;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        public static void FinalizarTimer()
        {
            aTimer.Stop();
            aTimer.Dispose();
        }

        public static void Tick(Object source, ElapsedEventArgs e)
        {
            segundos++;
        }

        public static void sumarAlTimer(){
            segundos += 5*60;
        }

        public static void reinicioHard(){
            _estadoJuego = 0;
            _nombre = "Ingrese su nombre en la seccion jugar";
        }
    }
}
 