using System;
using System.Collections.Generic;

class Inventory{
    
    List<Item> itemsList;

    void AddItem(Item item){
        itemsList.Add(item);
    }

    void RemoveItem(Item item){
        itemsList.Remove(item);
    }

    void Combine(Item[] items){
        
    }
}