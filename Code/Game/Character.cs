 using System;
using System.Collections.Generic;

public class Character{
   string name;
   int lives = 3;
   static List<Item> items;
   Inventory inv = new Inventory(items);


    public virtual string Attack(){
       return "attack!";
    }

    public virtual void TakeItem(Item item){
       inv.AddItem(item);
    }

    public virtual void DropItem(Item item){
       inv.RemoveItem(item);
    }

    public virtual void Interact(){}


 }