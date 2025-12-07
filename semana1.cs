using System;

namespace FigurasGeometricas
{
    // Clase para representar un Círculo
    public class Circulo
    {
        // Radio es un atributo privado de tipo double que almacena el radio del círculo
        // Se encapsula para proteger la integridad de los datos
        private double radio;

        // Constructor de la clase Circulo que recibe el radio como parámetro
        // Se valida que el radio sea mayor que cero
        public Circulo(double radio)
        {
            // Validación para asegurar que el radio sea un valor positivo
            if (radio <= 0)
            {
                throw new ArgumentException("El radio debe ser mayor que cero.");
            }
            this.radio = radio;
        }

        // Propiedad Radio que permite acceder y modificar el radio del círculo
        // Incluye validación para mantener la integridad de los datos
        public double Radio
        {
            get { return radio; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("El radio debe ser mayor que cero.");
                }
                radio = value;
            }
        }

        // CalcularArea es un método que devuelve un valor double
        // Se utiliza para calcular el área de un círculo utilizando la fórmula π * r²
        public double CalcularArea()
        {
            return Math.PI * radio * radio;
        }

        // CalcularPerimetro es un método que devuelve un valor double
        // Se utiliza para calcular el perímetro (circunferencia) de un círculo utilizando la fórmula 2 * π * r
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * radio;
        }

        // Método ToString sobrescrito para mostrar información del círculo
        public override string ToString()
        {
            return $"Círculo - Radio: {radio:F2}, Área: {CalcularArea():F2}, Perímetro: {CalcularPerimetro():F2}";
        }
    }

    // Clase para representar un Rectángulo
    public class Rectangulo
    {
        // Ancho y Alto son atributos privados de tipo double que almacenan las dimensiones del rectángulo
        // Se encapsulan para proteger la integridad de los datos
        private double ancho;
        private double alto;

        // Constructor de la clase Rectangulo que recibe ancho y alto como parámetros
        // Se valida que ambas dimensiones sean mayores que cero
        public Rectangulo(double ancho, double alto)
        {
            // Validación para asegurar que las dimensiones sean valores positivos
            if (ancho <= 0 || alto <= 0)
            {
                throw new ArgumentException("El ancho y alto deben ser mayores que cero.");
            }
            this.ancho = ancho;
            this.alto = alto;
        }

        // Propiedad Ancho que permite acceder y modificar el ancho del rectángulo
        // Incluye validación para mantener la integridad de los datos
        public double Ancho
        {
            get { return ancho; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("El ancho debe ser mayor que cero.");
                }
                ancho = value;
            }
        }

        // Propiedad Alto que permite acceder y modificar el alto del rectángulo
        // Incluye validación para mantener la integridad de los datos
        public double Alto
        {
            get { return alto; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("El alto debe ser mayor que cero.");
                }
                alto = value;
            }
        }

        // CalcularArea es un método que devuelve un valor double
        // Se utiliza para calcular el área de un rectángulo utilizando la fórmula ancho * alto
        public double CalcularArea()
        {
            return ancho * alto;
        }

        // CalcularPerimetro es un método que devuelve un valor double
        // Se utiliza para calcular el perímetro de un rectángulo utilizando la fórmula 2 * (ancho + alto)
        public double CalcularPerimetro()
        {
            return 2 * (ancho + alto);
        }

        // Método adicional para verificar si el rectángulo es un cuadrado
        // Devuelve true si el ancho es igual al alto
        public bool EsCuadrado()
        {
            return Math.Abs(ancho - alto) < 0.0001; // Comparación con tolerancia para valores double
        }

        // Método ToString sobrescrito para mostrar información del rectángulo
        public override string ToString()
        {
            string tipo = EsCuadrado() ? "Cuadrado" : "Rectángulo";
            return $"{tipo} - Ancho: {ancho:F2}, Alto: {alto:F2}, Área: {CalcularArea():F2}, Perímetro: {CalcularPerimetro():F2}";
        }
    }

    // Clase principal para probar las figuras geométricas
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== DEMOSTRACIÓN DE FIGURAS GEOMÉTRICAS ===\n");

            try
            {
                // Crear un círculo con radio 5
                Circulo miCirculo = new Circulo(5.0);
                Console.WriteLine(miCirculo.ToString());
                
                // Modificar el radio del círculo
                miCirculo.Radio = 7.5;
                Console.WriteLine($"Círculo modificado - Radio: {miCirculo.Radio:F2}");
                Console.WriteLine($"Área del círculo modificado: {miCirculo.CalcularArea():F2}");
                Console.WriteLine($"Perímetro del círculo modificado: {miCirculo.CalcularPerimetro():F2}\n");

                // Crear un rectángulo de 4x6
                Rectangulo miRectangulo = new Rectangulo(4.0, 6.0);
                Console.WriteLine(miRectangulo.ToString());
                
                // Crear un cuadrado (rectángulo con lados iguales)
                Rectangulo miCuadrado = new Rectangulo(5.0, 5.0);
                Console.WriteLine(miCuadrado.ToString());
                
                // Modificar las dimensiones del rectángulo
                miRectangulo.Ancho = 8.0;
                miRectangulo.Alto = 3.0;
                Console.WriteLine($"Rectángulo modificado - Ancho: {miRectangulo.Ancho:F2}, Alto: {miRectangulo.Alto:F2}");
                Console.WriteLine($"Área del rectángulo modificado: {miRectangulo.CalcularArea():F2}");
                Console.WriteLine($"Perímetro del rectángulo modificado: {miRectangulo.CalcularPerimetro():F2}");

                // Intentar crear una figura con dimensiones inválidas (esto lanzará una excepción)
                // Descomentar la siguiente línea para ver el manejo de errores:
                // Rectangulo rectanguloInvalido = new Rectangulo(-2, 5);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError inesperado: {ex.Message}");
            }

            Console.WriteLine("\n=== FIN DE LA DEMOSTRACIÓN ===");
            Console.ReadLine();
        }
    }
}