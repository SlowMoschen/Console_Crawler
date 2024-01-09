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

        public static void DisplayHeader( string message )
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

            Console.Write($"Progress to LVL {currentLevel + 1} [");
            Console.Write(new string('#', progressBars));
            Console.Write(new string('.', progressBarLength - progressBars));
            Console.Write("]\n");
        }
    }
}
