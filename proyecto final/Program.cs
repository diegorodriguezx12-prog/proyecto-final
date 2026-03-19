using System;

int totalEvaluados = 0;
int publicados = 0;
int rechazados = 0;
int enRevision = 0;
int impactoAltoCount = 0;
int impactoMedioCount = 0;
int impactoBajoCount = 0;

int opcion = 0;

do
{
    Console.Clear();
    Console.WriteLine("====================================================");
    Console.WriteLine("   SIMULADOR DE STREAMING - PROYECTO 01");
    Console.WriteLine("====================================================");
    Console.WriteLine("1. Evaluar nuevo contenido");
    Console.WriteLine("2. Mostrar reglas del sistema");
    Console.WriteLine("3. Mostrar estadísticas de la sesión");
    Console.WriteLine("4. Reiniciar estadísticas");
    Console.WriteLine("5. Salir");
    Console.Write("Seleccione una opción: ");

    if (!int.TryParse(Console.ReadLine(), out opcion))
    {
        opcion = 0;
    }

    switch (opcion)
    {
        case 1:
            EvaluarContenido();
            break;
        case 2:
            MostrarReglas();
            break;
        case 3:
            MostrarEstadisticas();
            break;
        case 4:
            ReiniciarEstadisticas();
            break;
        case 5:
            FinalizarPrograma();
            break;
        default:
            Console.WriteLine("Error: Ingrese un número válido (1-5).");
            break;
    }

    if (opcion != 5)
    {
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

} while (opcion != 5);