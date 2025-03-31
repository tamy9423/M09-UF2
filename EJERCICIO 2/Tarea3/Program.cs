using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class Paciente
{
    public int Id { get; set; }
    public int LlegadaHospital { get; set; }
    public int TiempoConsulta { get; set; }
    public bool RequiereDiagnostico { get; set; }
    public string Estado { get; set; }
    public int OrdenLlegada { get; set; }

    public Paciente(int id, int llegadaHospital, int tiempoConsulta, int ordenLlegada, bool requiereDiagnostico)
    {
        Id = id;
        LlegadaHospital = llegadaHospital;
        TiempoConsulta = tiempoConsulta;
        RequiereDiagnostico = requiereDiagnostico;
        Estado = "EsperaConsulta";
        OrdenLlegada = ordenLlegada;
    }
}

class Program
{
    static object lockObj = new object(); // Para sincronización
    static SemaphoreSlim maquinasDiagnostico = new SemaphoreSlim(2); // Máquinas de diagnóstico
    static SemaphoreSlim medicosDisponibles = new SemaphoreSlim(4); // 4 médicos disponibles
    static Random rand = new Random(); // Para asignar médicos aleatoriamente
    static Queue<Paciente> colaDiagnostico = new Queue<Paciente>(); // Cola para diagnóstico ordenado

    static void AtenderPaciente(Paciente paciente)
    {
        medicosDisponibles.Wait(); // Esperar hasta que haya un médico disponible
        int medicoId;
        lock (lockObj)
        {
            medicoId = rand.Next(1, 5); // Selecciona un médico entre 1 y 4
            paciente.Estado = "Consulta";
            Console.WriteLine($"Paciente {paciente.Id}. Llegado el {paciente.OrdenLlegada}. Estado: {paciente.Estado}. Duración Espera: {paciente.LlegadaHospital} segundos.");
        }
        
        Thread.Sleep(paciente.TiempoConsulta * 1000); // Simula la consulta médica según el tiempo del paciente
        medicosDisponibles.Release(); // Liberar médico
        
        if (paciente.RequiereDiagnostico)
        {
            lock (lockObj)
            {
                paciente.Estado = "EsperaDiagnostico";
                Console.WriteLine($"Paciente {paciente.Id}. Llegado el {paciente.OrdenLlegada}. Estado: {paciente.Estado}. Esperando diagnóstico.");
                colaDiagnostico.Enqueue(paciente); // Agregar a la cola en orden de llegada
            }
        }
        else
        {
            paciente.Estado = "Finalizado";
            Console.WriteLine($"Paciente {paciente.Id}. Llegado el {paciente.OrdenLlegada}. Estado: {paciente.Estado}. Finalizado.");
        }
    }

    static void GestionarDiagnostico()
    {
        while (true)
        {
            Paciente paciente;
            lock (lockObj)
            {
                if (colaDiagnostico.Count == 0)
                    break; // Si la cola está vacía, terminamos
                paciente = colaDiagnostico.Dequeue();
            }

            maquinasDiagnostico.Wait(); // Espera hasta que una máquina esté disponible
            paciente.Estado = "Diagnostico";
            Console.WriteLine($"Paciente {paciente.Id}. Llegado el {paciente.OrdenLlegada}. Estado: {paciente.Estado}. Realizando diagnóstico (15s).");
            Thread.Sleep(15000); // Simula diagnóstico
            maquinasDiagnostico.Release();
            
            paciente.Estado = "Finalizado";
            Console.WriteLine($"Paciente {paciente.Id}. Llegado el {paciente.OrdenLlegada}. Estado: {paciente.Estado}. Finalizado.");
        }
    }

    static void Main()
    {
        List<Thread> hilosPacientes = new List<Thread>();
        List<Paciente> pacientes = new List<Paciente>();

        for (int i = 1; i <= 20; i++)
        {
            int id = rand.Next(1, 101);
            int tiempoConsulta = rand.Next(5, 16);
            bool requiereDiagnostico = rand.Next(0, 2) == 1;
            int llegadaHospital = (i - 1) * 2; // Pacientes llegan cada 2 segundos
            
            Paciente paciente = new Paciente(id, llegadaHospital, tiempoConsulta, i, requiereDiagnostico);
            pacientes.Add(paciente);
            
            Console.WriteLine($"Paciente {paciente.Id}. Llegado el {paciente.OrdenLlegada}. Estado: EsperaConsulta. Duración: 0 segundos.");
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

        // Procesar diagnóstico en orden de llegada
        GestionarDiagnostico();

        Console.WriteLine("Todos los pacientes han sido atendidos y diagnosticados si era necesario");
    }
}
