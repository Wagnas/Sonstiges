using System.Text.RegularExpressions;
using Day5;

namespace AdventOfCode.DayX;

internal class Day5
{
    public static void Main(string[] args)
    {
        try
        {
            string path = @"C:\Users\Wagner\Documents\Ausbildung\BetrieblicheAusbildung\AdventOfCode\input5.txt";

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File Not Found!");
            }
            string[] lines = File.ReadAllLines(path);

            const int rows = 8;
            int columns = lines[0].Length;

            var inputMatrix = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                string line= lines[i];
                for (int j = 0; j < line.Length; j++)
                {
                    inputMatrix[i, j] = line[j];
                }
            }

            var stacks = new List<Stack<char>>();

            for (int n = 1; n < inputMatrix.GetLength(1); n += 4)
            {
                Stack<char> inputStack = new Stack<char>();
                for (int m = 0; m < rows; m++)
                {
                    if (inputMatrix[m, n] == ' ') { continue; }
                    inputStack.Push(inputMatrix[m, n]);
                }
                stacks.Add(inputStack);
            }

            using (var reader = new StreamReader(path))
            {
                int currentLine = 1;

                while (currentLine < 11)
                {
                    reader.ReadLine();
                    currentLine++;
                }

                string line;
                var regex = new Regex(@"\d+");
                while ((line = reader.ReadLine()) != null)
                {
                    MatchCollection matches = regex.Matches(line);
                    var matchesArray = new int[matches.Count];

                    for (int i = 0; i < matches.Count; i++)
                    {
                        matchesArray[i] = int.Parse(matches[i].Value);
                    }
                    Crane.move(matchesArray[0], stacks[(matchesArray[1])-1], stacks[(matchesArray[2])-1]);
                }
            }
            foreach (Stack<char> stack in stacks)
            {
                stack.TryPop(out char result);
                Console.Write(result);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Fehler: " + e.Message);
        }
    }
}
