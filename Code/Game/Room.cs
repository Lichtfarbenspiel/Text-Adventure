using System;
using System.Collections.Generic;
using static System.Console;

class Room{

    public string name;
    string description;
    int position;
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
        WriteLine(description);
        if(itemsInRoom.Count > 0){
            WriteLine("\n");
            WriteLine("You can see ");
            foreach (Item item in itemsInRoom)
            {
                WriteLine(item.name);
            }
        }
        if(opponents.Count > 0){
            WriteLine("There are the following Characters:");
            WriteLine("\n");
            foreach (Opponent op in opponents)
            {
                WriteLine(op.name + " " + op.description);
                WriteLine("\n");
            }
        }
    }

    public void Enter(Door d, Game game){
        
        bool riddleSolved = false;

        for(int i = 0; i < game.rooms.Count; i++){
            if(game.rooms[i].name == d.leadsTowards){
                nextRoom = game.rooms[i];
            }
            else{
                nextRoom = null;
                WriteLine("Unknown command, please try Again!");
                break;
            }
        }

        if(!d.locked){
            nextRoom.Display();
        }
        else{
            riddleSolved = d.Riddle();
            if(!riddleSolved){
                WriteLine("You shall not pass until you solve the riddle!");
                this.Display();
            }
            else{
                nextRoom.Display();
            }
        }
    }
}