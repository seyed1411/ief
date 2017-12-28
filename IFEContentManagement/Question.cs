using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IFEContentManagement
{
    public class Question
    {
        public string type;
        public string[] answers;
        public string title;

        public Question() { }
        public Question(string _type, string[] _answers, string _title)
        {
            this.type = _type;
            this.title = _title;
            this.answers = _answers;
        }
    }
}
