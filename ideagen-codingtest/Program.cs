using System;


namespace ideagen_codingtest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program calculator = new Program();

            Console.WriteLine(calculator.Calculate("1 + 1")); // Output: 2
            Console.WriteLine(calculator.Calculate("2 * 2")); // Output: 4
            Console.WriteLine(calculator.Calculate("1 + 2 + 3")); // Output: 6
            Console.WriteLine(calculator.Calculate("6 / 2")); // Output: 3
            Console.WriteLine(calculator.Calculate("11 + 23")); // Output: 34
            Console.WriteLine(calculator.Calculate("11.1 + 23")); // Output: 34.1
            Console.WriteLine(calculator.Calculate("1 + 1 * 3")); // Output: 4
            Console.WriteLine(calculator.Calculate("( 11.5 + 15.4 ) + 10.1")); // Output: 37
            Console.WriteLine(calculator.Calculate("23 - ( 29.3 - 12.5 )")); // Output: 6.2
            Console.WriteLine(calculator.Calculate("( 1 / 2 ) - 1 + 1")); // Output: 0.5
            Console.WriteLine(calculator.Calculate("10 - ( 2 + 3 * ( 7 - 5 ) )")); // Output: 2

        }

        public double Calculate(string sum)
        {
            var tokens = sum.Split(' ');
            var stack = new Stack<double>();
            var opStack = new Stack<string>();

            for (int i = 0; i < tokens.Length; i++)
            {
                var token = tokens[i];

                if (token == "(")
                {
                    opStack.Push(token);
                }
                else if (token == "+" || token == "-" || token == "*" || token == "/")
                {
                    while (opStack.Count > 0 && HasPrecedence(token, opStack.Peek()))
                    {
                        var op = opStack.Pop();
                        var val2 = stack.Pop();
                        var val1 = stack.Pop();

                        stack.Push(ApplyOp(op, val1, val2));
                    }
                    opStack.Push(token);
                }
                else if (token == ")")
                {
                    while (opStack.Peek() != "(")
                    {
                        var op = opStack.Pop();
                        var val2 = stack.Pop();
                        var val1 = stack.Pop();

                        stack.Push(ApplyOp(op, val1, val2));
                    }
                    opStack.Pop();
                }
                else
                {
                    stack.Push(double.Parse(token));
                }
            }

            while (opStack.Count > 0)
            {
                var op = opStack.Pop();
                var val2 = stack.Pop();
                var val1 = stack.Pop();

                stack.Push(ApplyOp(op, val1, val2));
            }

            return stack.Pop();
        }

        private bool HasPrecedence(string op1, string op2)
        {
            if (op2 == "(" || op2 == ")")
            {
                return false;
            }
            if ((op1 == "*" || op1 == "/") && (op2 == "+" || op2 == "-"))
            {
                return false;
            }
            return true;
        }

        private double ApplyOp(string op, double val1, double val2)
        {
            switch (op)
            {
                case "+":
                    return val1 + val2;
                case "-":
                    return val1 - val2;
                case "*":
                    return val1 * val2;
                case "/":
                    if (val2 == 0)
                    {
                        throw new DivideByZeroException("Cannot divide by zero");
                    }
                    return val1 / val2;
            }
            return 0;
        }

    }
}
