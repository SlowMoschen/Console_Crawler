﻿namespace Console_Crawler.GameUtilities
{
    internal class InputHandler
    {
        public static string GetChoice(string message, string[] choices, string[]? numbers = null)
        {
            Console.WriteLine();
            Console.WriteLine(" " + message);

            for(int i = 0; i < choices.Length; i++)
            {
                int choiceNumber = i + 1;
                if(numbers != null)
                {
                    if(numbers[i] != "")
                    {
                        Console.WriteLine(" " + choiceNumber + ". " + choices[i] + " - " + numbers[i]);
                    }
                    else
                    {
                        Console.WriteLine(" " + choiceNumber + ". " + choices[i]);
                    }
                }
                else
                {
                    Console.WriteLine(" " + choiceNumber + ". " + choices[i]);
                }
            }

            Console.WriteLine();

            string? input = Console.ReadLine();

            while(input == null || input == "")
            {
                input = Console.ReadLine();
            }

            if(int.TryParse(input, out int choice))
            {
                if(choice >= 1 && choice <= choices.Length)
                {
                    return choices[choice - 1];
                }
            }
            else
            {
                if(choices.Select(choice => choice.ToLower()).Contains(input))
                {
                    return UpperCaseEveryFirstLetter(input);
                }
            }

            Console.WriteLine(" Input is invalid");
            return GetChoice(message, choices, numbers);
        }

        private static string UpperCaseEveryFirstLetter(string input)
        {
            string[] words = input.Split(' ');
            string output = "";

            foreach(string word in words)
            {
                output += word.First().ToString().ToUpper() + word.Substring(1) + " ";
            }

            return output.Trim();
        }
    }
}
