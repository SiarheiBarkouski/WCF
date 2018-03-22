using System;
using System.Diagnostics;
using System.Text;
using Infrastructure;

namespace Server
{
    class ProcessInformation : IProcessInformation
    {
        public string GetAllProcesses()
        {
            var str = new StringBuilder();
            var processes = Process.GetProcesses();
            foreach (var proc in processes)
            {
                try
                {
                    str.AppendLine($"{proc.ProcessName} {proc.Id} {proc.StartTime}");
                }
                catch
                {
                }
            }
            return str.ToString();
        }

        public string GetProcessThreads(int processId)
        {
            var str = new StringBuilder();
            var proc = Process.GetProcessById(processId);
            var threads = proc.Threads;
            foreach (ProcessThread thread in threads)
            {
                str.AppendLine($"{thread.Id} {thread.PriorityLevel} {thread.StartTime}");
            }
            return str.ToString();
        }

        public string GetProcessById(int processId)
        {
            var str = new StringBuilder();
            var proc = Process.GetProcessById(processId);
            str.AppendLine($"{proc.Id} {proc.ProcessName} {proc.StartTime}");
            return str.ToString();
        }
        public string StartProcess(string path)
        {
            var str = new StringBuilder();
            var proc = Process.Start(path);
            str.AppendLine($"Process {proc?.ProcessName} was started.");
            return str.ToString();
        }
        public string KillProcess(int processId)
        {
            var str = new StringBuilder();
            var proc = Process.GetProcessById(processId);
            proc.Kill();
            str.AppendLine($"Process {proc.ProcessName} was killed.");
            return str.ToString();
        }

        public string ShowModulesInfo(int processId)
        {
            var str = new StringBuilder();
            try
            {
                var proc = Process.GetProcessById(processId);
                var modules = proc.Modules;
                foreach (ProcessModule module in modules)
                {
                    str.AppendLine($"{module.ModuleName} {module.FileVersionInfo}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return $"Failed to get modules: {e.Message}";
            }
            return str.ToString();
        }
    }
}
