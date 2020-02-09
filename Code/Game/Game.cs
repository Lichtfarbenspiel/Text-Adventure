using System;
using System.Collections.Generic;

class Game
{
    public List<Room> rooms;
    public Player player;
    public String instructions;

    public Game(List<Room> rooms, Player player, String instructions)
    {
        this.rooms = rooms;
        this.player = player;
        this.instructions = instructions;
    }
    
}