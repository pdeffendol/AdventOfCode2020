using System;
using System.IO;
using System.Linq;

var lines = File.ReadAllLines("input.txt").Select(long.Parse).ToList();
int preambleLength = 25;
long badNumber = 0;

for (int i = preambleLength; i < lines.Count; i++)
{
    Console.WriteLine($"Checking {lines[i]}");
    bool foundTerms = false;
    for (int j = i - preambleLength; j < i && !foundTerms; j++)
    {
        for (int k = j + 1; k < i && !foundTerms; k++)
        {
            if (lines[j] + lines[k] == lines[i])
            {
                foundTerms = true;
                Console.WriteLine($"{lines[j]} + {lines[k]} = {lines[i]}");
            }
        }
    }

    if (!foundTerms)
    {
        badNumber = lines[i];
        break;
    }
}

Console.WriteLine($"Bad number is {badNumber}");

for (int i = 0; i < lines.Count; i++)
{
    long contiguousSum = 0;
    var sumIndex = i;
    var smallestNumber = long.MaxValue;
    var largestNumber = long.MinValue;
    while (contiguousSum < badNumber && i < lines.Count)
    {
        smallestNumber = Math.Min(lines[sumIndex], smallestNumber);
        largestNumber = Math.Max(lines[sumIndex], largestNumber);
        contiguousSum += lines[sumIndex++];
    }

    if (contiguousSum == badNumber)
    {
        long weakness = smallestNumber + largestNumber;
        Console.WriteLine($"Weakness is {weakness}");
        break;
    }
}
