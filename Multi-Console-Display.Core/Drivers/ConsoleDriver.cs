using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Project_Console_Driver
{
    public class ConsoleDriver
    {
        private ProcessStartInfo _startInfo;
        private Process _process;
        private ConsoleInputWriter _consoleInputWriter;

        public ConsoleDriver(ConsoleConfiguration config)
        {
            _process = new Process();

            _startInfo = new ProcessStartInfo();
            _startInfo.FileName = config.FileName;
            _startInfo.Arguments = config.Args;
            _startInfo.UseShellExecute = false;
            _startInfo.CreateNoWindow = true;
        }

        public void OutputData(DataReceivedEventHandler handler)
        {
            _startInfo.RedirectStandardOutput = true;
            _startInfo.RedirectStandardError = true;
            _process.OutputDataReceived += handler;
            _process.ErrorDataReceived += handler;
        }

        public async Task RunAsync()
        {
            await Task.Run(() =>
            {
                try
                {
                    _process.StartInfo = _startInfo;

                _process.EnableRaisingEvents = true;
                _process.Start();

                _process.Exited += (sender, args) => Exit(sender, args);

                if (_startInfo.RedirectStandardInput)
                {
                    _consoleInputWriter.SetStream(_process.StandardInput);
                }

                _process.BeginOutputReadLine();
               
                    _process.WaitForExit();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            });
        }

        public ConsoleInputWriter InputData()
        {
            _startInfo.RedirectStandardInput = true;
            return _consoleInputWriter = new ConsoleInputWriter();
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

            if (_consoleInputWriter != null)
            {
                _consoleInputWriter.Dispose();
            }
        }

        private void DisplayError(string data)
        {
            Console.WriteLine(data);
        }
    }
}