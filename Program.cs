using AdventOfCode22;
using AdventOfCode22.Day2;

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