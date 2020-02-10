using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using static System.Console;
using System.Linq;

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
            Console.Clear();
            currentRoom.Display();
            PlayGame();
        }
        else{
            WriteLine("Error! Input incorrect, please try again.");
            System.Threading.Thread.Sleep(5000);
            Console.Clear();
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
                case "q":
                    Environment.Exit(0);
                    break;
                case "m":
                case "menu": 
                    menu.Display(this); 
                    break;
                case "c": 
                case "commands":
                    this.ShowCommands(); 
                    break;
                case "l":
                case "look":
                    currentRoom.Display(); 
                    break;
                case "i": 
                case "inventory":
                    player.DisplayInventory(); 
                    break;
                case "take":
                case "t": 
                    this.PickItem(input[1]);
                    break;
                case "drop": 
                    this.LeaveItem(input[1]); 
                    break;
                case "use":
                case "u":
                    player.UseItem(input[1]);
                    break;
                case "attack":
                    this.Fight(input[1]);
                    break;
                case "address":
                    this.SpeakTo(input[1]);
                    break;
                case "w":  
                case "a": 
                case "s": 
                case "d": 
                    this.ChangeRoom(input[0]);
                    break;
            }
            this.Winning();
            this.GameOver();
            this.PlayGame();
        }
        else{
            Console.Clear();
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
        if(player.inv.itemsList.Count == 0){
            WriteLine("There are no items in your inventory.");
            currentRoom.Display();
        }
        else{
            for(int i = 0; i < player.inv.itemsList.Count; i++){
            
                if(player.inv.itemsList[i].name != input){
                    WriteLine(wrongCommand);
                    System.Threading.Thread.Sleep(2000);
                    currentRoom.Display();
                } 
                else{
                    thisItem = player.inv.itemsList[i];
                    player.DropItem(thisItem);
                    currentRoom.itemsInRoom.Add(thisItem);
                }
            }
        }  
    }

    void Fight(String input){

        if(currentRoom.opponents.Count == 0){
            WriteLine("There are no opponents to attack.");
        }
        else{
            foreach(Opponent op in currentRoom.opponents){
                if(op.name == input){
                    thisOpponent = op;
                    thisOpponent = player.Attack(thisOpponent);
                }
            }
            if(!thisOpponent.isAlive){
                foreach(Item item in thisOpponent.inv.itemsList){
                    thisItem = item;
                    thisOpponent.inv.RemoveItem(item);
                    currentRoom.itemsInRoom.Add(thisItem);
                }
            }
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
                d.locked = false;
                pass = true;
            }
        }
        if(pass){
            foreach(Room r in rooms){
                if(thisDoor.leadsTowards == r.name){
                    currentRoom = r;
                }
            }
            OpponentChangeRoom();
            currentRoom.Display();
            pass = false;
        }
    }

    void OpponentChangeRoom(){
        Random r = new Random();
        int location = r.Next(0, rooms.Count-1);

        for(int i = 0; i <= this.rooms.Count -1; i++){
            for(int j = 0; j <= this.rooms[i].opponents.Count -1; j++){
                
                var character = this.rooms[i].opponents[j];
                if(character.level >= 2){
                    this.rooms[location].opponents.Add(character);

                    this.rooms[i].opponents.Remove(character);
                    character.location = location;
                }
            }
        }            
    }

    void ShowCommands(){
        WriteLine("commands (c): show Commands \n move forward (w), move backward (s), move left (a), move right (d)\n look (l)\n show inventory (i)\n take (t) <item>\n drop <item>\n use (u) <item>\n attack <character name>\n address <character name>\n save game\n quit (q)");
    }

    void GameOver(){
        if(player.lives <= 0){
            gameOver = true;
        }
    }

    void SpeakTo(String name){
        foreach(Opponent op in currentRoom.opponents){
            if(name == op.name){
                thisOpponent = op;
            }
        }
        player.Interact(thisOpponent);
    }

    void Winning(){
        foreach(Item item in player.inv.itemsList){
            if(item.usage == "win"){
                WriteLine("Congratulations! You found the " + item.name);
                won = true;
            }
        }
        if(won){
            WriteLine("Here are your stats:");
            player.DisplayInventory();
            WriteLine("\n");
        }
    }
}