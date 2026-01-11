using System;
using System.Collections.Generic;


/// Ejercicio 7: Abecedario y Posiciones
/// Desarrollar un programa en C# que genere una lista con las letras del abecedario (de la A a la Z).
/// Luego, debe eliminar de la lista las letras que se encuentran en posiciones múltiplos de 3 (3, 6, 9, etc.).
/// Finalmente, mostrar la lista resultante y la cantidad de letras que quedan.
/// 
/// 
class ProcesadorAbecedario
{
    private List<char> abecedario;

    public ProcesadorAbecedario()
    {
        abecedario = new List<char>();
        // Generar abecedario de la A a la Z
        for (char letra = 'A'; letra <= 'Z'; letra++)
        {
            abecedario.Add(letra);
        }
    }

    public List<char> EliminarMultiplosDeTres()
    {
        List<char> resultado = new List<char>();
        
        // Recordar que las listas empiezan en índice 0, pero el usuario piensa en posición 1
        for (int i = 0; i < abecedario.Count; i++)
        {
            // Si la posición (i+1) NO es múltiplo de 3, agregamos la letra
            if ((i + 1) % 3 != 0)
            {
                resultado.Add(abecedario[i]);
            }
        }
        
        return resultado;
    }

    public void MostrarAbecedarioOriginal()
    {
        Console.WriteLine("Abecedario original:");
        for (int i = 0; i < abecedario.Count; i++)
        {
            Console.WriteLine($"Posición {i + 1}: {abecedario[i]}");
        }
    }
}

class Program
{
    static void Main()
    {
        ProcesadorAbecedario procesador = new ProcesadorAbecedario();
        
        Console.WriteLine("=== PROCESAMIENTO DE ABECEDARIO ===");
        
        procesador.MostrarAbecedarioOriginal();
        
        var resultado = procesador.EliminarMultiplosDeTres();
        
        Console.WriteLine("\n=== ABECEDARIO RESULTANTE (sin posiciones múltiplos de 3) ===");
        Console.Write("Letras: ");
        foreach (char letra in resultado)
        {
            Console.Write(letra + " ");
        }
        
        Console.WriteLine($"\nTotal de letras: {resultado.Count}");
    }
}