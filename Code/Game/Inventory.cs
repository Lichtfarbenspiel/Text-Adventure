using System;
using System.Collections.Generic;

public class Inventory{
    
    List<Item> itemsList;

    public Inventory(List<Item> itemsList)
    {
        this.itemsList = itemsList;
    }

    public void AddItem(Item item){
        itemsList.Add(item);
    }

    public void RemoveItem(Item item){
        itemsList.Remove(item);
    }

    public void Combine(Item[] items){
        
    }
}