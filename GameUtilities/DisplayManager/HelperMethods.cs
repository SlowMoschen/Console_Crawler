using System.Diagnostics;

namespace Console_Crawler.GameUtilities.DisplayManager
{
    internal partial class DisplayManager
    {
        public static void WaitForInput( string message = "Press any key to continue ..." )
        {
            Console.WriteLine();
            Console.WriteLine($" {message}");
            Console.ReadKey();
        }

        public static void WaitForXSeconds( int seconds )
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.Elapsed.Seconds < seconds) { }
            stopwatch.Stop();
        }


        public static void DisplayHeader( string title, string subtitle = "" )
        {
            int width = Math.Max(title.Length, subtitle.Length) + 27; // Calculate the width of the box
            string border = new string('-', width); // Create the border string

            Console.WriteLine(border);
            Console.WriteLine("|" + new string(' ', width - 2) + "|");
            int leftPadding = (width - title.Length) / 2 - 1;
            int rightPadding = leftPadding + ((width - title.Length) % 2 == 0 ? 0 : 1);
            Console.WriteLine("|" + new string(' ', leftPadding) + title + new string(' ', rightPadding) + "|");
            Console.WriteLine("|" + new string(' ', width - 2) + "|");
            if (!string.IsNullOrEmpty(subtitle))
            {
                leftPadding = (width - subtitle.Length) / 2 - 1;
                rightPadding = leftPadding + ((width - subtitle.Length) % 2 == 0 ? 0 : 1);
                Console.WriteLine("|" + new string(' ', leftPadding) + subtitle + new string(' ', rightPadding) + "|");
                Console.WriteLine("|" + new string(' ', width - 2) + "|");
            }
            Console.WriteLine(border);
        }


        public static void DisplaySubHeader( string message )
        {
            Console.WriteLine();
            Console.WriteLine("---------------------------");

            int dashedLineLength = 27;
            int padding = (dashedLineLength - message.Length) / 2;
            Console.WriteLine("{0," + ((dashedLineLength - message.Length) / 2 + message.Length) + "}", message);
            Console.WriteLine("---------------------------");
            Console.WriteLine();
        }

        public static string DisplayOptionsMenu( string message, string[] options, string[] numbers = null)
        {
            Console.WriteLine();
            string playerChoice = InputHandler.GetChoice(message, options, numbers);
            Console.WriteLine();
            return playerChoice;
        }

        public static void DisplayLevelProgressBar( int currentLevel, int currentXP, int xpToNextLevel )
        {
            double progress = (double)currentXP / xpToNextLevel;
            int progressBarLength = 20;
            int progressBars = (int)(progress * progressBarLength);

            Console.Write($" Progress to LVL {currentLevel + 1} [");
            Console.Write(new string('#', progressBars));
            Console.Write(new string('.', progressBarLength - progressBars));
            Console.Write("]\n");
        }

        public static void DisplaySaveSuccess()
        {
            Console.WriteLine();
            Console.WriteLine(" Saving successfull!");
            WaitForInput();
        }

        public static void DisplaySaveFailure()
        {
            Console.WriteLine();
            Console.WriteLine(" Saving failed!");
            WaitForInput();
        }

        public static void DisplayLoadSuccess()
        {
            Console.WriteLine();
            Console.WriteLine(" Loading successfull!");
            WaitForXSeconds(1);
        }
    }
}
