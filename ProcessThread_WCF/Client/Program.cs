using System;
using System.Diagnostics;
using System.ServiceModel;
using Infrastructure;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var address = new EndpointAddress(@"http://127.0.0.1:60001/IProcessInformation");
            var binding = new BasicHttpBinding();
            

            var channelFactory = new ChannelFactory<IProcessInformation>(binding, address);
            var channel = channelFactory.CreateChannel();
            
            Menu(new ProcessClass(channel));
        }

        private static void Menu(ProcessClass procClass)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("1. Get all processes.");
                    Console.WriteLine("2. Get process  by PID.");
                    Console.WriteLine("3. Get process threads.");
                    Console.WriteLine("4. Start process.");
                    Console.WriteLine("5. Kill process.");
                    Console.WriteLine("6. Show process modules.");
                    Console.Write("Enter your choice: ");

                    var result = Int32.TryParse(Console.ReadLine(), out var choice);
                    if (result)
                    {
                        switch (choice)
                        {
                            case 1:
                                procClass.GetAllProcesses();
                                break;
                            case 2:
                                Console.Write("Enter process id: ");
                                procClass.GetProcessById(Convert.ToInt32(Console.ReadLine()));
                                break;
                            case 3:
                                Console.Write("Enter process id: ");
                                procClass.GetProcessThreads(Convert.ToInt32(Console.ReadLine()));
                                break;
                            case 4:
                                procClass.StartProcess(Console.ReadLine());
                                break;
                            case 5:
                                Console.Write("Enter process id: ");
                                procClass.KillProcess(Convert.ToInt32(Console.ReadLine()));
                                break;
                            case 6:
                                Console.Write("Enter process id: ");
                                procClass.ShowModulesInfo(Convert.ToInt32(Console.ReadLine()));
                                break;
                            case 0:
                                Process.GetCurrentProcess().Kill();
                                break;
                            default: Console.Clear(); continue;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}

