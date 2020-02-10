 using System;
using System.Collections.Generic;
using static System.Console;

public class Character{
   public string name;
   public int lives = 3;
   public int location;
   public Inventory inv;
   public bool isAlive;

    public Character(string name, int lives, int location, Inventory inv)
   {
      this.name = name;
      this.lives = lives;
      this.location = location;
      this.inv = inv;
   }

   public virtual void TakeItem(Item item){
      inv.AddItem(item);
   }

   public virtual void DropItem(Item item){
      inv.RemoveItem(item);
   }
 }