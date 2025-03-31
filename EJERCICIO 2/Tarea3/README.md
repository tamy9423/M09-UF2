![image](https://github.com/user-attachments/assets/6b566493-2bef-4da1-b540-61c85993be46)
![image](https://github.com/user-attachments/assets/52e0cc81-178c-4c02-a681-c6e9a0495cc4)


Explicación del planteamiento del código
Este programa simula la gestión de pacientes en un hospital con 4 médicos y 2 máquinas de diagnóstico. Se ha diseñado usando hilos y semáforos para gestionar la concurrencia.

Llegada de pacientes:

Se generan 20 pacientes, cada uno con un tiempo de consulta aleatorio (5-15s) y un posible requisito de diagnóstico.

Llegan al hospital cada 2 segundos, asegurando que se respeta el orden de llegada.

Consulta médica:

Se usa un semáforo de 4 médicos para controlar la cantidad de pacientes atendidos simultáneamente.

Cada paciente espera su turno y es asignado a un médico aleatorio disponible.

Tras la consulta, si necesita diagnóstico, entra en una cola; si no, finaliza.

Diagnóstico:

Se gestiona mediante un semáforo de 2 máquinas para permitir máximo 2 pruebas simultáneas.

Los pacientes entran a diagnóstico por orden de llegada a la cola de diagnóstico.

Tras 15s de diagnóstico, el paciente finaliza.
