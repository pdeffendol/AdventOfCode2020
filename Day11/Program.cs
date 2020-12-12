using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day11
{
    class Program
    {
        const char Occupied = '#';
        const char Floor = '.';
        const char Empty = 'L';

        static void Main(string[] args)
        {
            List<string> lines = File.ReadAllLines("input.txt").ToList();
            char[,] seating = new char[lines.Count, lines[0].Length];
            for (int r = 0; r < lines.Count; r++)
            {
                for (int c = 0; c < lines[0].Length; c++)
                {
                    seating[r, c] = lines[r][c];
                }
            }

            int numChanged = -1;
            var newSeating = seating;
            while (numChanged != 0)
            {
                (newSeating, numChanged) = Iterate(newSeating, OccupiedAdjacentStrategy);
            }
            Console.WriteLine($"Part 1: {CountOccupied(newSeating)} occupied seats");

            numChanged = -1;
            newSeating = seating;
            while (numChanged != 0)
            {
                (newSeating, numChanged) = Iterate(newSeating, OccupiedInLineStrategy);
            }
            Console.WriteLine($"Part 2: {CountOccupied(newSeating)} occupied seats");
        }

        private static int CountOccupied(char[,] input)
        {
            int occupied = 0;
            for (int r = 0; r < input.GetLength(0); r++)
            {
                for (int c = 0; c < input.GetLength(1); c++)
                {
                    if (input[r, c] == Occupied) occupied++;
                }
            }

            return occupied;
        }

        private static (char[,], int) Iterate(char[,] input, Func<char[,], int, int, char> switchStrategy)
        {
            var rows = input.GetLength(0);
            var cols = input.GetLength(1);
            var newSeating = new char[rows, cols];
            var numChanged = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    newSeating[r, c] = switchStrategy(input, r, c);

                    if (newSeating[r, c] != input[r, c]) numChanged++;
                }
            }

            return (newSeating, numChanged);
        }

        private static int OccupiedAdjacent(char[,] input, int row, int col)
        {
            var occupied = 0;
            if (IsOccupied(input, row - 1, col - 1)) occupied++;
            if (IsOccupied(input, row - 1, col)) occupied++;
            if (IsOccupied(input, row - 1, col + 1)) occupied++;
            if (IsOccupied(input, row, col - 1)) occupied++;
            if (IsOccupied(input, row, col + 1)) occupied++;
            if (IsOccupied(input, row + 1, col - 1)) occupied++;
            if (IsOccupied(input, row + 1, col)) occupied++;
            if (IsOccupied(input, row + 1, col + 1)) occupied++;

            return occupied;
        }

        private static int OccupiedInLine(char[,] input, int row, int col)
        {
            var occupied = 0;
            if (IsOccupiedInLine(input, row, col, -1, -1)) occupied++;
            if (IsOccupiedInLine(input, row, col, -1, 0)) occupied++;
            if (IsOccupiedInLine(input, row, col, -1, 1)) occupied++;
            if (IsOccupiedInLine(input, row, col, 0, -1)) occupied++;
            if (IsOccupiedInLine(input, row, col, 0, 1)) occupied++;
            if (IsOccupiedInLine(input, row, col, 1, -1)) occupied++;
            if (IsOccupiedInLine(input, row, col, 1, 0)) occupied++;
            if (IsOccupiedInLine(input, row, col, 1, 1)) occupied++;

            return occupied;
        }

        private static bool IsOccupiedInLine(char[,] input, int row, int col, int drow, int dcol)
        {
            int rows = input.GetLength(0);
            int cols = input.GetLength(1);

            int r = row += drow;
            int c = col += dcol;
            while (r >= 0 && r < rows && c >= 0 && c < cols)
            {
                if (input[r, c] == Occupied) return true;
                if (input[r, c] == Empty) return false;
                r += drow;
                c += dcol;
            }

            return false;
        }

        private static char OccupiedAdjacentStrategy(char[,] input, int row, int col)
        {
            return input[row, col] switch
            {
                Empty => OccupiedAdjacent(input, row, col) == 0 ? Occupied : Empty,
                Occupied => OccupiedAdjacent(input, row, col) >= 4 ? Empty : Occupied,
                _ => input[row, col],
            };
        }

        private static char OccupiedInLineStrategy(char[,] input, int row, int col)
        {
            return input[row, col] switch
            {
                Empty => OccupiedInLine(input, row, col) == 0 ? Occupied : Empty,
                Occupied => OccupiedInLine(input, row, col) >= 5 ? Empty : Occupied,
                _ => input[row, col],
            };
        }

        private static bool IsOccupied(char[,] input, int row, int col)
        {
            if (row < 0 || row >= input.GetLength(0) || col < 0 || col >= input.GetLength(1))
            {
                return false;
            }

            return input[row, col] == Occupied;
        }
    }
}
