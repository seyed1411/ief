using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IFEContentManagement
{
    public class QuestionCollection
    {
        public bool rtl;
        public List<Question> questions;

        public QuestionCollection()
        {
            rtl = false;
            this.questions = new List<Question>();
        }
        public QuestionCollection(bool _isRightToLeftLang)
        {
            rtl = _isRightToLeftLang;
            this.questions = new List<Question>();

        }
    }
}
