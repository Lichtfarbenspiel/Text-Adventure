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
    public bool gameOver = false;
    public bool won = false;
        
    

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
            System.Threading.Thread.Sleep(1000);
            currentRoom.Display();
            PlayGame();
        }
        else{
            WriteLine("Error! Input incorrect, please try again.");
            System.Threading.Thread.Sleep(5000);
            StartGame();
        }
    }

    public void PlayGame(){

        if(!gameOver){

            WriteLine("\n");
            WriteLine("Make a move!");
            Write(">");
            
            string userInput = Console.ReadLine();
            userInput = userInput.ToLower();
            string[] input = userInput.Split(" ");
            List<Opponent> opponents = currentRoom.opponents;
            
            Console.Clear();

            switch(input[0]){
                case "m": 
                    menu.Display(); 
                    break;
                case "c": 
                    this.ShowCommands(); 
                    break;
                case "l":
                    currentRoom.Display(); 
                    break;
                case "i": 
                    player.DisplayInventory(); 
                    break;
                case "take":
                case "t": 
                    this.PickItem(input[1]);
                    break;
                case "drop": 
                    this.LeaveItem(input[1]); 
                    break;
                case "f":
                    this.Fight(input[1]);
                    break;
                case "w":  
                case "a": 
                case "s": 
                case "d": 
                    this.ChangeRoom(input[0]);
                    break;
            }
            this.PlayGame();
        }
        else{
            WriteLine("Game Over!");
        }
    }
    void PickItem(String input){
    
        if(currentRoom.itemsInRoom.Count == 0){
            WriteLine("There are no items to take.");
            currentRoom.Display();
        }
        else{
            for(int i = 0; i < currentRoom.itemsInRoom.Count; i++){
            
                if(currentRoom.itemsInRoom[i].name != input){
                    WriteLine(wrongCommand);
                    System.Threading.Thread.Sleep(2000);
                    currentRoom.Display();
                } 
                else{
                    thisItem = currentRoom.itemsInRoom[i];
                    player.TakeItem(thisItem);
                    currentRoom.itemsInRoom.Remove(thisItem);
                }
            }
        }
    }

    void LeaveItem(String input){
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
    void Fight(String input){
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

    void ChangeRoom(String input){
        bool pass = false;

        foreach(Door d in currentRoom.doors){
            if(input == d.direction && d.locked){
                thisDoor = d;
                pass = thisDoor.Riddle();
            }
            else if(input == d.direction && !d.locked){
                thisDoor = d;
                pass = true;
            }
        }
        if(pass){
            foreach(Room r in rooms){
                if(thisDoor.leadsTowards == r.name){
                    currentRoom = r;
                }
            }
            currentRoom.Display();
        }
    }

    void ShowCommands(){
        WriteLine("commands (c): show Commands \n move forward(w), move backward (s), move left (a), move right (d)\n look (l)\n show inventory (i)\n take (t item) <item>\n drop (d item) <item>\n attack (a name) <character>.\n save (save) game\n quit (q)");
    }
}