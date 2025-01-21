using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameParserApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var GameApp = new GameParserApp();
            GameApp.Run();

            Console.ReadKey();
        }

        public class Game
        {
            public string Title { get; set; }
            public string ReleaseYear { get; set; }
            public string Rating { get; set; }
        }
        public class GameParserApp
        {
            public void Run()
            {
                do
                {
                    Console.WriteLine("Please enter the file name");
                    var fileNameInput = Console.ReadLine();




                    try
                    {
                        if (string.IsNullOrWhiteSpace(fileNameInput))
                        {
                            throw new ArgumentNullException(fileNameInput, "file cannot be Null or empty");
                            
                        }

                        if (!File.Exists(fileNameInput))
                        {
                            throw new FileNotFoundException("The specified file does not exist.", fileNameInput);
                        }


                        string fileName = File.ReadAllText(fileNameInput);
                        try
                        {

                            List<Game> gamesList = JsonSerializer.Deserialize<List<Game>>(fileName);

                            if (gamesList == null || gamesList.Count == 0)
                            {
                                Console.WriteLine("no games found in the json file");
                                continue; 
                            }

                            Console.WriteLine($"\n List of games in the json file");
                            foreach (var game in gamesList)
                            {
                                Console.WriteLine($"Title: {game.Title}, Release Year: {game.ReleaseYear}, Rating: {game.Rating}");
                            }
                            break;

                        }
                        catch (JsonException ex)
                        {
                            Console.WriteLine($"Error parsing the JSON file: {ex.Message}");
                            Console.WriteLine("\nContent of the problematic JSON file:");
                            Console.WriteLine(fileName);
                        }
                    }
                    catch (ArgumentNullException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    catch (FileNotFoundException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    }
                }
                while (true);
            }
        }
    }
}
