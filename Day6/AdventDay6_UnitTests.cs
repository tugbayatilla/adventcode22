namespace AdventOfCode22.Day6;

public class AdventDay6UnitTests
{
    private readonly ElfCommSystem _elfCommSystem;

    public AdventDay6UnitTests()
    {
        _elfCommSystem = ElfCommSystem.Create();
    }
    
    
    [Theory]
    [InlineData("", 0)]
    [InlineData("asd", 0)]
    [InlineData("abcd", 4)]
    [InlineData("__cde", 5)]
    [InlineData("____", 0)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void Marker_finds_when_buffer_given(string buffer, int marker)
    {
        Assert.Equal(marker,_elfCommSystem.FindMarker(buffer));
    }
    
    [Theory]
    [InlineData("Day6/data/test01.data", 5)]
    [InlineData("Day6/data/AdventDay6.data", 1848)]
    public void Marker_found_with_given_file(string filePath, int marker)
    {
        var buffer = File.ReadAllText(filePath);
        Assert.Equal(marker,_elfCommSystem.FindMarker(buffer));
    }

    
    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void change_distinct_char_length_changes_the_marker(string buffer, int marker)
    {
        _elfCommSystem.ChangeDistinctCharLenght(14);
        Assert.Equal(marker,_elfCommSystem.FindMarker(buffer));
    }


    
}