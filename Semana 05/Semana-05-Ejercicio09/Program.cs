using System;
using System.Collections.Generic;

/// Ejercicio 9: Contador de Vocales
/// Desarrollar un programa en C# que permita contar la cantidad de vocales (a  ,e, i, o, u) 
/// en una palabra o frase ingresada por el usuario.
/// El programa debe mostrar el conteo de cada vocal por separado y el total de vocales encontradas.

class ContadorVocales
{
    private Dictionary<char, int> conteoVocales;

    public ContadorVocales()
    {
        conteoVocales = new Dictionary<char, int>
        {
            {'a', 0},
            {'e', 0},
            {'i', 0},
            {'o', 0},
            {'u', 0}
        };
    }

    public void ContarVocales(string palabra)
    {
        // Reiniciar conteo
        foreach (var vocal in conteoVocales.Keys)
        {
            conteoVocales[vocal] = 0;
        }

        string palabraMinuscula = palabra.ToLower();
        
        foreach (char letra in palabraMinuscula)
        {
            if (conteoVocales.ContainsKey(letra))
            {
                conteoVocales[letra]++;
            }
        }
    }

    public void MostrarResultados()
    {
        int totalVocales = 0;
        
        Console.WriteLine("\n=== CONTEO DE VOCALES ===");
        foreach (var vocal in conteoVocales)
        {
            Console.WriteLine($"Vocal '{vocal.Key}': {vocal.Value} veces");
            totalVocales += vocal.Value;
        }
        
        Console.WriteLine($"\nTotal de vocales: {totalVocales}");
    }

    public Dictionary<char, int> ObtenerConteo()
    {
        return new Dictionary<char, int>(conteoVocales);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== CONTADOR DE VOCALES ===");
        Console.Write("Ingrese una palabra o frase: ");
        string entrada = Console.ReadLine();
        
        ContadorVocales contador = new ContadorVocales();
        contador.ContarVocales(entrada);
        contador.MostrarResultados();
    }
}