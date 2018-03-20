using System.Diagnostics;
using System.ServiceModel;

namespace Infrastructure
{
    [ServiceContract]
    public interface IProcessInformation
    {
        [OperationContract(IsOneWay = false)]
        Process[] GetAllProcesses();

        [OperationContract]
        ProcessThreadCollection GetProcessThreads(Process proc);

        [OperationContract]
        Process GetProcessById(int processId);

        [OperationContract]
        Process StartProcess(string path);

        [OperationContract]
        void KillProcess(Process proc);

        [OperationContract]
        ProcessModuleCollection ShowModulesInfo(Process proc);
    }
}
