using System;
using System.Collections.Generic;
using System.Text;

class Traductor
{
    static void Main(string[] args)
    {
        // Diccionario inicial con palabras en inglés y sus traducciones al español
        Dictionary<string, string> diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {"time", "tiempo"},
            {"person", "persona"},
            {"year", "año"},
            {"way", "camino"},
            {"day", "día"},
            {"thing", "cosa"},
            {"man", "hombre"},
            {"world", "mundo"},
            {"life", "vida"},
            {"hand", "mano"},
            {"part", "parte"},
            {"child", "niño/a"},
            {"eye", "ojo"},
            {"woman", "mujer"},
            {"place", "lugar"},
            {"work", "trabajo"},
            {"week", "semana"},
            {"case", "caso"},
            {"point", "punto"},
            {"government", "gobierno"},
            {"company", "empresa"}
        };

        while (true)
        {
            MostrarMenu();
            string seleccion = Console.ReadLine();

            switch (seleccion)
            {
                case "1":
                    TraducirFrase(diccionario);
                    break;

                case "2":
                    AgregarPalabra(diccionario);
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    EsperarEntrada();
                    break;
            }
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("================================================");
        Console.WriteLine("********** TRADUCTOR INGLÉS - ESPAÑOL **********");
        Console.WriteLine("================================================");
        Console.WriteLine("1. Traducir una frase");
        Console.WriteLine("2. Agregar palabras al diccionario");
        Console.WriteLine("0. Salir");
        Console.Write("Seleccione una opción: ");
    }

    static void TraducirFrase(Dictionary<string, string> diccionario)
    {
        Console.Write("Ingrese la frase a traducir: ");
        string entrada = Console.ReadLine();
        StringBuilder resultado = new StringBuilder();
        string[] palabras = entrada.Split(' ');

        foreach (string palabra in palabras)
        {
            string palabraLimpia = palabra.ToLower().Trim(new char[] { '.', ',', '!', '?' });
            if (diccionario.TryGetValue(palabraLimpia, out string traduccion))
            {
                resultado.Append(traduccion + " ");
            }
            else
            {
                // Verificar si la palabra está en español y traducir al inglés
                string traduccionIngles = ObtenerTraduccionIngles(palabraLimpia, diccionario);
                if (!string.IsNullOrEmpty(traduccionIngles))
                {
                    resultado.Append(traduccionIngles + " ");
                }
                else
                {
                    resultado.Append(palabra + " "); // Si no se encuentra, se deja la palabra original
                }
            }
        }

        Console.WriteLine("Frase traducida: " + resultado.ToString().Trim());
        EsperarEntrada();
    }

    static string ObtenerTraduccionIngles(string palabra, Dictionary<string, string> diccionario)
    {
        foreach (var par in diccionario)
        {
            if (par.Value.Equals(palabra, StringComparison.OrdinalIgnoreCase))
            {
                return par.Key; // Retorna la clave (palabra en inglés)
            }
        }
        return null; // No se encontró traducción
    }

    static void AgregarPalabra(Dictionary<string, string> diccionario)
    {
        Console.Write("Ingrese la palabra en inglés: ");
        string palabraIngles = Console.ReadLine().ToLower();
        Console.Write("Ingrese la traducción en español: ");
        string palabraEspanol = Console.ReadLine().ToLower();

        if (!diccionario.ContainsKey(palabraIngles))
        {
            diccionario.Add(palabraIngles, palabraEspanol);
            Console.WriteLine("Palabra añadida correctamente al diccionario.");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
        EsperarEntrada();
    }

    static void EsperarEntrada()
    {
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}
