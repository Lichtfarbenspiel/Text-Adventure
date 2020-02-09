using System;
using System.Collections.Generic;
using static System.Console;

class Menu{

    List<String> instruction = new List<string>();

    public void Display(){
        foreach(String s in instruction){
            WriteLine(s);
        }
    }

    void Save(Game game){

    }

    void load(Game game){

    }

    void resume(){
        // look aufrufen?
    }

    void quit(){
        Environment.Exit(0);
    }

}