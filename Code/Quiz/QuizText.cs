using System;
using static System.Console;
using System.Collections.Generic;

namespace Quiz
{
    class QuizText : QuizElement
    {

        public Answer answer;
        new string instructions = "Please enter the correct word below. Mind the correct spelling.";

        public QuizText(string question, Answer answer) : base(question)
        {
            this.answer = answer;
        }

        public override void Display()
        {
            WriteLine(instructions);
            WriteLine(question);
        }

        public override bool CheckAnswer(string userInput)
        {
           if(userInput == answer.text && answer.isTrue)
                return true;
           else if(userInput != answer.text && !answer.isTrue) 
                return false;
           else
                WriteLine(MsgWrongInput);
            return false;

        }
    }
}