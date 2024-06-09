using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TP_ClubDeportivo
{
    public class ProgramaClubDeportivo
    {
        static List<Suplemento> suplementos = new List<Suplemento>(); // Acá definimos la lista de suplementos
        static List<ServicioDeportivo> servicios = new List<ServicioDeportivo>();// Acá definimos la de suplementos
        public static void Main(string[] args)
        {
            ClubDeportivo miclub = new ClubDeportivo();
            while (true)
            {
                Console.WriteLine("1. Cargar nuevo suplemento");
                Console.WriteLine("2. Mostrar detalle de los suplementos");
                Console.WriteLine("3. Agregar nuevo servicio");
                Console.WriteLine("4. Mostrar detalles de los servicios");
                Console.WriteLine("5. Salir de facturación");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("6. Correr test de prueba");
                Console.ResetColor();
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        CargarNuevoSuplemento(miclub);
                        break;
                    case "2":
                        MostrarDetalleSuplementos(miclub);
                        break;
                    case "3":
                        AgregarNuevoServicio(miclub);
                        break;
                    case "4":
                        MostrarDetallesServicios(miclub);
                        break;
                    case "5":
                        SalirFacturacion(miclub);
                        break;
                    case "6":
                        TestMain(miclub);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opción no válida. Por favor, ingrese un número del 1 al 5.");
                        Console.ResetColor();
                        break;
                }
            }
        }

        public static void CargarNuevoSuplemento(ClubDeportivo miclub)
        {

            Suplemento nuevoSuplemento = Suplemento.CrearSuplemento();
            miclub.suplementos.Add(nuevoSuplemento);
        }

        static void MostrarDetalleSuplementos(ClubDeportivo miclub)
        {
            Suplemento.ListarSuplementos(miclub.suplementos);
        }

        static void AgregarNuevoServicio(ClubDeportivo miclub)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Seleccione el tipo de servicio:");
            Console.ResetColor();
            Console.WriteLine("1. Entrenamiento Personalizado");
            Console.WriteLine("2. Clases Grupales");
            string opcionServicio = Console.ReadLine();


            string tipo = Utilidad.LeerEntradaNoVacia("Ingrese el nombre del entrenamiento o clase:");
            decimal duracion = Utilidad.LeerNumero("Ingrese la duración en minutos:");


            if (opcionServicio == "1")
            {
                var nuevoServicio = new EntrenamientoPersonalizado(tipo, duracion);
                miclub.servicios.Add(nuevoServicio);
                nuevoServicio.MostrarDetalles();

            }
            else if (opcionServicio == "2")
            {
                Console.WriteLine("Ingrese el número de participantes:");
                int numeroParticipantes = int.Parse(Console.ReadLine());
                miclub.servicios.Add(new ClasesGrupales(tipo, duracion, numeroParticipantes));
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opción no válida. Por favor, ingrese 1 para Entrenamiento Personalizado o 2 para Clases Grupales.");
                Console.ResetColor();
            }
        }

        public static void MostrarDetallesServicios(ClubDeportivo miclub)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Detalles de los servicios:");
            Console.ResetColor();
            foreach (var servicio in miclub.servicios)
            {
                servicio.MostrarDetalles();
            }
        }

        static void SalirFacturacion(ClubDeportivo miclub)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("MONTO TOTAL FACTURADO: " + miclub.CalcularMontoTotalFacturado());
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Cantidad de servicios simples: " + miclub.CantServiciosSimples());
            Console.ResetColor();

            Console.WriteLine("¿Está seguro de que desea salir? (s/n)");
            string confirmacion = Console.ReadLine();
            if (confirmacion.ToLower() == "s")
            {
                Environment.Exit(0);
            }
        }

        static void TestMain(ClubDeportivo miClub)
        {
            // Guarda la entrada estándar original
            TextReader originalInput = Console.In;

            // Define las entradas para cada uno de los métodos
            string simulatedInput = "Whey Protein\n30\n1000\n";
            var input = new StringReader(simulatedInput);

            // Se setea el ingreso de pueba
            Console.SetIn(input);

            // Se muestra ese ingreso para que se vea en consola
            Console.WriteLine(simulatedInput);

            // Llama al método CargarNuevoSuplemento
            ProgramaClubDeportivo.CargarNuevoSuplemento(miClub);

            // Restaura la entrada estándar original
            Console.SetIn(originalInput);

            // Llama a los otros métodos
            ProgramaClubDeportivo.MostrarDetalleSuplementos(miClub);

            // Simula la entrada para AgregarNuevoServicio
            // Simulación de entrenamiento personalizado
            simulatedInput = "1\nEntrenamiento Personalizado\n60\n";
            input = new StringReader(simulatedInput);
            Console.SetIn(input);
            Console.WriteLine(simulatedInput);
            ProgramaClubDeportivo.AgregarNuevoServicio(miClub);
            Console.SetIn(originalInput);

            // Simulación de clases grupales
            simulatedInput = "2\nClases Grupales\n60\n20\n";
            input = new StringReader(simulatedInput);
            Console.SetIn(input);
            Console.WriteLine(simulatedInput);
            ProgramaClubDeportivo.AgregarNuevoServicio(miClub);
            Console.SetIn(originalInput);

            ProgramaClubDeportivo.MostrarDetallesServicios(miClub);

            // Simula la entrada para SalirFacturacion con salida negativa para no finalizar el programa
            simulatedInput = "n\n";
            input = new StringReader(simulatedInput);
            Console.SetIn(input);
            Console.WriteLine(simulatedInput);
            ProgramaClubDeportivo.SalirFacturacion(miClub);
            Console.SetIn(originalInput);
        }
    }
}