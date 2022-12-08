using AdventOfCode22;

AdventDay1 adventDay1 = new();
var content = adventDay1.ReadDataFromFile("adventDay1.data");
adventDay1.FillInventory(content);
var mostCalories = adventDay1.GetMostCalories();

Console.WriteLine($"Most Calories:{mostCalories}");