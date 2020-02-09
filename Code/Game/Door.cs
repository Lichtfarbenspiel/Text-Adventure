using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using Quiz;

class Door{

    public List<QuizText> riddles = new List<QuizText>();
    public bool locked = true;
    public string direction;
    public String leadsTowards;
   

    

    public Door(List<QuizText> riddles, bool locked, String direction, String leadsTowards)
    {
        this.riddles = riddles;
        this.locked = locked;
        this.direction = direction;
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