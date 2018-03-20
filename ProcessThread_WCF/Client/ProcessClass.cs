using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Infrastructure;

namespace Client
{
    class ProcessClass
    {
        private readonly IProcessInformation _info;
        public ProcessClass(IProcessInformation info)
        {
            _info = info;
        }
        public void GetAllProcesses()
        {
            var processes = _info.GetAllProcesses();
            Console.Clear();
            foreach (var proc in processes)
            {
                Console.WriteLine($"{proc.Id} {proc.ProcessName} {proc.StartTime}");
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void GetProcessThreads(Process proc)
        {
            var threads = _info.GetProcessThreads(proc);

            Console.Clear();
            foreach (System.Diagnostics.ProcessThread thread in threads)
            {
                Console.WriteLine($"{thread.Id} {thread.PriorityLevel} {thread.StartTime}");
            }

            Console.ReadKey();
            Console.Clear();
        }

        public Process GetProcessById(int processId)
        {
            var proc = _info.GetProcessById(processId);
            Console.WriteLine($"{proc.Id} {proc.ProcessName} {proc.StartTime}");
            return proc;
        }
        public void StartProcess(string path)
        {
            var proc = _info.StartProcess(path);
            Console.WriteLine($"Process {proc.ProcessName} was started.");
        }
        public void KillProcess(Process proc)
        {
            _info.KillProcess(proc);
            Console.WriteLine($"Process {proc.ProcessName} was killed.");
        }

        public void ShowModulesInfo(Process proc)
        {
            var modules = _info.ShowModulesInfo(proc);
            Console.Clear();
            foreach (ProcessModule module in modules)
            {
                Console.WriteLine($"{module.ModuleName} {module.FileVersionInfo}");
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
