using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ProcessLibrary
{
    [ServiceContract]
    public interface IProcessInformation
    {
        [OperationContract]
        string GetAllProcesses();

        [OperationContract]
        string GetProcessThreads(int processId);

        [OperationContract]
        string GetProcessById(int processId);

        [OperationContract]
        string StartProcess(string path);

        [OperationContract]
        string KillProcess(int processId);

        [OperationContract]
        string ShowModulesInfo(int processId);
    }

}
