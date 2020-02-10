using System;
using System.Collections.Generic;
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
            case "2":
                g.PlayGame();
            break;
            case "0":
                Environment.Exit(0);
            break;                 
        }
    }
}