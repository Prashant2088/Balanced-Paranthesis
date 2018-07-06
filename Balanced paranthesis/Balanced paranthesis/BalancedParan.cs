using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balanced_paranthesis
{
    public class BalancedParan
    {
        //Stack operations here 
        internal class stack
        {
            internal int top = -1;
            internal char[] items = new char[100];

            internal virtual void push(char x)
            {
                if (top == 99)
                    Console.WriteLine("Stack  Is full");
                else
                    items[++top] = x;
            }

            internal virtual char pop()
            {
                if (top == -1)
                {
                    Console.WriteLine("Underflow error");
                    return '\0';
                }
                else
                {
                    char element = items[top];
                    top--;
                    return element;
                }
            }

            internal virtual bool Empty
            {
                get
                {
                    return (top == -1) ? true : false;
                }
            }
        }

        //Returns true if Both characters are matching
        internal static bool isMatchingPair(char character1, char character2)
        {
            if (character1 == '(' && character2 == ')')
                return true;

            else if (character1 == '{' && character2 == '}')
                return true;

            else if (character1 == '[' && character2 == ']')
                return true;

            else
                return false;
        }

        /* Return true if expression has balanced Parenthesis */
        internal static bool areParenthesisBalanced(char[] exp)
        {
            /* Declare an empty character stack */
            stack st = new stack();

            /* check matching parenthesis */
            for (int i = 0; i < exp.Length; i++)
            {

                /*If the exp[i] is a starting 
                    parenthesis then push it*/
                if (exp[i] == '{' || exp[i] == '(' || exp[i] == '[')
                {
                    st.push(exp[i]);
                }

                /* If exp[i] is an ending parenthesis 
                    then pop from stack and check if the 
                    popped parenthesis is a matching pair*/
                if (exp[i] == '}' || exp[i] == ')' || exp[i] == ']')
                {

                    /* If we see an ending parenthesis without 
                        a pair then return false*/
                    if (st.Empty)
                    {
                        return false;
                    }

                    /* Pop the top element from stack, if 
                        it is not a pair parenthesis of character 
                        then there is a mismatch. This happens for 
                        expressions like {(}) */
                    else if (!isMatchingPair(st.pop(), exp[i]))
                    {
                        return false;
                    }
                }

            }

            /* If there is something left in expression 
                then there is a starting parenthesis without 
                a closing parenthesis */

            if (st.Empty)
            {
                return true; //balanced
            }
            else
            { //not balanced
                return false;
            }
        }

        static void Main(string[] args)
        {
            char[] exp = new char[] { '{', '(', ')', '}', '[', ']' };

            if (areParenthesisBalanced(exp))
                Console.WriteLine("Balanced ");
            else
                Console.WriteLine("Not Balanced ");

        }
    }
}
