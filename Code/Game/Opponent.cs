using System;
using System.Collections.Generic;
using static System.Console;

class Opponent : Character
{
    public string description; 
    public bool befriend;
    List<String> interactions;
    public bool isAlive = true;

    public Opponent(string name, int lives, int location, Inventory inv, string description, bool befriend, List<String> interactions) : base(name, lives, location, inv)
    {
        this.name = name;          
        this.lives = lives;
        this.location = location;
        this.inv = inv;
        this.befriend = befriend;
        this.interactions = interactions;
        this.description = description;
    }

    public override void DropItem(Item item){
        inv.RemoveItem(item);
    }

    public override Character Attack(Character player){
        double damageMax;
        double damageMin;

        WriteLine("You are being attacked by " + this.name + "...");

        Random r = new Random();

        if(this.lives >= 3){
            damageMax = 0.6f;
            damageMin = 0.4f;

            double damage = r.NextDouble() * (damageMin - damageMax) + damageMin;
            player.lives -= (int)(lives * damage);
        }
        if(this.lives == 2){
            damageMax = 0.4f;
            damageMin = 0.2f;

            double damage = r.NextDouble() * (damageMin - damageMax) + damageMin;
            player.lives -= (int)(lives * damage);
        }
        if(this.lives == 1){
            damageMax = 0.2f;
            damageMin = 0.0f;

            double damage = r.NextDouble() * (damageMin - damageMax) + damageMin;
            player.lives -= (int)(lives * damage);
        }
        if(player.lives == 0){
            player.isAlive = false;
        }
        WriteLine("Lives left: " + player.lives);
        return player;
    }


    public override void Interact(){
        WriteLine(interactions[0]);
        interactions.Remove(interactions[0]);
    }
}