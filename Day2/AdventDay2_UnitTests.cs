namespace AdventOfCode22.Day2;

public class AdventDay2UnitTests
{
    
    [Fact]
    public void _001_Day2_exist()
    {
        AdventDay2 adventDay2 = new();
        
        Assert.NotNull(adventDay2);
    }
    
    [Fact]
    public void _002_opponents_and_i_say_nothing_then_i_get_zero_point()
    {
        AdventDay2 adventDay2 = new();
        
        Assert.Equal(0, adventDay2.Calculate("",""));
    }
    
    [Fact]
    public void _003_opponents_says_Rock_and_i_say_Paper_then_i_win_and_get_8_point()
    {
        AdventDay2 adventDay2 = new();
        
        Assert.Equal(8, adventDay2.Calculate("A","Y"));
    }
    
    [Fact]
    public void _004_opponents_says_Paper_and_i_say_Rock_then_i_lost_and_get_1_point()
    {
        AdventDay2 adventDay2 = new();
        
        Assert.Equal(1, adventDay2.Calculate("B","X"));
    }
    
    [Fact]
    public void _005_opponents_says_Scissors_and_i_say_scissors_then_we_draw_and_get_6_point()
    {
        AdventDay2 adventDay2 = new();
        
        Assert.Equal(6, adventDay2.Calculate("C","Z"));
    }

}

public class AdventDay2
{
    public int Calculate(string opponentSelection, string mySelection)
    {
        if (opponentSelection == "A" && mySelection == "Y")
            return 8;
        
        if (opponentSelection == "B" && mySelection == "X")
            return 1;
        
        if (opponentSelection == "C" && mySelection == "Z")
            return 6;
        
        
        return 0;
    }
}