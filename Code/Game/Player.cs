using System;
using System.Collections.Generic;
using static System.Console;

class Player : Character{
    string name;
    int lives;
    Inventory inv;
    Dictionary<string, char> commands = new Dictionary<string, char>();

    public Player(string name, int lives, Inventory inv, Dictionary<string, char> commands) : base(name, lives, inv)
    {
        this.name = name;
        this.lives = lives;
        this.inv = inv;
        this.commands = commands;
    }

    public override void Attack(){
        Write("How would you like to Attack? >");
        string attack = Console.ReadLine();
        
    }
     
    public override void Interact(){

    }

    public void ShowCommands(){
        WriteLine(commands.ToString());
    }
}