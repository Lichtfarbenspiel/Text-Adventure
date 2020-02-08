using System;
using System.Collections.Generic;

class Opponent : Character
{
    string name;
    int lives = 3;
    bool befriend;
    static List<Item> items;
    Inventory inv = new Inventory(items);

    public override String Attack(){
        return "attack!";
    }

    public override void DropItem(Item item){}

    public override void Interact(){}
}