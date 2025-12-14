// =============================================================================
// PROGRAMA: SISTEMA DE GESTIÓN DE ESTUDIANTES
// DESCRIPCIÓN: Programa que gestiona el registro de estudiantes con arrays
// AUTOR: [Nombre del Estudiante]
// FECHA: [Fecha de Desarrollo]
// =============================================================================

// Importación de espacios de nombres necesarios
using System;  // Espacio de nombres base de .NET

// Definición del espacio de nombres para organizar las clases
namespace GestionEstudiantes
{
    // =========================================================================
    // CLASE: Estudiante
    // DESCRIPCIÓN: Representa a un estudiante con sus datos personales
    // =========================================================================
    public class Estudiante
    {
        // =====================================================================
        // ATRIBUTOS O CAMPOS DE LA CLASE (variables de instancia)
        // =====================================================================
        
        // Atributo para almacenar el ID del estudiante
        private int id;
        
        // Atributo para almacenar los nombres del estudiante
        private string nombres;
        
        // Atributo para almacenar los apellidos del estudiante
        private string apellidos;
        
        // Atributo para almacenar la dirección del estudiante
        private string direccion;
        
        // ATRIBUTO ESPECIAL: Array para almacenar 3 números de teléfono
        // Un array es una colección de elementos del mismo tipo
        // Aquí definimos un array de strings con capacidad para 3 elementos
        private string[] telefonos;
        
        // =====================================================================
        // CONSTRUCTOR DE LA CLASE
        // DESCRIPCIÓN: Método especial que se ejecuta al crear un objeto
        //              Inicializa los atributos de la clase
        // =====================================================================
        public Estudiante(int id, string nombres, string apellidos, string direccion)
        {
            // La palabra clave 'this' se refiere al objeto actual
            // Asignamos los valores de los parámetros a los atributos
            this.id = id;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.direccion = direccion;
            
            // INICIALIZACIÓN DEL ARRAY
            // Creamos una nueva instancia del array con capacidad para 3 elementos
            // Esto reserva memoria para almacenar 3 números de teléfono
            this.telefonos = new string[3];
            
            // Nota: Los arrays en C# se indexan desde 0
            // Posiciones disponibles: telefonos[0], telefonos[1], telefonos[2]
        }
        
        // =====================================================================
        // MÉTODO: EstablecerTelefonos
        // DESCRIPCIÓN: Asigna valores a los tres números de teléfono del array
        // PARÁMETROS: Tres strings que representan los números de teléfono
        // =====================================================================
        public void EstablecerTelefonos(string telefono1, string telefono2, string telefono3)
        {
            // Asignamos cada teléfono a una posición específica del array
            // La posición 0 almacena el primer teléfono
            telefonos[0] = telefono1;
            
            // La posición 1 almacena el segundo teléfono
            telefonos[1] = telefono2;
            
            // La posición 2 almacena el tercer teléfono
            telefonos[2] = telefono3;
        }
        
        // =====================================================================
        // MÉTODO: MostrarInformacion
        // DESCRIPCIÓN: Muestra en consola todos los datos del estudiante
        //              Incluye el recorrido del array de teléfonos
        // =====================================================================
        public void MostrarInformacion()
        {
            // Imprime una línea decorativa
            Console.WriteLine("========================================");
            
            // Imprime el título de la sección
            Console.WriteLine("        INFORMACIÓN DEL ESTUDIANTE      ");
            
            // Imprime otra línea decorativa
            Console.WriteLine("========================================");
            
            // Muestra cada atributo del estudiante
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Nombres: {nombres}");
            Console.WriteLine($"Apellidos: {apellidos}");
            Console.WriteLine($"Dirección: {direccion}");
            
            // Salto de línea para mejor formato
            Console.WriteLine("\nTeléfonos registrados:");
            
            // =================================================================
            // BUCLE FOR PARA RECORRER EL ARRAY
            // DESCRIPCIÓN: Recorre todas las posiciones del array de teléfonos
            // =================================================================
            
            // telefonos.Length devuelve el tamaño del array (en este caso 3)
            // El bucle se ejecuta mientras i sea menor que el tamaño del array
            for (int i = 0; i < telefonos.Length; i++)
            {
                // Muestra cada teléfono con un número de secuencia (i+1)
                // i+1 se usa porque los usuarios suelen contar desde 1, no desde 0
                Console.WriteLine($"  Teléfono {i + 1}: {telefonos[i]}");
            }
            
            // Línea decorativa final
            Console.WriteLine("========================================\n");
        }
        
        // =====================================================================
        // MÉTODO: ObtenerTelefono
        // DESCRIPCIÓN: Obtiene un teléfono específico según su posición
        // PARÁMETROS: indice - posición del teléfono a obtener (0, 1 o 2)
        // RETORNO: El número de teléfono en esa posición
        // =====================================================================
        public string ObtenerTelefono(int indice)
        {
            // VALIDACIÓN DEL ÍNDICE
            // Verificamos que el índice esté dentro del rango válido
            // 0 es la primera posición, telefonos.Length-1 es la última
            if (indice >= 0 && indice < telefonos.Length)
            {
                // Si el índice es válido, retornamos el teléfono en esa posición
                return telefonos[indice];
            }
            else
            {
                // Si el índice no es válido, retornamos un mensaje de error
                // Esto evita que el programa falle con IndexOutOfRangeException
                return "Índice no válido";
            }
        }
        
        // =====================================================================
        // MÉTODOS ADICIONALES (Opcionales - para funcionalidad extra)
        // =====================================================================
        
        // Método para obtener el ID (getter)
        public int ObtenerId()
        {
            return id;
        }
        
        // Método para obtener los nombres completos
        public string ObtenerNombreCompleto()
        {
            return $"{nombres} {apellidos}";
        }
        
        // Método para modificar un teléfono específico
        public void ModificarTelefono(int indice, string nuevoTelefono)
        {
            if (indice >= 0 && indice < telefonos.Length)
            {
                telefonos[indice] = nuevoTelefono;
                Console.WriteLine($"Teléfono {indice + 1} actualizado correctamente.");
            }
            else
            {
                Console.WriteLine("Error: Índice de teléfono no válido.");
            }
        }
    }
    
    // =========================================================================
    // CLASE: Program (Clase principal)
    // DESCRIPCIÓN: Contiene el método Main, punto de entrada del programa
    // =========================================================================
    class Program
    {
        // =====================================================================
        // MÉTODO: Main
        // DESCRIPCIÓN: Punto de entrada principal del programa
        //              Se ejecuta cuando inicia la aplicación
        // =====================================================================
        static void Main(string[] args)
        {
            // Título del programa
            Console.WriteLine("SISTEMA DE GESTIÓN DE ESTUDIANTES");
            Console.WriteLine("==================================\n");
            
            // Bloque try-catch para manejar posibles errores
            try
            {
                // =============================================================
                // DEMOSTRACIÓN 1: Creación y uso del primer estudiante
                // =============================================================
                
                Console.WriteLine("=== REGISTRO DEL PRIMER ESTUDIANTE ===\n");
                
                // CREACIÓN DE UN OBJETO Estudiante
                // Usamos el constructor para crear una nueva instancia
                // 'estudiante1' es una variable que referencia al objeto creado
                Estudiante estudiante1 = new Estudiante(
                    id: 1001,  // Asignamos ID 1001
                    nombres: "Juan Carlos",  // Asignamos nombres
                    apellidos: "Pérez López",  // Asignamos apellidos
                    direccion: "Av. Principal 123, Quevedo"  // Asignamos dirección
                );
                
                // ESTABLECER LOS TELÉFONOS USANDO EL ARRAY
                // Llamamos al método que asigna valores al array de teléfonos
                estudiante1.EstablecerTelefonos(
                    telefono1: "0991234567",  // Va a la posición 0 del array
                    telefono2: "052345678",   // Va a la posición 1 del array
                    telefono3: "042987654"    // Va a la posición 2 del array
                );
                
                // MOSTRAR LA INFORMACIÓN COMPLETA
                // Llamamos al método que muestra todos los datos
                estudiante1.MostrarInformacion();
                
                // =============================================================
                // DEMOSTRACIÓN 2: Acceso individual a teléfonos
                // =============================================================
                
                Console.WriteLine("=== ACCESO A TELÉFONOS ESPECÍFICOS ===\n");
                
                // Accedemos a teléfonos individuales usando índices
                // Recordar: los arrays comienzan en el índice 0
                string primerTelefono = estudiante1.ObtenerTelefono(0);
                string segundoTelefono = estudiante1.ObtenerTelefono(1);
                
                Console.WriteLine($"Primer teléfono (índice 0): {primerTelefono}");
                Console.WriteLine($"Segundo teléfono (índice 1): {segundoTelefono}");
                
                // =============================================================
                // DEMOSTRACIÓN 3: Creación de un segundo estudiante
                // =============================================================
                
                Console.WriteLine("\n=== REGISTRO DE SEGUNDO ESTUDIANTE ===\n");
                
                // Creamos otro objeto Estudiante
                // Esto demuestra que podemos crear múltiples instancias de la clase
                Estudiante estudiante2 = new Estudiante(
                    id: 1002,
                    nombres: "María Fernanda",
                    apellidos: "García Rodríguez",
                    direccion: "Calle Secundaria 456, Quevedo"
                );
                
                // Establecemos diferentes números de teléfono
                estudiante2.EstablecerTelefonos(
                    "0987654321",  // Teléfono móvil
                    "052111222",   // Teléfono convencional
                    "042333444"    // Teléfono adicional
                );
                
                // Mostramos la información del segundo estudiante
                estudiante2.MostrarInformacion();
                
                // =============================================================
                // DEMOSTRACIÓN 4: Uso de métodos adicionales
                // =============================================================
                
                Console.WriteLine("=== FUNCIONALIDADES ADICIONALES ===\n");
                
                // Usamos métodos getter para obtener información específica
                Console.WriteLine($"ID del estudiante 2: {estudiante2.ObtenerId()}");
                Console.WriteLine($"Nombre completo: {estudiante2.ObtenerNombreCompleto()}");
                
                // Modificamos un teléfono específico
                estudiante2.ModificarTelefono(1, "052999888");  // Cambia el segundo teléfono
                
                // Mostramos la información actualizada
                Console.WriteLine("\nInformación actualizada del estudiante 2:");
                estudiante2.MostrarInformacion();
                
                // =============================================================
                // DEMOSTRACIÓN 5: Validación de índices (caso de error)
                // =============================================================
                
                Console.WriteLine("=== VALIDACIÓN DE ÍNDICES ===\n");
                
                // Intentamos acceder a un índice que no existe
                // Esto debería retornar el mensaje "Índice no válido"
                string telefonoInvalido = estudiante1.ObtenerTelefono(5);
                Console.WriteLine($"Intento de acceso a índice 5: {telefonoInvalido}");
                
                // Intentamos acceder a un índice negativo
                telefonoInvalido = estudiante1.ObtenerTelefono(-1);
                Console.WriteLine($"Intento de acceso a índice -1: {telefonoInvalido}");
                
                // =============================================================
                // DEMOSTRACIÓN 6: Mostrar resumen de todos los estudiantes
                // =============================================================
                
                Console.WriteLine("\n=== RESUMEN DE ESTUDIANTES REGISTRADOS ===\n");
                
                Console.WriteLine($"Total de estudiantes procesados: 2");
                Console.WriteLine($"Estudiante 1: {estudiante1.ObtenerNombreCompleto()}");
                Console.WriteLine($"Estudiante 2: {estudiante2.ObtenerNombreCompleto()}");
            }
            // Manejo de excepciones (errores en tiempo de ejecución)
            catch (Exception ex)
            {
                // Si ocurre algún error, mostramos un mensaje informativo
                Console.WriteLine($"\n¡ERROR EN EL PROGRAMA!");
                Console.WriteLine($"Tipo de error: {ex.GetType().Name}");
                Console.WriteLine($"Mensaje: {ex.Message}");
                Console.WriteLine("\nPor favor, verifique los datos e intente nuevamente.");
            }
            
            // =================================================================
            // FINALIZACIÓN DEL PROGRAMA
            // =================================================================
            
            Console.WriteLine("\n==========================================");
            Console.WriteLine("PROGRAMA FINALIZADO CORRECTAMENTE");
            Console.WriteLine("==========================================");
            
            // Mensaje final y espera de entrada del usuario
            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();  // Espera que el usuario presione una tecla
        }
    }
}

// =============================================================================
// NOTAS IMPORTANTES PARA EL DOCENTE:
// =============================================================================
// 
// 1. ESTRUCTURA DEL PROGRAMA:
//    - Namespace: Agrupa las clases relacionadas
//    - Clase Estudiante: Modela los datos y comportamiento de un estudiante
//    - Clase Program: Contiene el punto de entrada Main
//
// 2. CONCEPTOS CLAVE IMPLEMENTADOS:
//    a) CLASES: Plantilla para crear objetos (Estudiante)
//    b) OBJETOS: Instancias de una clase (estudiante1, estudiante2)
//    c) ARRAYS: Colección de elementos del mismo tipo (telefonos[])
//    d) ENCAPSULAMIENTO: Atributos privados, métodos públicos
//    e) MÉTODOS: Funciones que definen el comportamiento
//
// 3. CARACTERÍSTICAS DEL ARRAY:
//    - Tamaño fijo: 3 elementos (new string[3])
//    - Índices: 0, 1, 2 (siempre comienzan en 0)
//    - Acceso: telefonos[0] para primer elemento
//    - Validación: Se verifica que los índices estén en rango
//
// 4. BUENAS PRÁCTICAS INCLUIDAS:
//    - Comentarios descriptivos
//    - Validación de entradas
//    - Manejo de errores (try-catch)
//    - Nombres significativos de variables y métodos
//    - Separación de responsabilidades
//
// =============================================================================