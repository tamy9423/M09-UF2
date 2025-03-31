![image](https://github.com/user-attachments/assets/b0aeff57-4f36-4169-a9b5-8a8955acc564)
Se agregó una cola de diagnóstico (colaDiagnostico) para garantizar que los pacientes sean diagnosticados en orden de llegada.

Nuevo método GestionarDiagnostico(), que procesa los pacientes en la cola en el orden correcto.

Se separó la gestión del diagnóstico de la consulta médica, permitiendo que los pacientes esperen su turno sin desorden.

Ahora, los pacientes que requieren diagnóstico esperan en la cola y entran en orden de llegada, sin importar el orden en que terminaron la consulta.
