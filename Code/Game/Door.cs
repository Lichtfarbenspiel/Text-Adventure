using System;
using Softwaredesign.Quiz;

class Door{

    QuizElement riddle;
    bool locked = true;

    public Door(QuizElement riddle, bool locked)
    {
        this.riddle = riddle;
        this.locked = locked;
    }
}