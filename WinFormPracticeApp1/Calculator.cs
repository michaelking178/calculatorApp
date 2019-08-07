using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormPracticeApp1
{
    class Calculator
    {
        public enum Operator { MULTIPLY, DIVIDE, ADD, SUBTRACT, NONE };

        public class Equation
        {
            public Operator Operator_ { get; set; }
            public float Num1 { get; set; }
            public float Num2 { get; set; }
            public float Solution { get; set; }
            public bool IsRepeatingEqualBtn { get; set; }

            /// <summary>
            /// Calculates the given equation and returns the solution
            /// </summary>
            public float Calculate()
            {
                switch (Operator_)
                {
                    case Operator.DIVIDE:
                        return (Num1 / Num2);
                    case Operator.MULTIPLY:
                        return (Num1 * Num2);
                    case Operator.ADD:
                        return (Num1 + Num2);
                    case Operator.SUBTRACT:
                        return (Num1 - Num2);
                    default:
                        return 0;
                }
            }

            public void Clear()
            {
                Num1 = 0;
                Num2 = 0;
                Solution = 0;
                Operator_ = Operator.NONE;
                IsRepeatingEqualBtn = false;
            }
        }
    }
}
