using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CustomExpressionEvaluator
{
    public class ExpressionSolver // operation Precedence
    {
        private static readonly Dictionary<char, int> Precedence = new Dictionary<char, int>
        {
            { '+', 1 },
            { '-', 1 },
            { '*', 2 },
            { '/', 2 }
        };

        public double Evaluate(string expression)
        {
            Queue<object> postfixQueue = ConvertToPostfix(expression);
            Stack<double> stack = new Stack<double>();

            foreach (var token in postfixQueue)
            {
                if (token is double value)
                {
                    stack.Push(value);
                }
                else if (token is char op)
                {
                    double b = stack.Pop();
                    double a = stack.Pop();

                    switch (op)
                    {
                        case '+': stack.Push(a + b); break;
                        case '-': stack.Push(a - b); break;
                        case '*': stack.Push(a * b); break;
                        case '/': stack.Push(a / b); break;
                    }
                }
            }

            return stack.Pop();
        }

        private Queue<object> ConvertToPostfix(string expression) //expression to postfix ( 4 + (5/6)) to 4 5 6 / +
        {
            Queue<object> postfixQueue = new Queue<object>();
            Stack<char> operators = new Stack<char>();

            foreach (char ch in expression)
            {
                if (char.IsDigit(ch)) // digit
                {
                    int numStart = expression.IndexOf(ch);// find the index of the first digit of the number and initialize the index of the last digit of the number
                    int numEnd = numStart; 

                    while (numEnd < expression.Length && (char.IsDigit(expression[numEnd]) || expression[numEnd] == '.')) 
                    {
                        numEnd++;
                    }

                    string numStr = expression.Substring(numStart, numEnd - numStart);// get the substring that represents the number
                    postfixQueue.Enqueue(double.Parse(numStr));
                }
                else if (ch == '(') // if the character is an opening parenthesis and push  to the stack
                {
                    operators.Push(ch);
                }
                else if (ch == ')') // if the character is a closing parenthesis
                {
                    while (operators.Count > 0 && operators.Peek() != '(') // while the stack is not empty and the top element is not an opening parenthesis
                    {
                        postfixQueue.Enqueue(operators.Pop());
                    }
                    operators.Pop(); // Pop '('
                }
                else if (Precedence.ContainsKey(ch)) // if the character is an operator and its precedence is defined in a dictionary called Precedence
                {
                    while (operators.Count > 0 && operators.Peek() != '(' && Precedence[operators.Peek()] >= Precedence[ch]) 
                    {
                        postfixQueue.Enqueue(operators.Pop());
                    }
                    operators.Push(ch);
                }
            }

            while (operators.Count > 0)// after looping through all characters, while the stack is not empty
            {
                postfixQueue.Enqueue(operators.Pop()); 
            }

            return postfixQueue; 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ExpressionSolver evaluator = new ExpressionSolver();

            while (true)
            {
                Console.Write("Enter an expression: ");
                string expression = Console.ReadLine();

                if (expression.ToLower() == "exit")
                {
                    break;
                }

                try
                {
                    double result = evaluator.Evaluate(expression);
                    Console.WriteLine($"Result: {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}