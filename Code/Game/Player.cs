using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

class Player : Character{

    public bool isAlive = true;

    public Player(string name, int lives, int location, Inventory inv) : base(name, lives, location, inv)
    {
        this.name = name;
        this.lives = lives;
        this.location = location;
        this.inv = inv; 
    }
    public override void TakeItem(Item item){
            inv.AddItem(item); 
            WriteLine(item.name + " has been added to your inventory");
    }
    public override void DropItem(Item item){
        if(inv.itemsList.Count > 0){
            inv.RemoveItem(item);
            WriteLine("you dropped " + item.name);
        }
        else{
            WriteLine("There are no items in your inventory.");
        }
    }

    public void DisplayInventory(){
        WriteLine("Your inventory holds:");
        foreach (Item item in inv.itemsList)
        {
            WriteLine(item.name);
        }
        WriteLine("\n");
        WriteLine("Your Health:" + lives + " health points");
    }

    public Opponent Attack(Opponent opponent){
        double damageMax;
        double damageMin;

        WriteLine("Attacking " + opponent.name + "...");

        Random r = new Random();

        if(opponent.lives == 3){
            damageMax = 0.2f;
            damageMin = 0.0f;
            
            double damage = r.NextDouble() * (damageMin - damageMax) + damageMin;
            opponent.lives -= (int)(lives * damage);
        }
        if(opponent.lives == 2){
            damageMax = 0.4f;
            damageMin = 0.2f;

            double damage = r.NextDouble() * (damageMin - damageMax) + damageMin;
            opponent.lives -= (int)(lives * damage);
        }
        if(opponent.lives == 1){
            damageMax = 0.6f;
            damageMin = 0.4f;

            double damage = r.NextDouble() * (damageMin - damageMax) + damageMin;
            opponent.lives -= (int)(lives * damage);
        }
        if(opponent.lives == 0){
            opponent.isAlive = false;
        }
        WriteLine("Opponent's lives left: " + this.lives);
        return opponent;
    }

    public void Move(string direction){
        
    }
     
    public override void Interact(){

    }


}