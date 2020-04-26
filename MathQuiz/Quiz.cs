using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathQuiz
{
    class Quiz
    {
        private int arg1;
        private int arg2;
        private string oper;
        private int result;

        public int Result { get { return result; } }

        public Quiz(int arg1, int arg2, string oper)
        {
            this.arg1 = arg1;
            this.arg2 = arg2;
            this.oper = oper;

            switch (oper)
            {
                case "+":
                    result = arg1 + arg2;
                    break;
                case "-":
                    result = arg1 - arg2;
                    break;
                case "*":
                    result = arg1 * arg2;
                    break;
                case "/":
                    result = arg1 / arg2;
                    break;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} =", arg1, oper, arg2);
        }

    }
}
