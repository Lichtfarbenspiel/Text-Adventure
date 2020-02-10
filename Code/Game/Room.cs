using System;
using System.Collections.Generic;
using static System.Console;

class Room{

    public string name;
    public string description;
    public int position;
    public List<Door> doors;
    public List<Item> itemsInRoom;
    public List<Opponent> opponents;
    Room nextRoom;
    
    

    public Room(String name, String description, int position, List<Door> doors, List<Item> itemsInRoom, List<Opponent> opponents)
    {
        this.name = name;
        this.description = description;
        this.position = position;
        this.doors = doors;
        this.itemsInRoom = itemsInRoom;
        this.opponents = opponents;
    }

    public void Display(){
        Console.Clear();
        WriteLine(description);
        if(itemsInRoom.Count > 0){
            WriteLine("\n");
            WriteLine("You can see ");
            foreach (Item item in itemsInRoom)
            {
                WriteLine("- a/an " + item.name);
            }
        }
        if(opponents.Count > 0){
            WriteLine("\n");
            WriteLine("There are the following Characters:");
            foreach (Opponent op in opponents)
            {
                WriteLine("- " + op.name.ToUpper() + " " + op.description);
            }
        }
    }
}