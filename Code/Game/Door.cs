using System;
using System.Collections.Generic;
using System.Linq;
using Softwaredesign.Quiz;
using static System.Console;


class Door{

    public List<QuizElement> riddles = new List<QuizElement>();
    public bool locked = true;
    public Room leadsTowards;
    

    public Door(List<QuizElement> riddles, bool locked, Room leadsTowards)
    {
        this.riddles = riddles;
        this.locked = locked;
        this.leadsTowards = leadsTowards; 
    }
    public bool Riddle(){
        Random rnd = new Random();
        int number  = rnd.Next(0, riddles.Count);
        
        QuizElement thisRiddle = riddles.ElementAt(number);
        thisRiddle.Display();
        Write(">");
        string userInput = ReadLine();

        bool check = thisRiddle.CheckAnswer(userInput);
        if(!check){
            riddles.Remove(riddles.ElementAt(number));
            return false;
        }
        else{
            riddles.Remove(riddles.ElementAt(number));
            return true;
        }
        
    }
}