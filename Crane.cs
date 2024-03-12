namespace Day5
{
    internal static class Crane
    {
        public static void move(int numberOfCrates, Stack<char> fromStack, Stack<char> toStack)
        {
            while(numberOfCrates-- > 0)
            {
                if (fromStack.TryPop(out char element))
                {
                    toStack.Push(element);
                } 
                else
                {
                    break;
                }
            }
        }
    }
}
