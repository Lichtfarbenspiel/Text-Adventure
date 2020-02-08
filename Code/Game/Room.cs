using System;
using System.Collections.Generic;
using static System.Console;

class Room{

    string name;
    List<Item> itemsInRoom;
    List<Character> characters;
    String description;
    Door door;
    List<Char> directions = new List<char>();

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