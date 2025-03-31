![image](https://github.com/user-attachments/assets/b0aeff57-4f36-4169-a9b5-8a8955acc564)
Se agregó una cola de diagnóstico (colaDiagnostico) para garantizar que los pacientes sean diagnosticados en orden de llegada.

Nuevo método GestionarDiagnostico(), que procesa los pacientes en la cola en el orden correcto.

Se separó la gestión del diagnóstico de la consulta médica, permitiendo que los pacientes esperen su turno sin desorden.

Ahora, los pacientes que requieren diagnóstico esperan en la cola y entran en orden de llegada, sin importar el orden en que terminaron la consulta.


Otra Posible Solución
En lugar de usar una cola de prioridad, podríamos usar un Monitor con una variable de turno para asegurar que los pacientes pasen a diagnóstico en orden de llegada.

Implementación Alternativa
Añadir una variable turnoActual que indique qué paciente debe entrar al diagnóstico.

Usar Monitor.Wait() y Monitor.PulseAll() para gestionar la sincronización:

Un paciente solo entra si su OrdenLlegada coincide con turnoActual.

Cuando termina su diagnóstico, incrementa turnoActual y notifica a los demás.

Eliminar la cola Queue<Paciente>, ya que el orden se manejaría con la variable turnoActual.

Este método garantiza orden sin necesidad de almacenar pacientes en una cola.
