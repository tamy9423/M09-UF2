![image](https://github.com/user-attachments/assets/61625609-d0ba-4d15-bf9d-f51048be47a1)
![image](https://github.com/user-attachments/assets/d2ba4152-769b-42d3-9887-1d53113d230d)
![image](https://github.com/user-attachments/assets/c8fa2d68-59c1-42a1-9539-e3ebcd120142)

Explicación del código y decisiones tomadas.
Este código modela la asistencia de 20 pacientes en una clínica con consultas médicas y evaluaciones. Logic se organiza en tres partes principales.

Llegada y registro del paciente.

Cada individuo se produce con un número arbitrario, duración arbitraria de la cita (5-15 segundos) y posible enfermedad.

Los pacientes están registrados en la lista e inicializan en espera.

Los hilos comienzan a procesar consultas médicas.

Consulta médica.

Se emplea una señal de cuatro sustitutos médicos (sustitutos médicos) para controlar la entrada al examen.

Los pacientes esperan su turno y son asignados a un médico aleatorio.

Después de la discusión, si el paciente requiere un examen, proceda a la vía de diagnóstico, si no, concluye.

Diagnóstico.

Se utiliza un aparato de diagnóstico de dos herramientas para evaluar los exámenes médicos.

Los pacientes en la cola de diagnóstico son tratados en orden de llegada.

Después de 15 segundos de diagnóstico, el paciente termina su proceso.
