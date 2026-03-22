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

    if (!int.TryParse(Console.ReadLine(), out opcion))
    {
        opcion = 0;

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

    } while (opcion != 5) ;

    void EvaluarContenido()
    {
        Console.WriteLine("--- INGRESO DE DATOS ---");

        int tipo = 0;
        while (tipo < 1 || tipo > 4)
        {
            Console.Write("Tipo (1. Película, 2. Serie, 3. Documental, 4. En vivo): ");
            int.TryParse(Console.ReadLine(), out tipo);
        }

        int duracion = -1;
        while (duracion < 0)
        {
            Console.Write("Duración en minutos: ");
            int.TryParse(Console.ReadLine(), out duracion);
        }

        int clasificacion = 0;
        while (clasificacion < 1 || clasificacion > 3)
        {
            Console.Write("Clasificación (1. Todo público, 2. +13, 3. +18): ");
            int.TryParse(Console.ReadLine(), out clasificacion);
        }
        int hora = -1;
        while (hora < 0 || hora > 23)
        {
            Console.Write("Hora programada (0-23): ");
            int.TryParse(Console.ReadLine(), out hora);
        }

        int produccion = 0;
        while (produccion < 1 || produccion > 3)
        {
            Console.Write("Nivel de producción (1. Bajo, 2. Medio, 3. Alto): ");
            int.TryParse(Console.ReadLine(), out produccion);
        }

        bool pasoTecnica = true;
        string razonRechazo = "";

        if (clasificacion == 2 && (hora < 6 || hora > 22))
        {
            pasoTecnica = false;
            razonRechazo = "Contenido +13 fuera de horario (6-22h).";
        }
        else if (clasificacion == 3 && (hora > 5 && hora < 22))
        {
            pasoTecnica = false;
            razonRechazo = "Contenido +18 fuera de horario (22-5h).";
        }
        if (pasoTecnica)
        {
            if (tipo == 1 && (duracion < 60 || duracion > 180)) { pasoTecnica = false; razonRechazo = "Película fuera de rango."; }
            else if (tipo == 2 && (duracion < 20 || duracion > 90)) { pasoTecnica = false; razonRechazo = "Serie fuera de rango."; }
            else if (tipo == 3 && (duracion < 30 || duracion > 120)) { pasoTecnica = false; razonRechazo = "Documental fuera de rango."; }
            else if (tipo == 4 && (duracion < 30 || duracion > 240)) { pasoTecnica = false; razonRechazo = "Evento fuera de rango."; }
        }
        if (pasoTecnica && produccion == 1 && clasificacion == 3)
        {
            pasoTecnica = false;
            razonRechazo = "Producción baja no permitida para contenido +18.";
        }
        int impacto = 0;
        if (pasoTecnica)
        {
            if (produccion == 3 || duracion > 120 || (hora >= 20 && hora <= 23))
            {
                impacto = 3;
                impactoAltoCount++;
            }
            else if (produccion == 2 || (duracion >= 60 && duracion <= 120))
            {
                impacto = 2;
                impactoMedioCount++;
            }
            else
            {
                impacto = 1;
                impactoBajoCount++;
            }
        }
        totalEvaluados++;
        Console.WriteLine("\n--- RESULTADO DE EVALUACIÓN ---");
        if (!pasoTecnica)
        {
            Console.WriteLine("DECISIÓN: RECHAZAR");
            Console.WriteLine("RAZÓN: " + razonRechazo);
            rechazados++;
        }
        else if (impacto == 3)
        {
            Console.WriteLine("DECISIÓN: ENVIAR A REVISIÓN");
            Console.WriteLine("RAZÓN: El impacto es Alto.");
            enRevision++;
        }
        else
        {
            Console.WriteLine("DECISIÓN: PUBLICAR");
            Console.WriteLine("RAZÓN: Cumple reglas técnicas e impacto adecuado.");
            publicados++;
        }
    }