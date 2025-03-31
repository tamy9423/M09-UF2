![image](https://github.com/user-attachments/assets/805aa233-9b73-4076-9735-e67349802904)
¿Los pacientes que deben esperar para hacerse las pruebas de diagnóstico entran luego a hacerse las pruebas por orden de llegada?
El SemaphoreSlim garantiza que solo dos pacientes pueden usar las máquinas a la vez, pero el orden de acceso depende de la programación de los hilos. 
Para verificarlo, se pueden ejecutar varias pruebas observando los tiempos de llegada y diagnóstico.
