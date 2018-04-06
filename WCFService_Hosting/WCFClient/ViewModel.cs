using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;
using System.Windows;
using ProcessLibrary;

namespace WCFClient
{
    public class ViewModel : ViewModelBase
    {
        private ChannelFactory<IProcessInformation> _channelFactory;
        private IProcessInformation _channel;
        private string _address;
        private string _input;
        private string _output;
        private readonly Dictionary<int, string> _methods;
        private int _selectedMethod;

        public ViewModel()
        {
            _methods = new Dictionary<int, string>
            {
                {1, "1. Get All Processes()"},
                {2, "2. Get Process Threads(int processId)"},
                {3, "3. GetProcessById(int processId)"},
                {4, "4. Start Process(string pathToFile)"},
                {5, "5. Kill Process(int processId)"},
                {6, "6. Show Modules Info(int processId)"}
            };
        }


        public int SelectedMethod
        {
            get => _selectedMethod;
            set
            {
                if (_selectedMethod == value) return;
                _selectedMethod = value;
            }
        }

        public Dictionary<int, string> Methods => _methods;

        public string Input
        {
            get => _input;
            set
            {
                if (_input == value) return;
                _input = value;
                OnPropertyChanged();
            }
        }
        public string Output
        {
            get => _output;
            set
            {
                if (_output == value) return;
                _output = value;
                OnPropertyChanged();
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                if (_address == value) return;
                _address = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _send;
        public RelayCommand SendCommand
        {
            get
            {
                return _send ??
                       (_send = new RelayCommand
                           (
                           obj =>
                           {
                               Send();
                               Input = String.Empty;
                           },
                           obj => !String.IsNullOrWhiteSpace(Input)));
            }
        }

        private void Send()
        {
            try
            {
                if (_channelFactory == null)
                    _channelFactory = new ChannelFactory<IProcessInformation>(new BasicHttpBinding(), new EndpointAddress(Address));
                _channel = _channelFactory.CreateChannel();

                switch (SelectedMethod)
                {
                    case 1:
                        Output = _channel.GetAllProcesses();
                        break;
                    case 2:
                        Output = "Enter process id: ";
                        Output = _channel.GetProcessThreads(Convert.ToInt32(Input));
                        break;

                    case 3:
                        Output = "Enter process id: ";
                        Output = _channel.GetProcessById(Convert.ToInt32(Input));
                        break;
                    case 4:
                        Output = _channel.StartProcess(Input);
                        break;
                    case 5:
                        Output = "Enter process id: ";
                        Output = _channel.KillProcess(Convert.ToInt32(Input));
                        break;
                    case 6:
                        Output = "Enter process id: ";
                        Output = _channel.ShowModulesInfo(Convert.ToInt32(Input));
                        break;
                    case 0:
                        Process.GetCurrentProcess().Kill();
                        break;
                    default: return;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}
