using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

class Player : Character{
    Dictionary<string, char> commands = new Dictionary<string, char>();

    public Player(string name, int lives, int location, Inventory inv, Dictionary<string, char> commands) : base(name, lives, location, inv)
    {
        this.name = name;
        this.lives = lives;
        this.location = location;
        this.inv = inv; 
        this.commands = commands;  
    }
    public override void TakeItem(Item item){
        inv.AddItem(item);

    }
    public override Character Attack(Character opponent){
        double damageMax;
        double damageMin;

        Random r = new Random();

        if(this.lives >= 3){
            damageMax = 0.6f;
            damageMin = 0.4f;

            double damage = r.NextDouble() * (damageMin - damageMax) + damageMin;
            opponent.lives -= (int)(lives * damage);
        }
        if(this.lives == 2){
            damageMax = 0.4f;
            damageMin = 0.2f;

            double damage = r.NextDouble() * (damageMin - damageMax) + damageMin;
            opponent.lives -= (int)(lives * damage);
        }
        if(this.lives == 1){
            damageMax = 0.2f;
            damageMin = 0.0f;

            double damage = r.NextDouble() * (damageMin - damageMax) + damageMin;
            opponent.lives -= (int)(lives * damage);
        }
        return opponent;
    }
     
    public override void Interact(){

    }

    public void ShowCommands(){
        StringBuilder sb = new StringBuilder();
        bool isFirst = true;

        foreach(var x in commands){
            if(isFirst){
                sb.Append($"{x.Key} ({x.Value})");
            }
            else
                sb.Append($", {x.Key} ({x.Value})");
        }

        WriteLine(sb.ToString());
    }

}