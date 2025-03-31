![image](https://github.com/user-attachments/assets/6b566493-2bef-4da1-b540-61c85993be46)
![image](https://github.com/user-attachments/assets/52e0cc81-178c-4c02-a681-c6e9a0495cc4)


Explicación del enfoque del código.
Esta iniciativa replica digitalmente la atención al paciente en una instalación con cuatro médicos y dos aparatos de análisis. Se ha diseñado utilizando hilos y semáforos para gestionar la concurrencia.

Llegada de pacientes.

Se producen veinte individuos, cada uno con un intervalo de citas aleatorio (entre 5-15 unidades de tiempo) y potencialmente requieren un diagnóstico.

Bir-anual, de manera continua, es esencial monitorear la secuencia en la que los pacientes llegan al centro médico para garantizar su disposición cronológica.

Consulta médica.

Se emplea una sala de cinco médicos para manejar la cantidad de pacientes atendidos simultáneamente es un ejemplo de excesiva.

Cada paciente espera con derecho a su oportunidad y se requiere que vea a un médico aleatorio o aleatorio.

Después de la consulta, si necesita un diagnóstico, ingrese una cola. Si no, termina.

Diagnóstico.

Está orquestado por una luminancia de dos aparatos para permitir como máximo dos exámenes concomitantes concomitantes de artículos.

Los pacientes ingresan al diagnóstico por orden de llegada a la cola de diagnóstico.

Después de 15 años de diagnóstico, el paciente termina.

¿Los pacientes que deberían esperar acuden a consulta en orden de llegada?
Los pacientes se someten a la secuencia de la cola en el punto de nombramiento cuando se puede acceder a un médico.

Pruebas realizadas.
Ejecute el código dado varias veces y verifique cada vez en la consola que los mensajes aparecen en la secuencia esperada.

Acelere las entradas simuladas (sustituyendo el hilo. Sleep (2000) con Thread.sleep (500)) para evaluar si el retraso funciona con precisión.

Para garantizar un seguimiento adecuado y mantener la integridad de los registros de llegada de nuestro paciente, incluya las acciones de registro requeridas al principio y al final de cada consulta programada, más de cada cita, es esencial registrar el evento, verificando que haya habido pacientes entrantes antes de esa consulta en la línea de tiempo. Para garantizar la precisión de la consulta, agregue la confirmación

Los resultados demuestran que los pacientes generalmente son atendidos de acuerdo con la urgencia de sus afecciones. Sin embargo, pueden ocurrir retrasos inevitables en escenarios en los que hay una escasez de personal médico de servicio.
Otra posibilidad de solución.
En lugar de manejar los tiempos de espera para citas y evaluaciones con señales y líneas, un sistema de clasificación podría organizar a los pacientes.

Alternativa: Uso de BloquingCollection .
En lugar de una línea sin complicaciones, una colección bloqueada de pacientes  garantiza el tratamiento que se adhiere a la llegada y la urgencia, eliminando las interrupciones de hilos innecesarios.

Ventajas.

Evite la ocupación innecesaria de la CPU al no necesitar una espera activa (hilo. Sleep).

Mayor control sobre el orden de atención sin depender de bloqueos manuales.
