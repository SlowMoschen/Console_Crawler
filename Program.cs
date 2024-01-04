using System;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {

        // Initialize a new CMD instance
        ProcessStartInfo cmdStartInfo = new ProcessStartInfo();
        cmdStartInfo.FileName = "cmd.exe";
        cmdStartInfo.Arguments = "/c dotnet run";
        cmdStartInfo.CreateNoWindow = true;
        cmdStartInfo.UseShellExecute = true;
        Process cmdProcess = new Process();
        cmdProcess.StartInfo = cmdStartInfo;
        cmdProcess.Start();
        cmdProcess.WaitForExit();

        //Hello World
        Console.WriteLine("Hello World!");
        Console.ReadLine();

    }
}