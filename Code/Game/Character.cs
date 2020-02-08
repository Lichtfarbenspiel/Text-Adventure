 using System;
using System.Collections.Generic;
using static System.Console;

public class Character{
   string name;
   int lives = 3;
   Inventory inv;
   
   
   public Character(string name, int lives, Inventory inv)
   {
      this.name = name;
      this.lives = lives;
      this.inv = inv;
   }

   public virtual void Attack(){
      WriteLine("Attack!");
   }

   public virtual void TakeItem(Item item){
      inv.AddItem(item);
   }

   public virtual void DropItem(Item item){
      inv.RemoveItem(item);
   }

   public virtual void Interact(){
      WriteLine("Hello!");
   }


 }