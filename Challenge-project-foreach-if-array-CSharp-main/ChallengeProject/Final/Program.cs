/* 
Esta aplicación de consola en C# está diseñada para:
- Utilizar matrices para almacenar los nombres de los estudiantes y las puntuaciones de las tareas.
- Utilizar una declaración `foreach` para iterar a través de los nombres de los estudiantes como un bucle externo del programa.
- Utilizar una declaración `if` dentro del bucle externo para identificar el nombre del estudiante actual y acceder a las puntuaciones de las tareas de ese estudiante.
- Utilizar una declaración `foreach` dentro del bucle externo para iterar a través de la matriz de puntuaciones de las tareas y sumar los valores.
- Utilizar un algoritmo dentro del bucle externo para calcular la puntuación promedio del examen de cada estudiante.
- Utilizar una construcción `if-elseif-else` dentro del bucle externo para evaluar la puntuación promedio del examen y asignar una calificación en letras automáticamente.
- Integrar las puntuaciones de créditos adicionales al calcular la puntuación final y la calificación en letras del estudiante de la siguiente manera:
    - Detecta tareas de créditos adicionales según la cantidad de elementos en la matriz de puntuaciones del estudiante.
    - Divide los valores de las tareas de créditos adicionales por 10 antes de agregar las puntuaciones de crédito adicional a la suma de las puntuaciones de los exámenes.
- Utilizar el siguiente formato de informe para reportar las calificaciones de los estudiantes: 

    Estudiante         Puntuación del examen    Calificación final   Créditos adicionales

    Sophia             92.2                    95.88                A        92 (3.68 pts)

*/

int tareasExamen = 5;

string[] nombresEstudiantes = new string[] { "Sophia", "Andrew", "Emma", "Logan" };

int[] puntuacionesSophia = new int[] { 90, 86, 87, 98, 100, 94, 90 };
int[] puntuacionesAndrew = new int[] { 92, 89, 81, 96, 90, 89 };
int[] puntuacionesEmma = new int[] { 90, 85, 87, 98, 68, 89, 89, 89 };
int[] puntuacionesLogan = new int[] { 90, 95, 87, 88, 96, 96 };

int[] puntuacionesEstudiantes = new int[10];

string calificacionLetraEstudianteActual = "";

// Mostrar la fila de encabezado para las puntuaciones/calificaciones
Console.Clear();
Console.WriteLine("Estudiante\t\tPuntuación del Examen\tCalificación Final\tCréditos Adicionales\n");

/*
El bucle externo foreach se usa para:
- Iterar a través de los nombres de los estudiantes
- Asignar las calificaciones de un estudiante a la matriz puntuacionesEstudiantes
- Calcular las sumas de las puntuaciones de los exámenes y los créditos adicionales (bucle foreach interno)
- Calcular la calificación numérica y en letras
- Escribir la información del informe de calificaciones
*/
foreach (string nombre in nombresEstudiantes)
{
    string estudianteActual = nombre;

    if (estudianteActual == "Sophia")
        puntuacionesEstudiantes = puntuacionesSophia;

    else if (estudianteActual == "Andrew")
        puntuacionesEstudiantes = puntuacionesAndrew;

    else if (estudianteActual == "Emma")
        puntuacionesEstudiantes = puntuacionesEmma;

    else if (estudianteActual == "Logan")
        puntuacionesEstudiantes = puntuacionesLogan;

    int tareasCalificadas = 0;
    int tareasCreditoAdicionalCalificadas = 0;

    int sumaPuntuacionesExamen = 0;
    int sumaPuntuacionesCreditoAdicional = 0;

    decimal calificacionEstudianteActual = 0;
    decimal puntuacionExamenEstudianteActual = 0;
    decimal puntuacionCreditoAdicionalEstudianteActual = 0;

    /* 
    El bucle foreach interno:
    - Suma las puntuaciones de los exámenes y los créditos adicionales
    - Cuenta las tareas de créditos adicionales
    */
    foreach (int puntuacion in puntuacionesEstudiantes)
    {
        tareasCalificadas += 1;

        if (tareasCalificadas <= tareasExamen)
        {
            sumaPuntuacionesExamen = sumaPuntuacionesExamen + puntuacion;
        }

        else
        {
            tareasCreditoAdicionalCalificadas += 1;
            sumaPuntuacionesCreditoAdicional += puntuacion;
        }
    }

    puntuacionExamenEstudianteActual = (decimal)(sumaPuntuacionesExamen) / tareasExamen;
    puntuacionCreditoAdicionalEstudianteActual = (decimal)(sumaPuntuacionesCreditoAdicional) / tareasCreditoAdicionalCalificadas;

    calificacionEstudianteActual = (decimal)((decimal)sumaPuntuacionesExamen + ((decimal)sumaPuntuacionesCreditoAdicional / 10)) / tareasExamen;

    if (calificacionEstudianteActual >= 97)
        calificacionLetraEstudianteActual = "A+";

    else if (calificacionEstudianteActual >= 93)
        calificacionLetraEstudianteActual = "A";

    else if (calificacionEstudianteActual >= 90)
        calificacionLetraEstudianteActual = "A-";

    else if (calificacionEstudianteActual >= 87)
        calificacionLetraEstudianteActual = "B+";

    else if (calificacionEstudianteActual >= 83)
        calificacionLetraEstudianteActual = "B";

    else if (calificacionEstudianteActual >= 80)
        calificacionLetraEstudianteActual = "B-";

    else if (calificacionEstudianteActual >= 77)
        calificacionLetraEstudianteActual = "C+";

    else if (calificacionEstudianteActual >= 73)
        calificacionLetraEstudianteActual = "C";

    else if (calificacionEstudianteActual >= 70)
        calificacionLetraEstudianteActual = "C-";

    else if (calificacionEstudianteActual >= 67)
        calificacionLetraEstudianteActual = "D+";

    else if (calificacionEstudianteActual >= 63)
        calificacionLetraEstudianteActual = "D";

    else if (calificacionEstudianteActual >= 60)
        calificacionLetraEstudianteActual = "D-";

    else
        calificacionLetraEstudianteActual = "F";


    // Estudiante         Puntuación del Examen      Calificación Final   Créditos Adicionales
    // Sophia             92.2                    95.88                A        92 (3.68 pts)

    Console.WriteLine($"{estudianteActual}\t\t{puntuacionExamenEstudianteActual}\t\t{calificacionEstudianteActual}\t{calificacionLetraEstudianteActual}\t{puntuacionCreditoAdicionalEstudianteActual} ({(((decimal)sumaPuntuacionesCreditoAdicional / 10) / tareasExamen)} pts)");
}

// Requerido para ejecutar en VS Code (mantiene la ventana de salida abierta para ver los resultados)
Console.WriteLine("\n\rPresiona la tecla Enter para continuar");
Console.ReadLine();
