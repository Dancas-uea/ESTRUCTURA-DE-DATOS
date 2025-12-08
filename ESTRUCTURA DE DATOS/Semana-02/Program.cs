using System;

namespace FigurasGeometricas
    {
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CALCULADORA DE FIGURAS GEOMÉTRICAS ===\n");
            
            bool continuar = true;
            
            while (continuar)
            {
                MostrarMenu();
                string opcion = Console.ReadLine();
                
                switch (opcion)
                {
                    case "1":
                        CalcularCirculo();
                        break;
                    case "2":
                        CalcularRectangulo();
                        break;
                    case "3":
                        continuar = false;
                        Console.WriteLine("¡Gracias por usar la calculadora!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.\n");
                        break;
                }
            }
        }
        
        // MostrarMenu muestra las opciones disponibles al usuario
        static void MostrarMenu()
        {
            Console.WriteLine("Seleccione una figura geométrica:");
            Console.WriteLine("1. Círculo");
            Console.WriteLine("2. Rectángulo");
            Console.WriteLine("3. Salir");
            Console.Write("Ingrese su opción (1-3): ");
        }
        
        // CalcularCirculo solicita el radio y calcula área y perímetro del círculo
        static void CalcularCirculo()
        {
            Console.WriteLine("\n--- CÁLCULO DE CÍRCULO ---");
            
            try
            {
                // Solicitar al usuario que ingrese el radio
                Console.Write("Ingrese el radio del círculo: ");
                double radio = Convert.ToDouble(Console.ReadLine());
                
                // Crear objeto círculo con el radio ingresado
                Circulo miCirculo = new Circulo(radio);
                
                // Mostrar resultados
                Console.WriteLine("\nRESULTADOS:");
                Console.WriteLine($"Radio: {miCirculo.Radio:F2}");
                Console.WriteLine($"Área: {miCirculo.CalcularArea():F2}");
                Console.WriteLine($"Perímetro: {miCirculo.CalcularPerimetro():F2}\n");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Debe ingresar un número válido.\n");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}\n");
            }
        }
        
        // CalcularRectangulo solicita base y altura y calcula área y perímetro del rectángulo
        static void CalcularRectangulo()
        {
            Console.WriteLine("\n--- CÁLCULO DE RECTÁNGULO ---");
            
            try
            {
                // Solicitar al usuario que ingrese la base
                Console.Write("Ingrese la base del rectángulo: ");
                double baseRect = Convert.ToDouble(Console.ReadLine());
                
                // Solicitar al usuario que ingrese la altura
                Console.Write("Ingrese la altura del rectángulo: ");
                double altura = Convert.ToDouble(Console.ReadLine());
                
                // Crear objeto rectángulo con los datos ingresados
                Rectangulo miRectangulo = new Rectangulo(baseRect, altura);
                
                // Mostrar resultados
                Console.WriteLine("\nRESULTADOS:");
                Console.WriteLine($"Base: {miRectangulo.Base:F2}");
                Console.WriteLine($"Altura: {miRectangulo.Altura:F2}");
                Console.WriteLine($"Área: {miRectangulo.CalcularArea():F2}");
                Console.WriteLine($"Perímetro: {miRectangulo.CalcularPerimetro():F2}\n");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Debe ingresar números válidos.\n");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}\n");
            }
        }
    }

    // Clase Circulo que representa una figura geométrica circular
    // Encapsula el radio como dato primitivo y proporciona métodos para cálculos
    class Circulo
    {
        // Radio del círculo - dato encapsulado con propiedad para control de acceso
        private double radio;
        
        // Propiedad pública para acceder y modificar el radio con validación
        public double Radio
        {
            get { return radio; }
            set 
            { 
                // Validar que el radio no sea negativo
                if (value >= 0)
                    radio = value;
                else
                    throw new ArgumentException("El radio no puede ser negativo");
            }
        }
        
        // Constructor que inicializa el círculo con un radio específico
        public Circulo(double radio)
        {
            Radio = radio; // Utiliza la propiedad para incluir validación
        }
        
        // CalcularArea devuelve el área del círculo usando la fórmula π * r²
        public double CalcularArea()
        {
            return Math.PI * Radio * Radio;
        }
        
        // CalcularPerimetro devuelve la circunferencia del círculo usando la fórmula 2 * π * r
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * Radio;
        }
    }

    // Clase Rectangulo que representa una figura geométrica rectangular
    // Encapsula base y altura como datos primitivos y proporciona métodos para cálculos
    class Rectangulo
    {
        // Base del rectángulo - dato encapsulado
        private double baseRect;
        
        // Altura del rectángulo - dato encapsulado
        private double altura;
        
        // Propiedad para acceder y modificar la base con validación
        public double Base
        {
            get { return baseRect; }
            set 
            { 
                if (value >= 0)
                    baseRect = value;
                else
                    throw new ArgumentException("La base no puede ser negativa");
            }
        }
        
        // Propiedad para acceder y modificar la altura con validación
        public double Altura
        {
            get { return altura; }
            set 
            { 
                if (value >= 0)
                    altura = value;
                else
                    throw new ArgumentException("La altura no puede ser negativa");
            }
        }
        
        // Constructor que inicializa el rectángulo con base y altura específicas
        public Rectangulo(double baseRect, double altura)
        {
            Base = baseRect;    // Utiliza la propiedad para incluir validación
            Altura = altura;    // Utiliza la propiedad para incluir validación
        }
        
        // CalcularArea devuelve el área del rectángulo usando la fórmula base * altura
        public double CalcularArea()
        {
            return Base * Altura;
        }
        
        // CalcularPerimetro devuelve el perímetro del rectángulo usando la fórmula 2*(base + altura)
        public double CalcularPerimetro()
        {
            return 2 * (Base + Altura);
        }
    }
}