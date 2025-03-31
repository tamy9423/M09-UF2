using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class Paciente
{
    public int Id { get; set; }
    public int LlegadaHospital { get; set; }
    public int TiempoConsulta { get; set; }
    public string Estado { get; set; }

    public Paciente(int id, int llegadaHospital, int tiempoConsulta)
    {
        Id = id;
        LlegadaHospital = llegadaHospital;
        TiempoConsulta = tiempoConsulta;
        Estado = "Espera";
    }
}

class Program
{
    static object lockObj = new object(); // Para sincronización
    static Random rand = new Random(); // Para asignar médicos aleatoriamente

    static void AtenderPaciente(Paciente paciente)
    {
        int medicoId;
        lock (lockObj)
        {
            medicoId = rand.Next(1, 5); // Selecciona un médico entre 1 y 4
            paciente.Estado = "Consulta";
            Console.WriteLine($"Paciente {paciente.Id} (Llegada: {paciente.LlegadaHospital}s, Consulta: {paciente.TiempoConsulta}s) ha sido asignado al Médico {medicoId}");
        }
        
        Thread.Sleep(paciente.TiempoConsulta * 1000); // Simula la consulta médica según el tiempo del paciente
        
        paciente.Estado = "Finalizado";
        Console.WriteLine($"Paciente {paciente.Id} ha terminado la consulta con el Médico {medicoId}");
    }

    static void Main()
    {
        List<Thread> hilosPacientes = new List<Thread>();
        List<Paciente> pacientes = new List<Paciente>();

        for (int i = 1; i <= 4; i++)
        {
            int id = rand.Next(1, 101);
            int tiempoConsulta = rand.Next(5, 16);
            int llegadaHospital = (i - 1) * 2; // Pacientes llegan cada 2 segundos
            
            Paciente paciente = new Paciente(id, llegadaHospital, tiempoConsulta);
            pacientes.Add(paciente);
            
            Console.WriteLine($"Paciente {paciente.Id} ha llegado al hospital (Tiempo de llegada: {paciente.LlegadaHospital}s)");
            Thread pacienteThread = new Thread(() => AtenderPaciente(paciente));
            pacienteThread.Start();
            hilosPacientes.Add(pacienteThread);
            
            Thread.Sleep(2000); // Simula la llegada de pacientes cada 2 segundos
        }

        // Esperar a que todos los pacientes terminen su consulta
        foreach (var thread in hilosPacientes)
        {
            thread.Join();
        }

        Console.WriteLine("Todos los pacientes han sido atendidos");
    }
}
