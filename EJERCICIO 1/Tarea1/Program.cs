using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program
{
    static object lockObj = new object(); // Para sincronización
    static Random rand = new Random(); // Para asignar médicos aleatoriamente

    static void AtenderPaciente(int pacienteId)
    {
        int medicoId;
        lock (lockObj)
        {
            medicoId = rand.Next(1, 5); // Selecciona un médico entre 1 y 4
            Console.WriteLine($"Paciente {pacienteId} ha sido asignado al Médico {medicoId}");
        }
        
        Thread.Sleep(10000); // Simula la consulta médica (10 segundos)
        
        Console.WriteLine($"Paciente {pacienteId} ha terminado la consulta con el Médico {medicoId}");
    }

    static void Main()
    {
        List<Thread> hilosPacientes = new List<Thread>();
        
        for (int i = 1; i <= 4; i++)
        {
            Console.WriteLine($"Paciente {i} ha llegado al hospital");
            Thread pacienteThread = new Thread(() => AtenderPaciente(i));
            pacienteThread.Start();
            hilosPacientes.Add(pacienteThread);
            Thread.Sleep(2000); // Cada paciente llega cada 2 segundos
        }

        // Esperar a que todos los pacientes terminen su consulta
        foreach (var thread in hilosPacientes)
        {
            thread.Join();
        }

        Console.WriteLine("Todos los pacientes han sido atendidos");
    }
}
