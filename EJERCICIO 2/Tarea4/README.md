![image](https://github.com/user-attachments/assets/b95ff1f3-9570-44c6-9da5-c2ab3a5e741a)
![image](https://github.com/user-attachments/assets/3aa03049-d848-472f-aa6c-a357586e6bb9)

Explicación del planteamiento del código actual
El código:

Genera pacientes con tiempos de consulta y diagnóstico aleatorios.

Los coloca en una cola de diagnóstico en orden de llegada.

Simula la consulta y el diagnóstico con hilos y semáforos para manejar concurrencia.

Modificación para añadir prioridad
Se agregará un nuevo atributo Prioridad a la clase Paciente.

Se usará una estructura ordenada para gestionar la cola de pacientes por prioridad:

static SortedDictionary<int, Queue<Paciente>> colaPrioridad = new SortedDictionary<int, Queue<Paciente>>();
La consulta se asignará primero a pacientes con prioridad más alta.

Otra posibilidad de solución
Podemos usar una PriorityQueue (si se trabaja con .NET 6 o superior), que maneja de forma nativa el orden de prioridad.

static PriorityQueue<Paciente, int> colaPacientes = new PriorityQueue<Paciente, int>();
En este caso, los pacientes se ordenan automáticamente por prioridad sin necesidad de una SortedDictionary.

¿Por qué esta solución?
Ordena automáticamente los pacientes según prioridad sin bloquear hilos.

Mantiene el orden de llegada para pacientes con la misma prioridad.

Es más eficiente que ordenar listas manualmente.
