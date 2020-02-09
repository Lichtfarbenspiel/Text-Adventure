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
        static string FilePath = "json/Game.json";
        
       

        static void Main(string[] args)
        {
            Program p = new Program();

            game = LoadGame();
            WriteLine("check");
            game.StartGame();
        }

        static Game LoadGame(){

            using (StreamReader r = new StreamReader(FilePath))
            {
                string json = r.ReadToEnd();
                WriteLine(json);
                game = JsonConvert.DeserializeObject<Game>(json);
            }
            // string jsonString = File.ReadAllText(FilePath);
            // WriteLine(jsonString);
            // Game g = JsonConvert.DeserializeObject<Game>(jsonString);
            return game;
        }

        public static void Save(Game game){
            // string jsonString = JsonConvert.SerializeObject(game, Formatting.Indented, FilePath);
            // File.WriteAllText("Ressources\save.json", jsonString);
        }

        void Resume(){
            // game.currentRoom.Display();
        }

        void Quit(){
            Environment.Exit(0);
        }
    }
}

