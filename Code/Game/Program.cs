using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using static System.Console;

namespace Text_Adventure
{
    class Program
    {
        static Game game;
        
       
        static void Main(string[] args)
        {
            Program p = new Program();
            game = LoadGame();
            game.StartGame();
                
        }

        static Game LoadGame(){
            string filePath = "";
            string input;
            bool inLoop = true;
            while(inLoop)
            {
                WriteLine("Would you like to play a new game or load a saved game? \nEnter 'new' to play a new game \nEnter 'load' to load a previously saved game");
                Write(">");
                input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "new":
                        filePath = "bin/debug/netcoreapp3.1/Game.json";
                        inLoop = false;
                        break;
                    case "load":
                        filePath = "bin/debug/netcoreapp3.1/save.json";
                        inLoop = false;
                        break;
                    case "quit":
                        inLoop = false;
                        Environment.Exit(0);
                        break ;
                    default:
                        WriteLine("Wrong input, please try again!");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }

            string json = File.ReadAllText(filePath);
            Game game = JsonConvert.DeserializeObject<Game>(json);
            return game;            
        }
    }
}