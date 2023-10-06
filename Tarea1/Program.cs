using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea1
{
    internal class Program
    {
        static string[] cedulas = new string[10];
        static string[] nombres = new string[10];
        static double[] promedios = new double[10];
        static string[] condiciones = new string[10];
        static int cantidadEstudiantes = 0;

        static void ModificarEstudiantes()
        {
            Console.Write("Ingrese la cédula del estudiante a modificar: ");
            string cedulaModificar = Console.ReadLine();
            bool encontrado = false;

            for (int i = 0; i < cantidadEstudiantes; i++)
            {
                if (cedulas[i] == cedulaModificar)
                {
                    Console.Write("Ingrese el nuevo nombre: ");
                    nombres[i] = Console.ReadLine();
                    Console.Write("Ingrese el nuevo promedio: ");
                    double nuevoPromedio = double.Parse(Console.ReadLine());

                    if (nuevoPromedio >= 70)
                        condiciones[i] = "APROBADO";
                    else if (nuevoPromedio >= 60)
                        condiciones[i] = "REPROBADO";
                    else
                        condiciones[i] = "APLAZADO";

                    promedios[i] = nuevoPromedio;
                    Console.WriteLine("Estudiante modificado exitosamente.");
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Estudiante no encontrado.");
            }
        }

        static void EliminarEstudiantes()
        {
            Console.Write("Ingrese la cédula del estudiante a eliminar: ");
            string cedulaEliminar = Console.ReadLine();
            bool encontrado = false;

            for (int i = 0; i < cantidadEstudiantes; i++)
            {
                if (cedulas[i] == cedulaEliminar)
                {
                    for (int j = i; j < cantidadEstudiantes - 1; j++)
                    {
                        cedulas[j] = cedulas[j + 1];
                        nombres[j] = nombres[j + 1];
                        promedios[j] = promedios[j + 1];
                        condiciones[j] = condiciones[j + 1];
                    }

                    cantidadEstudiantes--;
                    Console.WriteLine("Estudiante eliminado exitosamente.");
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Estudiante no encontrado.");
            }
        }

        static void SubmenuReportes()
        {
            int opcion;
            do
            {
                Console.WriteLine("Submenú Reportes");
                Console.WriteLine("1. Reporte Estudiantes por Condición");
                Console.WriteLine("2. Reporte Todos los datos");
                Console.WriteLine("3. Regresar al Menú Principal");
                Console.Write("Elija una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        ReporteEstudiantesPorCondicion();
                        break;
                    case 2:
                        ReporteTodosLosDatos();
                        break;
                    case 3:
                        Console.WriteLine("Regresando al Menú Principal.");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            } while (opcion != 3);
        }

        static void ReporteEstudiantesPorCondicion()
        {
            Console.WriteLine("Seleccione una condición:");
            Console.WriteLine("1. APROBADO");
            Console.WriteLine("2. REPROBADO");
            Console.WriteLine("3. APLAZADO");
            int opcion = int.Parse(Console.ReadLine());

            Console.WriteLine("Cedula\t\tNombre\t\tPromedio\tCondicion");
            Console.WriteLine("=========================================");

            for (int i = 0; i < cantidadEstudiantes; i++)
            {
                if (opcion == 1 && condiciones[i] == "APROBADO")
                {
                    Console.WriteLine($"{cedulas[i]}\t\t{nombres[i]}\t\t{promedios[i]}\t\t{condiciones[i]}");
                }
                else if (opcion == 2 && condiciones[i] == "REPROBADO")
                {
                    Console.WriteLine($"{cedulas[i]}\t\t{nombres[i]}\t\t{promedios[i]}\t\t{condiciones[i]}");
                }
                else if (opcion == 3 && condiciones[i] == "APLAZADO")
                {
                    Console.WriteLine($"{cedulas[i]}\t\t{nombres[i]}\t\t{promedios[i]}\t\t{condiciones[i]}");
                }
            }

            Console.WriteLine("\t\t<PULSE CUALQUIER TECLA PARA ABANDONAR>");
            Console.ReadKey();
        }

        static void ReporteTodosLosDatos()
        {
            Console.WriteLine("Cedula\t\tNombre\t\tPromedio\tCondicion");
            Console.WriteLine("=========================================");

            double maxPromedio = promedios[0];
            double minPromedio = promedios[0];
            string estudianteMaxPromedio = nombres[0];
            string estudianteMinPromedio = nombres[0];

            for (int i = 0; i < cantidadEstudiantes; i++)
            {
                Console.WriteLine($"{cedulas[i]}\t\t{nombres[i]}\t\t{promedios[i]}\t\t{condiciones[i]}");

                if (promedios[i] > maxPromedio)
                {
                    maxPromedio = promedios[i];
                    estudianteMaxPromedio = nombres[i];
                }

                if (promedios[i] < minPromedio)
                {
                    minPromedio = promedios[i];
                    estudianteMinPromedio = nombres[i];
                }
            }

            Console.WriteLine("\nEstadísticas:");
            Console.WriteLine($"Cantidad de estudiantes: {cantidadEstudiantes}");
            Console.WriteLine($"Estudiante con el promedio mayor: {estudianteMaxPromedio} (Promedio: {maxPromedio})");
            Console.WriteLine($"Estudiante con el promedio menor: {estudianteMinPromedio} (Promedio: {minPromedio})");

            Console.WriteLine("\t\t<PULSE CUALQUIER TECLA PARA ABANDONAR>");
            Console.ReadKey();
        }
    }
}
