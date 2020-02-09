using System;
using System.Collections.Generic;
using static System.Console;

class Room{

    public string name;
    string description;
    int position;
    public List<Door> doors;
    public List<Item> itemsInRoom;
    public List<Character> characters;
    Room nextRoom;
    
    

    public Room(String name, String description, int position, List<Door> doors, List<Item> itemsInRoom, List<Character> characters)
    {
        this.name = name;
        this.description = description;
        this.position = position;
        this.doors = doors;
        this.itemsInRoom = itemsInRoom;
        this.characters = characters;
    }

    public void Display(){
        WriteLine(description);
        if(itemsInRoom.Count > 0){
            WriteLine("You can see ");
            foreach (Item item in itemsInRoom)
            {
                WriteLine(item.name);
            }
        }
        if(characters.Count > 0){
            WriteLine("There are ");
            foreach (Opponent op in characters)
            {
                WriteLine(op.name + op.description);
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