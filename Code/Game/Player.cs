using System;
using System.Collections.Generic;
using static System.Console;

class Player : Character{
    string name;
    int lives;
    static List<Item> items;
    Inventory inv = new Inventory(items);

    Dictionary<string, char> commands = new Dictionary<string, char>();


    public override String Attack(){
        return "attack!";
    }
     
    public override void Interact(){

    }

    public void ShowCommands(){
        WriteLine(commands.ToString());
    }
}