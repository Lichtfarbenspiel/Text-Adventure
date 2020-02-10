using System;
using System.Collections.Generic;
using static System.Console;

class Opponent : Character
{
    public string description; 
    public bool isFriendly = true;
    //public List<String> interactions;
    public bool isAlive = true;

    public Opponent(string name, int lives, int location, string description, bool isFriendly, Inventory inv) : base(name, lives, location, inv)
    {
        this.name = name;          
        this.lives = lives;
        this.location = location;
        this.description = description;
        this.isFriendly = isFriendly;
        this.inv = inv;
    }

    public override void DropItem(Item item){
        inv.RemoveItem(item);
    }

    public Player Attack(Player player){
        double damageMax;
        double damageMin;

        WriteLine("You are being attacked by " + this.name + "...");

        Random r = new Random();

        if(this.lives >= 3){
            damageMax = 0.6f;
            damageMin = 0.4f;

            double damage = r.NextDouble() * (damageMin - damageMax) + damageMin;
            player.lives -= (int)(player.lives * damage);
        }
        if(this.lives == 2){
            damageMax = 0.4f;
            damageMin = 0.2f;

            double damage = r.NextDouble() * (damageMin - damageMax) + damageMin;
            player.lives -= (int)(player.lives * damage);
        }
        if(this.lives == 1){
            damageMax = 0.2f;
            damageMin = 0.0f;
            
            double damage = r.NextDouble() * (damageMin - damageMax) + damageMin;
            player.lives -= (int)(player.lives * damage);
        }
        if(player.lives == 0){
            player.isAlive = false;
        }
        WriteLine("Lives left: " + player.lives);
        return player;
    }


    public override void Interact(Character player){
        if(this.isFriendly){
            if(inv.itemsList.Count <= 0){
                WriteLine("I am sorry my friend, i don't have anything to give.");
            }
            else{
                for(int i = 0; i < inv.itemsList.Count; i ++){
                    Item item = inv.itemsList[i];
                    this.DropItem(item);
                    WriteLine("My friend, please take this " + item.name);
                    player.TakeItem(item);
                }
            }
        }
        else{
            WriteLine("You are no friend of mine!");
            this.Attack(player);
        }
    }
}