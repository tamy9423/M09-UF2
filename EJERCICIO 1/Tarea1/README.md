Respuestas:
¿Cuántos hilos se están ejecutando en este programa?
Respuesta:
Se ejecutan 5 hilos en total:

1 hilo principal que ejecuta Main().

4 hilos adicionales creados para atender a cada paciente. Cada uno de estos hilos ejecuta el método AtenderPaciente().

¿Cuál de los pacientes entra primero en consulta?
Respuesta:
No hay un orden fijo, ya que los pacientes se asignan a los médicos de forma aleatoria.
Sin embargo, el primer paciente (Paciente 1) llega antes que los demás y tiene la primera oportunidad de obtener un médico libre.

¿Cuál de los pacientes sale primero de consulta?
Respuesta:
El paciente que saldrá primero de la consulta dependerá de qué médico le haya atendido y de la asignación aleatoria de médicos.
Como todos los pacientes tardan exactamente 10 segundos en consulta, el primer paciente en obtener un médico libre será el primero en salir.
Dado que los pacientes llegan cada 2 segundos, el primer paciente en ser atendido suele salir antes que los demás, pero esto depende de cómo se asignen los médicos.
