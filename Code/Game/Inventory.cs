using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

public class Inventory{
    
    public List<Item> itemsList;

    public Inventory(List<Item> itemsList)
    {
        this.itemsList = itemsList;
    }

    public void Display(){
        StringBuilder sb = new StringBuilder();
        bool isFirst = true;

        foreach (Item item in itemsList)
        {
            if(isFirst){
                sb.Append(item.name);
            }
            else
                sb.Append(", " + item.name);
        }
        WriteLine(sb.ToString());
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