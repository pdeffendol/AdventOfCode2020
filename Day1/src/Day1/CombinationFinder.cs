using System;
using System.Collections.Generic;
using System.Linq;

public class CombinationFinder
{
    public IEnumerable<List<int>> FindCombinations(List<int> items, int numberToTake)
    {
        if (numberToTake < 1)
            throw new ArgumentOutOfRangeException("Can't take fewer than 1 item at a time");

        if (items.Count == 0 || numberToTake > items.Count)
            yield break;

        if (numberToTake == 1)
        { 
            foreach (var item in items)
            {
                yield return new List<int> { item };
            }
            yield break;
        }

        int head = items.First();
        var tail = items.Skip(1).ToList();

        if (!tail.Any())
            yield return new List<int> { head };


        foreach (var tailItem in FindCombinations(tail, numberToTake - 1))
        {
            var newList = new List<int>();
            newList.Add(head);
            newList.AddRange(tailItem);
            yield return newList;
        }

        foreach (var tailItem in FindCombinations(tail, numberToTake))
        {
            yield return tailItem;
        }
    }
}