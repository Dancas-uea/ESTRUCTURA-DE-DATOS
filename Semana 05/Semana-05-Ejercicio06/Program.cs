using System;
using System.Collections.Generic;


/// Ejercicio 6: Asignaturas y Notas
/// Desarrollar un programa en C# que permita gestionar las asignaturas de un estudiante.
/// El programa debe permitir ingresar el nombre de la asignatura y la nota obtenida.
/// Luego, debe mostrar un listado de las asignaturas que el estudiante debe repetir (nota menor a 6).
/// Utilizar clases y listas para organizar la información.

class Asignatura
{
    public string Nombre { get; set; }
    public double Nota { get; set; }
    public bool Aprobada => Nota >= 6.0;

    public Asignatura(string nombre, double nota)
    {
        Nombre = nombre;
        Nota = nota;
    }
}

class GestorAsignaturas
{
    private List<Asignatura> asignaturas;

    public GestorAsignaturas()
    {
        asignaturas = new List<Asignatura>();
    }

    public void AgregarAsignatura(string nombre, double nota)
    {
        asignaturas.Add(new Asignatura(nombre, nota));
    }

    public List<Asignatura> ObtenerAsignaturasARepetir()
    {
        List<Asignatura> repetir = new List<Asignatura>();
        
        foreach (var asignatura in asignaturas)
        {
            if (!asignatura.Aprobada)
            {
                repetir.Add(asignatura);
            }
        }
        
        return repetir;
    }
}

class Program
{
    static void Main()
    {
        GestorAsignaturas gestor = new GestorAsignaturas();
        string[] nombresAsignaturas = { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
        
        Console.WriteLine("=== SISTEMA DE EVALUACIÓN DE ASIGNATURAS ===");
        
        foreach (var asignatura in nombresAsignaturas)
        {
            Console.Write($"Ingrese la nota para {asignatura}: ");
            double nota = Convert.ToDouble(Console.ReadLine());
            gestor.AgregarAsignatura(asignatura, nota);
        }
        
        var asignaturasARepetir = gestor.ObtenerAsignaturasARepetir();
        
        Console.WriteLine("\n=== ASIGNATURAS A REPETIR ===");
        if (asignaturasARepetir.Count == 0)
        {
            Console.WriteLine("¡Felicidades! Has aprobado todas las asignaturas.");
        }
        else
        {
            foreach (var asignatura in asignaturasARepetir)
            {
                Console.WriteLine($"{asignatura.Nombre}: {asignatura.Nota}");
            }
        }
    }
}