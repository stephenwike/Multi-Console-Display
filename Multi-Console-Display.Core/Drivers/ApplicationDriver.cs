using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading;

namespace Project_Console_Driver
{
    public class ApplicationDriver
    {
        private ProcessStartInfo _startInfo;
        private Process _process;
        private string _configJSON;

        public ApplicationDriver(ConsoleDriverConfiguration config)
        {
            //_configJSON = JsonNet.Serialize(config);
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Arrays };
            _configJSON = JsonConvert.SerializeObject(config, Formatting.None, settings);
        }

        public void Initialize()
        {
            _process = new Process();

            _startInfo = new ProcessStartInfo();
            _startInfo.FileName = @"C:\\Examples\poc\Multi-Console-Display\Multi-Console-Display\bin\Debug\Multi-Console-Display.exe";
            _startInfo.Arguments = _configJSON;
            _startInfo.UseShellExecute = false;
            _startInfo.CreateNoWindow = true;

            _process.StartInfo = _startInfo;
            _process.EnableRaisingEvents = true;

            _process.StartInfo.RedirectStandardError = true;
            _process.StartInfo.RedirectStandardOutput = true;
        }

        public void Start()
        {
            var thread = new Thread(new ThreadStart(DisplayFormThread));

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            // thread.Join();
        }

        private void DisplayFormThread()
        {
            try
            {
                _process.Start();

                _process.ErrorDataReceived += HandleError;
                _process.OutputDataReceived += DataReceived;

                _process.Exited += (sender, args) => Exit(sender, args);

                _process.BeginErrorReadLine();
                _process.BeginOutputReadLine();

                _process.WaitForExit();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());

            }
        }

        private void DataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }

        private void HandleError(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }

        private void Exit(object sender, object data)
        {
            Console.WriteLine(data);
            var p = sender as Process;
            if (p != null)
            {
                var exitCode = p.ExitCode;
                var id = p.Id;
            }

            // TODO: Add code to clean up orphaned processes.
        }
    }
}