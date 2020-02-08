using System;
using System.Collections.Generic;

class Game
{
    List<Room> rooms;
    Player player;

    public Game(List<Room> rooms, Player player)
    {
        this.rooms = rooms;
        this.player = player;
    }
    
}