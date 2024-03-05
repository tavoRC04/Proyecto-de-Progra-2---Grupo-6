using System;

class Program
{
    static void Main()
    {
        // Declaracion de variables para almacenar datos de estudiantes
        int cant = 0;
        int[] cedula = new int[cant];
        string[] nombre = new string[cant];
        int[] promedio = new int[cant];

        int opcion = 0;

        do
        {
            // Menu Principal
            Console.Clear();
            Console.WriteLine("==========Menu Principal==========");
            Console.WriteLine("1-Registrar datos de estudiantes");
            Console.WriteLine("2-Consultar estudiantes");
            Console.WriteLine("3-Modificar estudiantes");
            Console.WriteLine("4-Eliminar estudiantes");
            Console.WriteLine("5-Submenu Reportes");
            Console.WriteLine("6-Salir");
            Console.WriteLine("=================================");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                // ingresar estudiantes
                case 1:
                    if (cant >= 100)
                    {
                        Console.WriteLine("No es posible registrar más estudiantes. Se ha alcanzado el límite.");
                        break;
                    }

                    do
                    {
                        Console.Clear();
                        Array.Resize(ref cedula, cant + 1);
                        Array.Resize(ref nombre, cant + 1);
                        Array.Resize(ref promedio, cant + 1);

                        // Validacion: Evitar cedulas duplicadas
                        bool cedulaRepetida;
                        do
                        {
                            Console.WriteLine($"Digite la cedula del estudiante {cant + 1}:");
                            cedula[cant] = int.Parse(Console.ReadLine());

                            cedulaRepetida = false;
                            for (int i = 0; i < cant; i++)
                            {
                                if (cedula[i] == cedula[cant])
                                {
                                    Console.WriteLine("Ya existe un estudiante con esa cedula. Ingrese otra.");
                                    cedulaRepetida = true;
                                    break;
                                }
                            }

                        } while (cedulaRepetida);

                        // Validacion: que el nombre solo contenga letras
                        bool nombreValido;
                        do
                        {
                            Console.WriteLine($"Digite el Nombre del estudiante {cant + 1}:");
                            nombre[cant] = Console.ReadLine();

                            nombreValido = true;
                            foreach (char c in nombre[cant])
                            {
                                if (!char.IsLetter(c))
                                {
                                    Console.WriteLine("El nombre solo puede contener letras. Ingrese otro nombre.");
                                    nombreValido = false;
                                    break;
                                }
                            }

                        } while (!nombreValido);

                        Console.WriteLine($"Digite el Promedio obtenido del estudiante {cant + 1}:");
                        while (!int.TryParse(Console.ReadLine(), out promedio[cant]))
                        {
                            Console.WriteLine("Ingrese un valor numérico válido para el promedio.");
                            Console.WriteLine($"Digite el Promedio obtenido del estudiante {cant + 1}:");
                        }










                        cant++; // Incrementamos la cantidad de estudiantes

                        Console.WriteLine("¿Desea ingresar otro estudiante? (S/N)");
                    } while (Console.ReadLine().ToUpper() == "S");

                    break;

                // consultar estudiantes
                case 2:
                    if (cant == 0)
                    {
                        Console.WriteLine("No hay estudiantes registrados para consultar.");
                        break;
                    }

                    Console.Clear();
                    Console.WriteLine("==========Consulta de Estudiantes==========");
                    for (int i = 0; i < cant; i++)
                    {
                        Console.WriteLine($"Cedula: {cedula[i]}, Nombre: {nombre[i]}, Promedio: {promedio[i]}");
                    }
                    Console.WriteLine("===========================================");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                // modificar estudiantes
                case 3:
                    if (cant == 0)
                    {
                        Console.WriteLine("No hay estudiantes registrados para modificar.");
                        break;
                    }

                    Console.Clear();
                    Console.WriteLine("==========Modificar Estudiantes==========");
                    Console.WriteLine("Ingrese la cedula del estudiante que desea modificar:");
                    int cedulaBusqueda = int.Parse(Console.ReadLine());

                    bool encontrado = false;
                    for (int i = 0; i < cant; i++)
                    {
                        if (cedula[i] == cedulaBusqueda)
                        {
                            Console.WriteLine($"Estudiante encontrado: Cedula: {cedula[i]}, Nombre: {nombre[i]}, Promedio: {promedio[i]}");
                            Console.WriteLine("Ingrese los nuevos datos:");


                            // Validar que el nombre solo contenga letras
                            bool nuevoNombreValido;
                            do
                            {
                                Console.WriteLine("Nombre:");
                                nombre[i] = Console.ReadLine();

                                nuevoNombreValido = true;
                                foreach (char c in nombre[i])
                                {
                                    if (!char.IsLetter(c))
                                    {
                                        Console.WriteLine("El nombre solo puede contener letras. Ingrese otro nombre.");
                                        nuevoNombreValido = false;
                                        break;
                                    }
                                }

                            } while (!nuevoNombreValido);

                            Console.WriteLine("Promedio:");
                            promedio[i] = int.Parse(Console.ReadLine());
                            encontrado = true;
                            break;
                        }
                    }

                    if (!encontrado)
                    {
                        Console.WriteLine("Estudiante no encontrado.");
                    }

                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                // eliminar estudiantes
                case 4:
                    if (cant == 0)
                    {
                        Console.WriteLine("No hay estudiantes registrados para eliminar.");
                        break;
                    }

                    Console.Clear();
                    Console.WriteLine("==========Eliminar Estudiantes==========");
                    Console.WriteLine("Ingrese la cedula del estudiante que desea eliminar:");
                    int cedulaEliminar = int.Parse(Console.ReadLine());

                    bool encontradoEliminar = false;
                    for (int i = 0; i < cant; i++)
                    {
                        if (cedula[i] == cedulaEliminar)
                        {
                            encontradoEliminar = true;
                            for (int j = i; j < cant - 1; j++)
                            {
                                cedula[j] = cedula[j + 1];
                                nombre[j] = nombre[j + 1];
                                promedio[j] = promedio[j + 1];
                            }
                            cant--;
                            Array.Resize(ref cedula, cant);
                            Array.Resize(ref nombre, cant);
                            Array.Resize(ref promedio, cant);
                            Console.WriteLine("Estudiante eliminado correctamente.");
                            break;
                        }
                    }

                    if (!encontradoEliminar)
                    {
                        Console.WriteLine("Estudiante no encontrado.");
                    }

                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();

                    break;

                // submenu reportes
                case 5:
                    if (cant == 0)
                    {
                        Console.WriteLine("No hay estudiantes registrados para generar reportes.");
                        break;
                    }

                    int subopcionReportes = 0;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("==========Submenú Reportes==========");
                        Console.WriteLine("1- Reporte Estudiantes por Condición");
                        Console.WriteLine("2- Reporte Todos los datos");
                        Console.WriteLine("3- Regresar al Menu Principal");
                        Console.WriteLine("=====================================");
                        subopcionReportes = int.Parse(Console.ReadLine());

                        switch (subopcionReportes)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("==========Reporte Estudiantes por Condición==========");
                                Console.WriteLine("Ingrese la condición (Aprobado/Reprobado):");
                                string condicion = Console.ReadLine();

                                if (condicion.ToLower() == "aprobado")
                                {
                                    Console.WriteLine("Estudiantes Aprobados:");
                                    for (int i = 0; i < cant; i++)
                                    {
                                        if (promedio[i] >= 70)
                                        {
                                            Console.WriteLine($"Cedula: {cedula[i]}, Nombre: {nombre[i]}, Promedio: {promedio[i]}");
                                        }
                                    }
                                }
                                else if (condicion.ToLower() == "reprobado")
                                {
                                    Console.WriteLine("Estudiantes Reprobados:");
                                    for (int i = 0; i < cant; i++)
                                    {
                                        if (promedio[i] < 70)
                                        {
                                            Console.WriteLine($"Cedula: {cedula[i]}, Nombre: {nombre[i]}, Promedio: {promedio[i]}");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Condición no válida.");
                                }

                                Console.WriteLine("Presione cualquier tecla para continuar...");
                                Console.ReadKey();
                                break;

                            case 2:
                                Console.Clear();
                                Console.WriteLine("==========Reporte Todos los datos==========");
                                for (int i = 0; i < cant; i++)
                                {
                                    Console.WriteLine($"Cedula: {cedula[i]}, Nombre: {nombre[i]}, Promedio: {promedio[i]}");
                                }
                                Console.WriteLine("===========================================");
                                Console.WriteLine("Presione cualquier tecla para continuar...");
                                Console.ReadKey();
                                break;
                        }
                    } while (subopcionReportes != 3);
                    break;

                case 6:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Por favor, ingrese una opción válida.");
                    break;

            }

        } while (opcion != 6);
    }
}

