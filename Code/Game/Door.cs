using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using Quiz;

class Door{

    public List<QuizElement> riddles = new List<QuizElement>();
    public bool locked = true;
    public string direction;
    public String leadsTowards;
   

    

    public Door(List<QuizElement> riddles, bool locked, String direction)
    {
        this.riddles = riddles;
        this.locked = locked;
        this.direction = direction; 
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