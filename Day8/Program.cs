using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var instructions = File.ReadAllLines("input.txt").Select(l => {
    var parts = l.Split(" ");
    return (parts[0], int.Parse(parts[1]));
}).ToList();


(_, var acc) = RunProgram(instructions);
Console.WriteLine($"Accumulator is {acc}");

for (int i = 0; i < instructions.Count; i++)
{
    var oldInst = instructions[i];
    switch (instructions[i].Item1)
    { 
        case "jmp":
            instructions[i] = ("nop", instructions[i].Item2);
            break;
        case "nop":
            instructions[i] = ("jmp", instructions[i].Item2);
            break;
        default:
            continue;
    }

    var result = RunProgram(instructions);
    if (result.Item1 == true)
    {
        Console.WriteLine($"Fixed accumulator is {result.Item2}");
        break;
    }
    instructions[i] = oldInst;
}

(bool, int) RunProgram(List<(string, int)> instructions)
{ 
    int acc = 0;
    int current = 0;
    Dictionary<int, bool> visited = new Dictionary<int, bool>();

    while (current < instructions.Count)
    {
        if (visited.ContainsKey(current)) break;
        visited[current] = true;
        switch (instructions[current].Item1)
        { 
            case "acc":
                acc += instructions[current].Item2;
                current++;
                break;
            case "jmp":
                current += instructions[current].Item2;
                break;
            default:
                current++;
                break;
        }
    }

    return (current == instructions.Count, acc);
}
