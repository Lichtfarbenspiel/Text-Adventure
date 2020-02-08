using System;
using System.Collections.Generic;
using static System.Console;

class Opponent : Character
{
    string name;
    int lives = 3;
    Inventory inv;
    bool befriend;
    List<String> attacks;
    List<String> interactions;

    public Opponent(string name, int lives, Inventory inv, bool befriend, List<String> interactions, List<String> attacks) : base(name, lives, inv)
    {
        this.name = name;
        this.lives = lives;
        this.inv = inv;
        this.befriend = befriend;
        this.interactions = interactions;
        this.attacks = attacks;
    }

    public override void Attack(){
        Random rnd = new Random();
      
        int r = rnd.Next(attacks.Count);

        if(lives > 0){
            WriteLine(attacks[r]);
        }
    }


    public override void Interact(){
        WriteLine(interactions[0]);
        interactions.Remove(interactions[0]);
    }
}