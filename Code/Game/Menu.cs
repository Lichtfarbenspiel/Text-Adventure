using System;
using System.Collections.Generic;
using static System.Console;

class Menu{

    List<String> instruction = new List<string>();

    void Display(){
        foreach(String s in instruction){
            WriteLine(s);
        }
    }

}