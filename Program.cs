using AdventOfCode22;
using AdventOfCode22.Day2;
using AdventOfCode22.Day3;
using AdventOfCode22.Day4;
using AdventOfCode22.Day5;

AdventCode adventDay1 = new();
var content = adventDay1.ReadDataFromFile("Day1/adventDay1.data");
adventDay1.FillInventory(content);
var mostCalories = adventDay1.GetMostCalories();

Console.WriteLine($"Day1: {mostCalories} -- the Elf carrying the most Calories");

var top3ElvesWithMostCalories = adventDay1.GetElvesAndCaloriesOrderedDesc().Take(3).Sum(p => p.TotalCalories);
Console.WriteLine($"Day1: {top3ElvesWithMostCalories} -- the top three Elves carrying the most Calories");


AdventDay2 adventDay2 = new();
var data = adventDay2.ReadDataFile("Day2/AdventDay2.data");
var result = adventDay2.play(data);

Console.WriteLine($"Day2: {result}");

IEnumerable<string> ReadDataFromAFile(string fileName)
{
    var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
    var path = Path.Combine(directory, fileName);

    return File.ReadAllText(path).Split(Environment.NewLine);
}

AdventDay3 adventDay3 = new();
var rucksackItems = ReadDataFromAFile("Day3/AdventDay3.data");
foreach (var items in rucksackItems)
{
    var errorChar = adventDay3.FindErrorInItems(items);
    adventDay3.IdentifyAndStorePriorityItem(errorChar);
}
Console.WriteLine($"Day3: {adventDay3.SumOfPriorities()} --the sum of the priorities");

adventDay3 = new();
for (int i = 0; i < rucksackItems.Count(); i+=3)
{
    var rucksackForAGroup = rucksackItems.Skip(i).Take(3).ToArray();
    var badge = adventDay3.FindBadge(rucksackForAGroup);
    adventDay3.IdentifyAndStorePriorityItem(badge);
}

Console.WriteLine($"Day3: {adventDay3.SumOfPriorities()} -- part2: the sum of the priorities of the badges");


AdventDay4 adventDay4 = new();
var adventDay4Data = ReadDataFromAFile("Day4/AdventDay4.data");

int count = adventDay4Data.Count(p => adventDay4.IsOverlapFully(p));

Console.WriteLine($"Day4: {count} -- part1: how many assignment pairs does one range fully contain the other");

int countPartially = adventDay4Data.Count(p => adventDay4.IsOverlapPartially(p));
Console.WriteLine($"Day4: {countPartially} -- part2: how many assignment pairs do the ranges overlap");


AdventDay5 adventDay5 = new();
var day5Part1Result = adventDay5.AfterRearrangementCratesFromTopOfEachStacks("Day5/AdventDay5.data");
Console.WriteLine($"Day5: {day5Part1Result} -- part1: After the rearrangement procedure completes, what crate ends up on top of each stack?");
// RMVWJPFGV -> wrong answer