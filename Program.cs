using System;
using System.Collections.Generic;

namespace EXAM_4
{
    class Program
    {
        static void Main()
        {
            List<Crocodile> crocodiles = new List<Crocodile>();

            do
            {
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Feed");
                Console.WriteLine("2. Play");
                Console.WriteLine("3. Heal");
                Console.WriteLine("4. View all pets");
                Console.WriteLine("5. Add a new pet");
                Console.WriteLine("6. End the game");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Incorrect choice.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                    case 2:
                    case 3:
                        Console.WriteLine("Choose a crocodile (1 or 2):");
                        foreach (var crocodile in crocodiles)
                        {
                            crocodile.DisplayInfo();
                        }

                        int crocodileIndex;
                        if (!int.TryParse(Console.ReadLine(), out crocodileIndex) || crocodileIndex < 1 ||
                            crocodileIndex > crocodiles.Count)
                        {
                            Console.WriteLine("Incorrect crocodile choice.");
                            continue;
                        }

                        crocodiles[crocodileIndex - 1].ApplyAction((ActionType)choice);
                        break;

                    case 4:
                        Console.WriteLine("Information about all pets:");
                        foreach (var crocodile in crocodiles)
                        {
                            crocodile.DisplayInfo();
                        }
                        break;

                    case 5:
                        if (crocodiles.Count < 2)
                        {
                            Console.WriteLine("Enter the name and age of the crocodile separated by a space:");
                            string[] input = Console.ReadLine()?.Split(' ');

                            if (input != null && input.Length == 2)
                            {
                                string name = input[0];
                                if (!int.TryParse(input[1], out int age))
                                {
                                    Console.WriteLine("Incorrect age format.");
                                    continue;
                                }

                                crocodiles.Add(new Crocodile(name, age));
                                Console.WriteLine("New pet added!");
                            }
                            else
                            {
                                Console.WriteLine("Incorrect input.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Maximum number of pets reached.");
                        }
                        break;

                    case 6:
                        return;

                    default:
                        Console.WriteLine("Incorrect choice.");
                        break;
                }

                // Displaying information about pets after the action
                Console.WriteLine("Information about pets after performing the action:");
                foreach (var crocodile in crocodiles)
                {
                    crocodile.DisplayInfo();
                }

            } while (true);
        }
    }
}
