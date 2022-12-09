using Xunit.Sdk;

namespace AdventOfCode22.Day3;

public class AdventDay3UnitTests
{
    private readonly AdventDay3 _adventDay3 = new();

    [Fact]
    public void Test1()
    {
        Assert.Equal(0, _adventDay3.SumOfPriorities());
    }
    
    [Fact(Skip = $"another test covers this test. {nameof(_004_identified_and_stored_items_and_calculate_sum_of_priorities)}")]
    public void _002_identified_and_stored_item_lowercase_p_is_16_points()
    {
        _adventDay3.IdentifyAndStorePriorityItem('p');
        
        Assert.Equal(16, _adventDay3.SumOfPriorities());
    }
    
    [Fact(Skip = $"another test covers this test. {nameof(_004_identified_and_stored_items_and_calculate_sum_of_priorities)}")]
    public void _003_identified_and_stored_two_items_lowercase_p_and_uppercase_L_are_54_points()
    {
        _adventDay3.IdentifyAndStorePriorityItem('p');
        _adventDay3.IdentifyAndStorePriorityItem('L');
        
        Assert.Equal(16+38, _adventDay3.SumOfPriorities());
    }
    
    [Theory]
    [InlineData("p", 16)]
    [InlineData("L", 38)]
    [InlineData("pL", 54)]
    [InlineData("pLPvts", 157)]
    public void _004_identified_and_stored_items_and_calculate_sum_of_priorities(string priorityItems, int expectedSumOfPriority)
    {
        foreach (var priorityItem in priorityItems)
        {
            _adventDay3.IdentifyAndStorePriorityItem(priorityItem);
        }

        Assert.Equal(expectedSumOfPriority, _adventDay3.SumOfPriorities());
    }
    
    [Theory]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", 'p')]
    [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 'L')]
    [InlineData("PmmdzqPrVvPwwTWBwg", 'P')]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", 'v')]
    [InlineData("ttgJtRGJQctTZtZT", 't')]
    [InlineData("CrZsJsPPZsGzwwsLwLmpwMDw", 's')]
    public void _005_find_error_char_in_rucksack_line(string items, char errorChar)
    {
        Assert.Equal(errorChar, _adventDay3.FindErrorInItems(items));
    }
    
    [Fact(Skip = "Theory added. no need this one anymore.")]
    public void _006_Finding_batch_in_a_rucksack()
    {
        var rucksacks = new string[]
        {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg"
        };
        Assert.Equal('r', _adventDay3.FindBadge(rucksacks));
    }
    
    [Theory]
    [InlineData('r', new string[]
    {
        "vJrwpWtwJgWrhcsFMMfFFhFp",
        "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
        "PmmdzqPrVvPwwTWBwg"
    })]
    [InlineData('Z', new string[]
    {
        "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
        "ttgJtRGJQctTZtZT",
        "CrZsJsPPZsGzwwsLwLmpwMDw"
    })]
    public void _007_Finding_batch_in_a_rucksack(char expectedBadge, string[] rucksack)
    {
        Assert.Equal(expectedBadge, _adventDay3.FindBadge(rucksack));
    }
}