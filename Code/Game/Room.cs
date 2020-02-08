using System;
using System.Collections.Generic;
using static System.Console;

class Room{

    public string name;
    string description;
    int position;
    List<Door> doors;
    public List<Item> itemsInRoom;
    List<Character> characters;
    List<Char> directions = new List<char>();

    public Room(String name, String description, int position, List<Door> doors, List<Item> itemsInRoom, List<Character> characters, List<Char> directions)
    {
        this.name = name;
        this.description = description;
        this.position = position;
        this.doors = doors;
        this.itemsInRoom = itemsInRoom;
        this.characters = characters;
        this.directions = directions;
    }

    void Display(){
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

    // void RemoveItem(Item item){
    //     Player.inv.AddItem(item);
    //     itemsInRoom.Remove(item);
    // }

    // void AddCharacter(Character c){
    //     characters.Add(c);
    // }

    // void RemoveCharacter(Character c){
    //     characters.Remove(c);
    // }
    
    void Enter(Door d){
        Room nextRoom;
        bool riddleSolved = false;

        if(!d.locked){
            nextRoom = d.leadsTowards;
            nextRoom.Display();
        }
        else{
            riddleSolved = d.Riddle();
            if(!riddleSolved){
                WriteLine("You shall not pass until you solve the riddle!");
                this.Display();
            }
            else{
                nextRoom = d.leadsTowards;
                nextRoom.Display();
            }
        }
    }
}