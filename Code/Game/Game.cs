using System;
using System.Collections.Generic;
using static System.Console;

class Game
{
    public List<Room> rooms;
    public Player player;
    public String instructions;
    public Menu menu = new Menu();
    public Room currentRoom;
    Opponent thisOpponent;
    Item thisItem;
    Door thisDoor;
    String wrongCommand = "Unknown command, please try Again!";
    bool win = false;
    

    public Game(List<Room> rooms, Player player, String instructions)
    {
        this.rooms = rooms;
        this.player = player;
        this.instructions = instructions;
    }

    public void StartGame(){
        Console.Clear();
        WriteLine(this.instructions);
        WriteLine("Type 'start' to play the game!");
        Write(">");

        string userInput = Console.ReadLine().ToLower();

        if(String.Equals(userInput, "start")){
            WriteLine("Loading...");
            currentRoom = this.rooms[0];
            System.Threading.Thread.Sleep(5000);
            PlayGame();
        }
        else{
            WriteLine("Error! Input incorrect, please try again.");
            StartGame();
        }
    }

    public void PlayGame(){
        Console.Clear();
        
        currentRoom.Display();
        WriteLine("\n");
        Write("Make a move! >");
        string userInput = Console.ReadLine().ToLower();
        string[] input = userInput.Split(" ", 2);
        List<Opponent> opponents = currentRoom.opponents;

        switch(input[0]){
            case "m": 
                menu.Display(); 
                break;
            case "c": 
                player.ShowCommands(); 
                break;
            case "l":
                currentRoom.Display(); 
                break;
            case "i": 
                player.inv.Display(); 
                break;
            
            case "take": 
                PickItem(input[1]);
                break;
            case "drop": 
                LeaveItem(input[1]); 
                break;

            case "f":
                Fight(input[1]);
                break;

            case "w":  
            case "a": 
            case "s": 
            case "d": 
                Move(input[0]);
                break;
            default: 
                WriteLine(wrongCommand);
                break;
        }
    }
    public void PickItem(String input){
        int amount = currentRoom.itemsInRoom.Count;

        if(amount > 0){
            for(int i = 0; i < amount; i++){
                thisItem = currentRoom.itemsInRoom[i];

                if(String.Equals(thisItem.name, input)){
                    currentRoom.itemsInRoom.Remove(thisItem);
                    player.TakeItem(thisItem);
                } 
                else{
                    WriteLine(wrongCommand);
                    System.Threading.Thread.Sleep(5000);
                    currentRoom.Display();
                }
            }
        }
        else{
            WriteLine("There are no items to take.");
        }
    }

    public void LeaveItem(String input){
        int amount = player.inv.itemsList.Count;

        for(int i = 0; i < amount; i++){
            thisItem = player.inv.itemsList[i];
            
            if(String.Equals(thisItem.name, input)){

                player.inv.RemoveItem(thisItem);
                currentRoom.itemsInRoom.Add(thisItem);
            }
            else{
                WriteLine(wrongCommand);
                System.Threading.Thread.Sleep(5000);
                currentRoom.Display();
            }
        }  
    }
    public void Fight(String input){
        int amount = currentRoom.opponents.Count;
        if(amount > 0){
            for(int i = 0; i < amount; i ++){
                thisOpponent = currentRoom.opponents[i];
                if(String.Equals(thisOpponent.name, input)){
                    player.Attack(thisOpponent);
                }
                else{
                    WriteLine(wrongCommand);
                }
            }
        }
        else{
            WriteLine("There are no opponents to attack.");
        }
    }

    public void Move(String input){
        for(int i = 0; i < currentRoom.doors.Count; i ++){
            thisDoor = currentRoom.doors[i];
            if(String.Equals(thisDoor.direction, input)){
                currentRoom.Enter(thisDoor, this);
            }
            else{
                WriteLine("You can not go in this direction! Please try again.");
            }
        }
    }
}