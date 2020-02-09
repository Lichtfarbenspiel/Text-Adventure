using System;

namespace Quiz{
    class Answer
    {
        public string text;
        public bool isTrue;

        public Answer(string text, bool isTrue)
        {
            this.text = text;
            this.isTrue = isTrue;
        }
    }
}