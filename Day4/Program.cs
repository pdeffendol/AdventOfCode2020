using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

var text = File.ReadAllText("input.txt");
var passportStrings = text.Split("\n\n");
var passports = passportStrings.Select(GetPassportValues);

Console.WriteLine($"Part 1: {passports.Count(IsValidPartOne)}");
Console.WriteLine($"Part 2: {passports.Count(IsValidPartTwo)}");

Dictionary<string, string> GetPassportValues(string passportString)
{ 
    var passport = new Dictionary<string, string>();

    var pairs = Regex.Split(passportString, @"\s+").Where(p => !string.IsNullOrWhiteSpace(p));
    foreach (var pair in pairs)
    {
        var split = pair.Split(":");
        passport.Add(split[0].Trim(), split[1].Trim());
    }

    return passport;
}

bool IsValidPartOne(Dictionary<string, string> passport)
{
    if (passport.Count < 7) return false;

    //cid (Country ID) - ignored, missing or not.
    if (passport.Count == 7 && passport.ContainsKey("cid")) return false;

    return true;
}

bool IsValidPartTwo(Dictionary<string, string> passport)
{
    if (!IsValidPartOne(passport)) return false;

    //byr (Birth Year) - four digits; at least 1920 and at most 2002.
    var byr = int.Parse(passport["byr"]);
    if (byr < 1920 || byr > 2002) return false;

    //iyr (Issue Year) - four digits; at least 2010 and at most 2020.
    var iyr = int.Parse(passport["iyr"]);
    if (iyr < 2010 || iyr > 2020) return false;

    //eyr (Expiration Year) - four digits; at least 2020 and at most 2030.
    var eyr = int.Parse(passport["eyr"]);
    if (eyr < 2020 || eyr > 2030) return false;

    //hgt (Height) - a number followed by either cm or in:
    var hgtMatch = Regex.Match(passport["hgt"], @"^(\d+)(cm|in)$");
    if (!hgtMatch.Success) return false;

    //If cm, the number must be at least 150 and at most 193.
    //If in, the number must be at least 59 and at most 76.
    var units = hgtMatch.Groups[2].Value;
    var hgt = int.Parse(hgtMatch.Groups[1].Value);
    if (units == "cm" && (hgt < 150 || hgt > 193)) return false;
    if (units == "in" && (hgt < 59 || hgt > 76)) return false;

    //hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
    if (!Regex.IsMatch(passport["hcl"], @"^#[0-9a-f]{6}$")) return false;

    //ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
    var colors = new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
    if (!colors.Contains(passport["ecl"])) return false;

    //pid (Passport ID) - a nine-digit number, including leading zeroes.
    if (!Regex.IsMatch(passport["pid"], @"^\d{9}$")) return false;

    return true;
}

