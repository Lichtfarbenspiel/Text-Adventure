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
        static string instructions = "how to play";
        
       
        static void Main(string[] args)
        {
            Program p = new Program();

            LoadGame();
                
        }

        static void LoadGame(){

           using (StreamReader r = new StreamReader(PathRooms))
            {
                string json = r.ReadToEnd();
                rooms = JsonConvert.DeserializeObject<List<Room>>(json);
            }

            using (StreamReader r = new StreamReader(PathPlayer))
            {
                string json = r.ReadToEnd();
                player = JsonConvert.DeserializeObject<Player>(json);
            }
            WriteLine(player);
            game = new Game(rooms, player, instructions);
            game.StartGame();
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