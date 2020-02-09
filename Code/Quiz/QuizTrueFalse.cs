using System;
using static System.Console;

namespace Quiz
{
    class QuizTrueFalse : QuizElement
    {
        bool isTrue;
        new string instructions = "Please enter 'T' if you believe the statement to be correct. Enter 'F' if you believe it is false.";

        public QuizTrueFalse(string question, bool isTrue) : base(question)
        {
            this.isTrue = isTrue;
        }

        public override void Display()
        {
            WriteLine(instructions);
            WriteLine(question);
        }

        public override bool CheckAnswer(string userInput)
        {
            if (userInput == "T" || userInput == "t" && isTrue)
                return true;
            else if (userInput == "F" || userInput == "f" && !isTrue)
                return false;
            else 
                WriteLine(MsgWrongInput);
            return false;
        }
    }
}