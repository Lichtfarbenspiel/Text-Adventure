using System;
using System.Collections.Generic;
using static System.Console;

class Room{

    String name;
    String description;
    Door door;
    List<Item> itemsInRoom;
    List<Character> characters;
    List<Char> directions = new List<char>();

    public Room(String name, String description, Door door, List<Item> itemsInRoom, List<Character> characters, List<Char> directions)
    {
        this.name = name;
        this.description = description;
        this.door = door;
        this.itemsInRoom = itemsInRoom;
        this.characters = characters;
        this.directions = directions;
    }

    void Display(){
        WriteLine(description);
    }

    void RemoveItem(Item item){
        itemsInRoom.Remove(item);
    }

    void AddCharacter(Character c){
        characters.Add(c);
    }

    void RemoveCharacter(Character c){
        characters.Remove(c);
    }
    
    void Enter(){

    }

}