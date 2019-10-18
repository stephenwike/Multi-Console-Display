using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Project_Console_Driver
{
    public class ConsoleDriver
    {
        private ProcessStartInfo _startInfo;
        private Process _process;
        private ConsoleInputWriter _consoleInputWriter;

        public ConsoleDriver(ConsoleDriverConfiguration config)
        {
            _process = new Process();

            _startInfo = new ProcessStartInfo();
            _startInfo.FileName = config.Exe;
            _startInfo.Arguments = config.Args;
            _startInfo.UseShellExecute = false;
            _startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            _startInfo.RedirectStandardError = true;
        }

        public void OutputData(DataReceivedEventHandler handler)
        {
            _startInfo.RedirectStandardOutput = true;
            _process.OutputDataReceived += handler;
        }

        public async Task RunAsync()
        {
            await Task.Run(() =>
            {
                _process.StartInfo = _startInfo;

                _process.EnableRaisingEvents = true;
                _process.Start();

                // process.OutputDataReceived += (sender, args) => Display(args.Data);
                _process.ErrorDataReceived += (sender, args) => DisplayError(args.Data);
                _process.Exited += (sender, args) => Exit(args);
                // process.Exited

                if (_startInfo.RedirectStandardInput)
                {
                    _consoleInputWriter.SetStream(_process.StandardInput);
                }
                
                // StreamReader sr = process.StandardOutput;
                // StreamReader se = process.StandardError;


                // string output = process.StandardOutput.ReadToEnd();
                _process.BeginOutputReadLine();
                // process.WaitForExit();

                // sw.WriteLine("echo Fuck off");
                // Console.WriteLine(output);

                // process.Close();
                // sw.Close();

                // Console.WriteLine("\n\nPress any key to exit.");
                // Console.ReadLine();

                // _process.WaitForExit();
            });
        }

        public ConsoleInputWriter InputData()
        {
            _startInfo.RedirectStandardInput = true;
            return _consoleInputWriter = new ConsoleInputWriter();
        }

        private void Exit(object data)
        {
            Console.WriteLine(data);
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