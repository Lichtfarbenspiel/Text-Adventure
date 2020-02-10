using System;
using static System.Console;
using System.Collections.Generic;

namespace Quiz{
    class QuizElement
    {

        string instructions = "Please enter your choice below";
        public string question;
        protected string MsgWrongInput = "Sorry, something went wrong! The input might have been wrong.";
       

        public QuizElement(string question)
        {
            this.question = question;        
        }

        public virtual void Display()
        {
            WriteLine(instructions);
            WriteLine(question);
        }

        public virtual bool CheckAnswer(string userInput)
        {
            return true;
        }
    }
}
