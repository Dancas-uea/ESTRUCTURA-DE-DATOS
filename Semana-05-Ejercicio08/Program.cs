using System;

/// Ejercicio 8: Verificador de Palíndromos
/// Desarrollar un programa en C# que solicite al usuario ingresar una palabra o frase.
/// El programa debe verificar si la palabra o frase es un palíndromo (se lee igual de adelante hacia atrás y de atrás hacia adelante).
/// Ignorar espacios, mayúsculas y signos de puntuación al realizar la verificación.  

class PalindromoChecker
{
    public string Palabra { get; set; }

    public PalindromoChecker(string palabra)
    {
        Palabra = palabra.ToLower().Replace(" ", "").Replace(".", "").Replace(",", "");
    }

    public bool EsPalindromo()
    {
        if (string.IsNullOrEmpty(Palabra))
            return false;

        int inicio = 0;
        int fin = Palabra.Length - 1;

        while (inicio < fin)
        {
            if (Palabra[inicio] != Palabra[fin])
                return false;
            
            inicio++;
            fin--;
        }
        
        return true;
    }

    public bool EsPalindromoConReverse()
    {
        char[] caracteres = Palabra.ToCharArray();
        Array.Reverse(caracteres);
        string palabraInvertida = new string(caracteres);
        
        return Palabra.Equals(palabraInvertida);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== VERIFICADOR DE PALÍNDROMOS ===");
        Console.Write("Ingrese una palabra o frase: ");
        string entrada = Console.ReadLine();
        
        PalindromoChecker checker = new PalindromoChecker(entrada);
        
        Console.WriteLine($"\nAnálisis de: '{entrada}'");
        Console.WriteLine($"Texto procesado: '{checker.Palabra}'");
        
        bool esPalindromo = checker.EsPalindromo();
        
        if (esPalindromo)
        {
            Console.WriteLine("✅ ¡Es un palíndromo!");
        }
        else
        {
            Console.WriteLine("❌ No es un palíndromo");
        }
    }
}