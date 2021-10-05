using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class BasicController : ControllerBase
    {
        private static string path = Environment.CurrentDirectory;
        private static char separator = Path.DirectorySeparatorChar;
        private static string dataPath = $"{path}{separator}Data{separator}numeros.txt";

        [HttpGet("Suma")]
        public IActionResult suma(int numero1, int numero2)
        {
            return Ok(numero1 + numero2);
        }

        [HttpGet("TraductorDeNumeros")]
        public IActionResult traductor(int numero)
        {
            IEnumerable<String> numeros = System.IO.File.ReadLines($"{path}{separator}Data{separator}numeros.txt");
            string traduccion = String.Empty;
            foreach (var cadena in numeros)
            {
                traduccion = nombre(cadena, numero);
                if (traduccion != string.Empty)
                {
                    break;
                }
            }
            return Ok(traduccion);
        }

        [HttpGet("TablaDeMultiplicar")]
        public IActionResult tabla(int numero)
        {
            int[] tabla = new int[14];
            for(int i=1;i<=13;i++)
            {
               tabla[i] = numero*i; 
               Console.WriteLine(tabla[i]);
            }
            return Ok(tabla);
        }

        private string nombre(string cadena, int numero)
        {
            int count = 0;
            string traduccion = string.Empty;
            string[] separacion = cadena.Split(':');
            foreach (var item in separacion)
            {
                if (item == numero.ToString())
                {
                    count = 2;
                }
                else if (count == 2)
                {
                    count = 1;
                    traduccion = item;
                    return traduccion;
                }
            }
            return traduccion;
        }
    }
}
