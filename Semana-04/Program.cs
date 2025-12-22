using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaTurnosClinica
{
    // Clase que representa un paciente
    class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public int Edad { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} | Nombre: {Nombre} | Tel: {Telefono} | Edad: {Edad}";
        }
    }

    // Enumeración para los estados de un turno
    enum EstadoTurno
    {
        Pendiente,
        Confirmado,
        Cancelado,
        Completado
    }

    // Clase que representa un turno médico
    class Turno
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public Paciente Paciente { get; set; }
        public string Medico { get; set; }
        public string Especialidad { get; set; }
        public EstadoTurno Estado { get; set; }
        public string Observaciones { get; set; }

        public override string ToString()
        {
            return $"Turno #{Id} | {Fecha.ToShortDateString()} {Hora} | " +
                   $"Paciente: {Paciente.Nombre} | Médico: Dr. {Medico} | " +
                   $"Especialidad: {Especialidad} | Estado: {Estado}";
        }
    }

    // Clase principal que gestiona la agenda de turnos
    class Agenda
    {
        private List<Turno> turnos = new List<Turno>();
        private List<Paciente> pacientes = new List<Paciente>();
        private int siguienteIdTurno = 1;
        private int siguienteIdPaciente = 1;

        // Método para agregar un nuevo paciente
        public Paciente AgregarPaciente(string nombre, string telefono, int edad, string email)
        {
            var paciente = new Paciente
            {
                Id = siguienteIdPaciente++,
                Nombre = nombre,
                Telefono = telefono,
                Edad = edad,
                Email = email
            };
            
            pacientes.Add(paciente);
            Console.WriteLine($"\n✓ Paciente registrado exitosamente (ID: {paciente.Id})");
            return paciente;
        }

        // Método para agendar un nuevo turno
        public bool AgendarTurno(Paciente paciente, DateTime fecha, string hora, 
                                 string medico, string especialidad, string observaciones)
        {
            // Validar que no haya un turno en el mismo horario con el mismo médico
            bool horarioOcupado = turnos.Any(t => 
                t.Fecha.Date == fecha.Date && 
                t.Hora == hora && 
                t.Medico == medico && 
                t.Estado != EstadoTurno.Cancelado);

            if (horarioOcupado)
            {
                Console.WriteLine("\n✗ El médico ya tiene un turno en ese horario");
                return false;
            }

            var turno = new Turno
            {
                Id = siguienteIdTurno++,
                Fecha = fecha,
                Hora = hora,
                Paciente = paciente,
                Medico = medico,
                Especialidad = especialidad,
                Estado = EstadoTurno.Pendiente,
                Observaciones = observaciones
            };

            turnos.Add(turno);
            Console.WriteLine($"\n✓ Turno agendado exitosamente (ID: {turno.Id})");
            return true;
        }

        // Método para cancelar un turno
        public bool CancelarTurno(int idTurno)
        {
            var turno = turnos.FirstOrDefault(t => t.Id == idTurno);
            
            if (turno == null)
            {
                Console.WriteLine("\n✗ Turno no encontrado");
                return false;
            }

            if (turno.Estado == EstadoTurno.Cancelado)
            {
                Console.WriteLine("\n✗ El turno ya está cancelado");
                return false;
            }

            turno.Estado = EstadoTurno.Cancelado;
            Console.WriteLine("\n✓ Turno cancelado exitosamente");
            return true;
        }

        // Método para confirmar un turno
        public bool ConfirmarTurno(int idTurno)
        {
            var turno = turnos.FirstOrDefault(t => t.Id == idTurno);
            
            if (turno == null)
            {
                Console.WriteLine("\n✗ Turno no encontrado");
                return false;
            }

            turno.Estado = EstadoTurno.Confirmado;
            Console.WriteLine("\n✓ Turno confirmado exitosamente");
            return true;
        }

        // Método para mostrar todos los turnos
        public void MostrarTodosTurnos()
        {
            Console.WriteLine("\n=== LISTA COMPLETA DE TURNOS ===");
            
            if (!turnos.Any())
            {
                Console.WriteLine("No hay turnos agendados.");
                return;
            }

            var turnosOrdenados = turnos.OrderBy(t => t.Fecha).ThenBy(t => t.Hora);
            
            foreach (var turno in turnosOrdenados)
            {
                Console.WriteLine(turno.ToString());
            }
            
            Console.WriteLine($"\nTotal de turnos: {turnos.Count}");
        }

        // Método para mostrar turnos por fecha
        public void MostrarTurnosPorFecha(DateTime fecha)
        {
            Console.WriteLine($"\n=== TURNOS PARA EL {fecha.ToShortDateString()} ===");
            
            var turnosFecha = turnos
                .Where(t => t.Fecha.Date == fecha.Date && t.Estado != EstadoTurno.Cancelado)
                .OrderBy(t => t.Hora);

            if (!turnosFecha.Any())
            {
                Console.WriteLine("No hay turnos para esta fecha.");
                return;
            }

            foreach (var turno in turnosFecha)
            {
                Console.WriteLine(turno.ToString());
            }
        }

        // Método para mostrar turnos por paciente
        public void MostrarTurnosPorPaciente(int idPaciente)
        {
            var paciente = pacientes.FirstOrDefault(p => p.Id == idPaciente);
            
            if (paciente == null)
            {
                Console.WriteLine("\n✗ Paciente no encontrado");
                return;
            }

            Console.WriteLine($"\n=== TURNOS DE {paciente.Nombre.ToUpper()} ===");
            
            var turnosPaciente = turnos
                .Where(t => t.Paciente.Id == idPaciente)
                .OrderByDescending(t => t.Fecha);

            if (!turnosPaciente.Any())
            {
                Console.WriteLine("El paciente no tiene turnos agendados.");
                return;
            }

            foreach (var turno in turnosPaciente)
            {
                Console.WriteLine(turno.ToString());
            }
        }

        // Método para buscar paciente por nombre
        public List<Paciente> BuscarPacientePorNombre(string nombre)
        {
            return pacientes
                .Where(p => p.Nombre.ToLower().Contains(nombre.ToLower()))
                .ToList();
        }

        // Método para mostrar todos los pacientes
        public void MostrarTodosPacientes()
        {
            Console.WriteLine("\n=== LISTA DE PACIENTES ===");
            
            if (!pacientes.Any())
            {
                Console.WriteLine("No hay pacientes registrados.");
                return;
            }

            foreach (var paciente in pacientes)
            {
                Console.WriteLine(paciente.ToString());
            }
        }

        // Método para mostrar estadísticas
        public void MostrarEstadisticas()
        {
            Console.WriteLine("\n=== ESTADÍSTICAS DE LA AGENDA ===");
            Console.WriteLine($"Total de pacientes registrados: {pacientes.Count}");
            Console.WriteLine($"Total de turnos agendados: {turnos.Count}");
            Console.WriteLine($"Turnos pendientes: {turnos.Count(t => t.Estado == EstadoTurno.Pendiente)}");
            Console.WriteLine($"Turnos confirmados: {turnos.Count(t => t.Estado == EstadoTurno.Confirmado)}");
            Console.WriteLine($"Turnos cancelados: {turnos.Count(t => t.Estado == EstadoTurno.Cancelado)}");
            Console.WriteLine($"Turnos completados: {turnos.Count(t => t.Estado == EstadoTurno.Completado)}");
        }
    }

    // Clase principal del programa
    class Program
    {
        static void Main(string[] args)
        {
            Agenda agenda = new Agenda();
            bool salir = false;

            Console.WriteLine("========================================");
            Console.WriteLine("   AGENDA DE TURNOS - CLÍNICA SALUD+");
            Console.WriteLine("========================================\n");

            while (!salir)
            {
                MostrarMenu();
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarNuevoPaciente(agenda);
                        break;
                        
                    case "2":
                        AgendarNuevoTurno(agenda);
                        break;
                        
                    case "3":
                        ConsultarTurnos(agenda);
                        break;
                        
                    case "4":
                        GestionarTurno(agenda);
                        break;
                        
                    case "5":
                        agenda.MostrarTodosPacientes();
                        break;
                        
                    case "6":
                        agenda.MostrarEstadisticas();
                        break;
                        
                    case "7":
                        CargarDatosDemo(agenda);
                        break;
                        
                    case "8":
                        salir = true;
                        Console.WriteLine("\n¡Gracias por usar el sistema de agenda!");
                        break;
                        
                    default:
                        Console.WriteLine("\n✗ Opción no válida. Intente nuevamente.");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("=== MENÚ PRINCIPAL ===");
            Console.WriteLine("1. Registrar nuevo paciente");
            Console.WriteLine("2. Agendar nuevo turno");
            Console.WriteLine("3. Consultar turnos");
            Console.WriteLine("4. Gestionar turno (confirmar/cancelar)");
            Console.WriteLine("5. Ver todos los pacientes");
            Console.WriteLine("6. Ver estadísticas");
            Console.WriteLine("7. Cargar datos de demostración");
            Console.WriteLine("8. Salir");
            Console.Write("\nSeleccione una opción: ");
        }

        static void RegistrarNuevoPaciente(Agenda agenda)
        {
            Console.WriteLine("\n=== REGISTRO DE NUEVO PACIENTE ===");
            
            Console.Write("Nombre completo: ");
            string nombre = Console.ReadLine();
            
            Console.Write("Teléfono: ");
            string telefono = Console.ReadLine();
            
            Console.Write("Edad: ");
            int edad;
            while (!int.TryParse(Console.ReadLine(), out edad) || edad <= 0)
            {
                Console.Write("Edad no válida. Ingrese nuevamente: ");
            }
            
            Console.Write("Email: ");
            string email = Console.ReadLine();
            
            agenda.AgregarPaciente(nombre, telefono, edad, email);
        }

        static void AgendarNuevoTurno(Agenda agenda)
        {
            Console.WriteLine("\n=== AGENDAR NUEVO TURNO ===");
            
            // Buscar paciente
            Console.Write("Ingrese nombre del paciente: ");
            string nombrePaciente = Console.ReadLine();
            
            var pacientesEncontrados = agenda.BuscarPacientePorNombre(nombrePaciente);
            
            if (!pacientesEncontrados.Any())
            {
                Console.WriteLine("\n✗ No se encontró el paciente. Regístrelo primero.");
                return;
            }
            
            Console.WriteLine("\nPacientes encontrados:");
            for (int i = 0; i < pacientesEncontrados.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pacientesEncontrados[i]}");
            }
            
            Console.Write("\nSeleccione el paciente (número): ");
            int seleccion;
            while (!int.TryParse(Console.ReadLine(), out seleccion) || seleccion < 1 || seleccion > pacientesEncontrados.Count)
            {
                Console.Write("Selección no válida. Ingrese nuevamente: ");
            }
            
            Paciente pacienteSeleccionado = pacientesEncontrados[seleccion - 1];
            
            // Ingresar datos del turno
            Console.Write("\nFecha del turno (dd/mm/aaaa): ");
            DateTime fecha;
            while (!DateTime.TryParse(Console.ReadLine(), out fecha) || fecha < DateTime.Today)
            {
                Console.Write("Fecha no válida. Ingrese nuevamente: ");
            }
            
            Console.Write("Hora del turno (HH:mm): ");
            string hora = Console.ReadLine();
            
            Console.Write("Nombre del médico: ");
            string medico = Console.ReadLine();
            
            Console.Write("Especialidad: ");
            string especialidad = Console.ReadLine();
            
            Console.Write("Observaciones: ");
            string observaciones = Console.ReadLine();
            
            agenda.AgendarTurno(pacienteSeleccionado, fecha, hora, medico, especialidad, observaciones);
        }

        static void ConsultarTurnos(Agenda agenda)
        {
            Console.WriteLine("\n=== CONSULTA DE TURNOS ===");
            Console.WriteLine("1. Ver todos los turnos");
            Console.WriteLine("2. Ver turnos por fecha");
            Console.WriteLine("3. Ver turnos por paciente");
            Console.Write("\nSeleccione una opción: ");
            
            string opcion = Console.ReadLine();
            
            switch (opcion)
            {
                case "1":
                    agenda.MostrarTodosTurnos();
                    break;
                    
                case "2":
                    Console.Write("\nIngrese fecha (dd/mm/aaaa): ");
                    DateTime fecha;
                    while (!DateTime.TryParse(Console.ReadLine(), out fecha))
                    {
                        Console.Write("Fecha no válida. Ingrese nuevamente: ");
                    }
                    agenda.MostrarTurnosPorFecha(fecha);
                    break;
                    
                case "3":
                    Console.Write("\nIngrese ID del paciente: ");
                    int idPaciente;
                    while (!int.TryParse(Console.ReadLine(), out idPaciente))
                    {
                        Console.Write("ID no válido. Ingrese nuevamente: ");
                    }
                    agenda.MostrarTurnosPorPaciente(idPaciente);
                    break;
                    
                default:
                    Console.WriteLine("\n✗ Opción no válida.");
                    break;
            }
        }

        static void GestionarTurno(Agenda agenda)
        {
            Console.WriteLine("\n=== GESTIÓN DE TURNO ===");
            Console.Write("Ingrese ID del turno a gestionar: ");
            
            int idTurno;
            while (!int.TryParse(Console.ReadLine(), out idTurno))
            {
                Console.Write("ID no válido. Ingrese nuevamente: ");
            }
            
            Console.WriteLine("\n1. Confirmar turno");
            Console.WriteLine("2. Cancelar turno");
            Console.Write("\nSeleccione una acción: ");
            
            string accion = Console.ReadLine();
            
            switch (accion)
            {
                case "1":
                    agenda.ConfirmarTurno(idTurno);
                    break;
                    
                case "2":
                    agenda.CancelarTurno(idTurno);
                    break;
                    
                default:
                    Console.WriteLine("\n✗ Acción no válida.");
                    break;
            }
        }

        static void CargarDatosDemo(Agenda agenda)
        {
            Console.WriteLine("\n=== CARGANDO DATOS DE DEMOSTRACIÓN ===");
            
            // Crear pacientes demo
            var paciente1 = agenda.AgregarPaciente("Juan Pérez", "0991234567", 35, "juan@email.com");
            var paciente2 = agenda.AgregarPaciente("María García", "0987654321", 28, "maria@email.com");
            var paciente3 = agenda.AgregarPaciente("Carlos López", "0971122334", 42, "carlos@email.com");
            
            // Crear turnos demo
            agenda.AgendarTurno(paciente1, DateTime.Today.AddDays(1), "09:00", "Rodríguez", "Cardiología", "Control rutina");
            agenda.AgendarTurno(paciente2, DateTime.Today.AddDays(2), "10:30", "Gómez", "Pediatría", "Vacunación");
            agenda.AgendarTurno(paciente3, DateTime.Today.AddDays(1), "14:00", "Rodríguez", "Cardiología", "Electrocardiograma");
            agenda.AgendarTurno(paciente1, DateTime.Today.AddDays(3), "11:00", "Martínez", "Traumatología", "Revisión lesión");
            
            Console.WriteLine("\n✓ Datos de demostración cargados exitosamente.");
            Console.WriteLine("Pacientes: 3 | Turnos: 4");
        }
    }
}