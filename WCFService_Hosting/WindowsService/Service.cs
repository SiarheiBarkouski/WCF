using System.ServiceModel;
using System.ServiceProcess;
using ProcessLibrary;

namespace WindowsService
{
    public partial class Service : ServiceBase
    {
        private ServiceHost _service;

        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (_service == null)
            {
                _service = new ServiceHost(typeof(ProcessInformation));
                _service.Open();
            }
        }

        protected override void OnStop()
        {
            if (_service != null)
            {
                _service.Close();
            }
        }
    }
}

