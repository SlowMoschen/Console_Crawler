using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Crawler.GameUtilities
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
                if(choices.Contains(input))
                {
                    return input;
                }
            }

            Console.WriteLine(" Input is invalid");
            return GetChoice(message, choices, numbers);
        }
    }
}
