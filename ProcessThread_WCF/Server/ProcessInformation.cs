using System;
using System.Diagnostics;
using Infrastructure;

namespace Server
{
    class ProcessInformation : IProcessInformation
    {
        public Process[] GetAllProcesses()
        {
            var processes = Process.GetProcesses();
            return processes;
        }

        public ProcessThreadCollection GetProcessThreads(Process proc)
        {
            var threads = proc.Threads;

            Console.Clear();
            foreach (ProcessThread thread in threads)
            {
                Console.WriteLine($"{thread.Id} {thread.PriorityLevel} {thread.StartTime}");
            }

            Console.ReadKey();
            Console.Clear();

            return threads;
        }
        
        public Process GetProcessById(int processId)
        {
            var proc = Process.GetProcessById(processId);
            Console.WriteLine($"{proc.Id} {proc.ProcessName} {proc.StartTime}");
            return proc;
        }
        public Process StartProcess(string path)
        {
            var proc = Process.Start(path);
            return proc;
        }
        public void KillProcess(Process proc)
        {
            proc.Kill();
            Console.WriteLine($"Process {proc.ProcessName} was killed.");
        }
        
        public ProcessModuleCollection ShowModulesInfo(Process proc)
        {
            var modules = proc.Modules;
            Console.Clear();
            foreach (ProcessModule module in modules)
            {
                Console.WriteLine($"{module.ModuleName} {module.FileVersionInfo}");
            }
            Console.ReadKey();
            Console.Clear();

            return modules;
        }
    }
}
