using System;
using System.IO;
using System.Linq;

var groups = File.ReadAllText("input.txt").Split("\n\n");

var anyYes = groups.Select(g => g.ToArray().Where(c => c >= 'a' && c <= 'z').Distinct().Count());

Console.WriteLine($"Part 1: {anyYes.Sum()}");

var questions = "abcdefghijklmnopqrstuvwxyz";
var allYes = groups.Select(g =>
{
    var people = g.Trim().Split("\n");
    return questions.Count(q => people.All(p => p.Contains(q)));
});

Console.WriteLine($"Part 2: {allYes.Sum()}");
