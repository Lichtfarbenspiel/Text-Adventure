using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

class Player : Character{

    public bool isAlive = true;
    public int level;
    

    public Player(string name, int lives, int level, int location, Inventory inv) : base(name, lives, location, inv)
    {
        this.name = name;
        this.lives = lives;
        this.level = level;
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
            WriteLine("- " + item.name);
        }
        WriteLine("\n");
        WriteLine("Your Health: " + lives + " health points");
        WriteLine("Your Level: " + level);
    }

    public Opponent Attack(Opponent opponent){
        double damageMax;
        double damageMin;

        WriteLine("Attacking " + opponent.name + "...");

        Random r = new Random();
        
            if(this.level >= 3){
                damageMax = 0.6f;
                damageMin = 0.4f;
                
                double damage = r.NextDouble() * (damageMax - damageMin) + damageMin;
                opponent.lives -= (int)(opponent.lives * damage);
            }
            else if(this.level == 2){
                damageMax = 0.4f;
                damageMin = 0.2f;

                double damage = r.NextDouble() * (damageMax - damageMin) + damageMin;
                opponent.lives -= (int)(opponent.lives * damage);
            }
            else if(this.level == 1){
                damageMax = 0.2f;
                damageMin = 0.0f;

                double damage = r.NextDouble() * (damageMax - damageMin) + damageMin;
                opponent.lives -= (int)(opponent.lives * damage);
            }
            if(opponent.lives <= 0){
                opponent.isAlive = false;
                WriteLine("You killed " + opponent.name);
            }
            WriteLine("Opponent's lives left: " + opponent.lives);
            if(this.lives > 0){
                opponent.Attack(this);
            } 

        return opponent;
    }

    public void Interact(Opponent opponent){
        WriteLine("What would you like to say to " + opponent.name.ToUpper() + "? ");
        Write(">");
        string input = Console.ReadLine();
        opponent.Interact(this);
    }

    public String UseItem(String input){
        string output = "";
        foreach(Item item in this.inv.itemsList){
            if(input == item.name){
                if(item.name == "potion"){
                    this.lives += item.power;
                    output = "You have now " + this.lives + " Health Points.";
                }
                switch(item.usage){
                    case "fire":
                        output = "'A fire has been lit'";
                        this.inv.RemoveItem(item);
                        return output;
                    case "strength":
                        this.level += item.power;
                        output = "Your Level is now " + this.level;
                        this.inv.RemoveItem(item);
                        return output;
                    case "weakness":
                        this.level -= item.power;
                        output = "Your Level is now " + this.level;
                        this.inv.RemoveItem(item);
                        return output;
                }
            }
        }
        return output;
    }
}