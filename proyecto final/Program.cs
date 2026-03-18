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
    Console.Write("\nSeleccione una opción: ");

    string entrada = Console.ReadLine();
    opcion = int.Parse(entrada);
} while (true);