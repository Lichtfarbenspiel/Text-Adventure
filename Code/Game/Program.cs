using System;
using System.Collections.Generic;
using static System.Console;

namespace Text_Adventure
{
    class Program
    {
        Game game;
        Player player;
        Menu menu = new Menu();
        Room currentRoom;
        Character thisOpponent;
        Item thisItem;
        Door thisDoor;
        String wrongCommand = "Unknown command, please try Again!";
        
       

        static void Main(string[] args)
        {
            Program p = new Program();
            p.LoadGame();
            p.StartGame(p.game);
        }

        Game LoadGame(){
            JsonConverter jc = new JsonConverter();
            game = jc.DeserialiseJson("json/Game.json");
            return game;
        }

        void StartGame(Game g){
            Console.Clear();
            WriteLine(game.instructions);
            WriteLine("Type 'start' to play the game!");
            Write(">");

            string userInput = Console.ReadLine().ToLower();

            if(String.Equals(userInput, "start")){
                WriteLine("Loading...");
                currentRoom = game.rooms[0];
                player = game.player;
                System.Threading.Thread.Sleep(5000);
                PlayGame();
            }
            else{
                WriteLine("Error! Input incorrect, please try again.");
                StartGame(game);
            }
        }
        
        void PlayGame(){
            Console.Clear();
            
            currentRoom.Display();
            WriteLine("\n");
            Write("Make a move! >");
            string userInput = Console.ReadLine().ToLower();
            string[] input = userInput.Split(" ");
            List<Character> opponents = currentRoom.characters;

            switch(input[0]){
                case "m": 
                    menu.Display(); 
                    break;
                case "c": 
                    game.player.ShowCommands(); 
                    break;
                case "l":
                    currentRoom.Display(); 
                    break;
                case "i": 
                    game.player.inv.Display(); 
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
        void PickItem(String input){
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
            int amount = currentRoom.characters.Count;
            if(amount > 0){
                for(int i = 0; i < amount; i ++){
                    thisOpponent = currentRoom.characters[i];
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

        void Move(String input){
            for(int i = 0; i < currentRoom.doors.Count; i ++){
                thisDoor = currentRoom.doors[i];
                if(String.Equals(thisDoor.direction, input)){
                    currentRoom.Enter(thisDoor, game);
                }
                else{
                    WriteLine("You can not go in this direction! Please try again.");
                }
            }
        }

    }   
}
