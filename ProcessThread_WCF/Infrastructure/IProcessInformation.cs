using System.Diagnostics;
using System.ServiceModel;

namespace Infrastructure
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
