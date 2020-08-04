using System;

namespace LispParenthesesCheckerLibrary
{
    public static class LispParentheseChecker
    {
        public static bool Validate(string lispExpression)
        {
            int openCount = 0;

            foreach (char c in lispExpression)
            {
                if (isOpen(c))
                {
                    openCount++;
                }
                else if (isClose(c))
                {
                    if (openCount == 0)
                    {
                        return false;
                    }
                    openCount--;
                }
            }

            return openCount == 0;
        }

        private static bool isOpen(char c)
        {
            return c == '(';
        }

        private static bool isClose(char c)
        {
            return c == ')';
        }
    }
}
