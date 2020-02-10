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
        static List<Room> rooms;
        static Player player;
        static string PathRooms = "json/Rooms.json";
        static string PathPlayer = "json/Player.json";
        static string instructions = "Welcome to the 'Adventure of Lonewood Castle'!";
        
       
        static void Main(string[] args)
        {
            Program p = new Program();
            game = LoadGame();
            game.StartGame();
                
        }

        static Game LoadGame(){
            string filePath = ""; 
            WriteLine("Would you like to play a new game or load a saved game? \nEnter 'new' to play a new game \nEnter 'load' to load a previously saved game");
            Write(">");
            string input = Console.ReadLine().ToLower();
            switch(input){
                case "new":
                    filePath = "json/Game.json";
                    break;
                case "load":
                    filePath = "json/Saves/save.json";
                    break;
                case "quit":
                    Environment.Exit(0);
                    break;
                default: 
                    WriteLine("Wrong input, please try again!");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    LoadGame();
                    break;
            }

            string json = File.ReadAllText(filePath);
            Game game = JsonConvert.DeserializeObject<Game>(json);
            return game;            
        }
    }
}