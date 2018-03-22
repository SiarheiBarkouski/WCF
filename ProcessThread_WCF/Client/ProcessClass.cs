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
            ConsoleAction(_info.GetAllProcesses());
        }

        public void GetProcessThreads(int processId)
        {
            ConsoleAction(_info.GetProcessThreads(processId));
        }

        public void GetProcessById(int processId)
        {
            ConsoleAction(_info.GetProcessById(processId));
        }
        public void StartProcess(string path)
        {
            ConsoleAction(_info.StartProcess(path));
        }
        public void KillProcess(int processId)
        {
            ConsoleAction(_info.KillProcess(processId));
        }

        public void ShowModulesInfo(int processId)
        {
            ConsoleAction(_info.ShowModulesInfo(processId));
        }

        private void ConsoleAction(string input)
        {
            Console.Clear();
            Console.WriteLine(input);
            Console.ReadKey();
            Console.Clear();
        }

    }
}
