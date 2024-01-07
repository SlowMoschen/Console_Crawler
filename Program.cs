using Console_Crawler.GameUtilities;
using System;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        RunDotNetCommand("run");


        //Hello World
        Console.WriteLine("Hello World!");
        int armor = 20;
        Console.WriteLine(DamageCalculator.CalculateDamageReduction(armor));
        Console.ReadLine();
    }

    static void RunDotNetCommand(string command)
    {
        // Initialize a new CMD instance
        ProcessStartInfo cmdStartInfo = new ProcessStartInfo();
        cmdStartInfo.FileName = "cmd.exe";
        cmdStartInfo.Arguments = "/c dotnet " + command;
        cmdStartInfo.CreateNoWindow = true;
        cmdStartInfo.UseShellExecute = true;
        Process cmdProcess = new Process();
        cmdProcess.StartInfo = cmdStartInfo;
        cmdProcess.Start();
        cmdProcess.WaitForExit();
    }
}