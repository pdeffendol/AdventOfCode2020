using System;
using System.IO;
using System.Linq;

var commands = File.ReadAllLines("input.txt")
    .Select(l => (l[0], int.Parse(l.Substring(1)))).ToList();

// directions N,E,S,W = 0, 1, 2, 3

var x = 0; // Positive is east
var y = 0; // Positive is south
var currentDirection = 1;

foreach (var command in commands)
{
    var turns = 0;
    switch (command.Item1)
    {
        case 'N':
            y -= command.Item2;
            break;
        case 'S':
            y += command.Item2;
            break;
        case 'E':
            x += command.Item2;
            break;
        case 'W':
            x -= command.Item2;
            break;
        case 'L':
            turns = (360 - command.Item2 / 90) % 4;
            currentDirection = (currentDirection + turns) % 4;
            break;
        case 'R':
            turns = command.Item2 / 90 % 4;
            currentDirection = (currentDirection + turns) % 4;
            break;
        case 'F':
            if (currentDirection == 0) y -= command.Item2;
            if (currentDirection == 1) x += command.Item2;
            if (currentDirection == 2) y += command.Item2;
            if (currentDirection == 3) x -= command.Item2;
            break;
    }
}

var distance = Math.Abs(x) + Math.Abs(y);
Console.WriteLine($"Part 1: {distance}");


x = 0; // Positive is east
y = 0; // Positive is south
var wx = 10; // relative to ship
var wy = -1; // relative to ship

foreach (var command in commands)
{
    var turns = 0;
    switch (command.Item1)
    {
        case 'N':
            wy -= command.Item2;
            break;
        case 'S':
            wy += command.Item2;
            break;
        case 'E':
            wx += command.Item2;
            break;
        case 'W':
            wx -= command.Item2;
            break;
        case 'L':
            turns = (360 - command.Item2 / 90) % 4;
            (wx, wy) = Rotate(wx, wy, turns);
            break;
        case 'R':
            turns = command.Item2 / 90 % 4;
            (wx, wy) = Rotate(wx, wy, turns);
            break;
        case 'F':
            int dx = wx * command.Item2;
            int dy = wy * command.Item2;
            x += dx;
            y += dy;
            break;
    }
}

distance = Math.Abs(x) + Math.Abs(y);
Console.WriteLine($"Part 2: {distance}");

(int, int) Rotate(int x, int y, int turnsRight)
{
    var (xp, yp) = (x, y);
    for (int i = 0; i < turnsRight; i++)
    {
        (xp, yp) = (yp * -1, xp);
    }

    return (xp, yp);
}
