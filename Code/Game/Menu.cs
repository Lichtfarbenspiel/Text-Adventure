using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using static System.Console;

class Menu{

    public void Display(Game g){
        WriteLine(">>Menu<<");
        WriteLine("Enter '1' to save the game");
        WriteLine("Enter '2' to resume");
        WriteLine("Enter '0' to quit the game");

        Write(">");

        string userInput = Console.ReadLine();
        switch(userInput){
            case "1":
                Save(g);
                break;
            case "2":
                g.PlayGame();
            break;
            case "0":
                Environment.Exit(0);
            break;                 
        }
    }

    public void Save(Game game){
        WriteLine("Saving...");
        
        string jsonString = JsonConvert.SerializeObject(game, Formatting.Indented);
        File.WriteAllText("bin/debug/netcoreapp3.1/save.json", jsonString);
        System.Threading.Thread.Sleep(2000);       
    }
}