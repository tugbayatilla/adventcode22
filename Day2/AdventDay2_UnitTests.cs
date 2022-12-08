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

        Assert.Equal(0, adventDay2.Calculate("", ""));
    }

    [Fact]
    public void _003_opponents_says_Rock_and_i_say_Paper_then_i_win_and_get_8_point()
    {
        AdventDay2 adventDay2 = new();

        Assert.Equal(8, adventDay2.Calculate("A", "Y"));
    }

    [Fact]
    public void _004_opponents_says_Paper_and_i_say_Rock_then_i_lost_and_get_1_point()
    {
        AdventDay2 adventDay2 = new();

        Assert.Equal(1, adventDay2.Calculate("B", "X"));
    }

    [Fact]
    public void _005_opponents_says_Scissors_and_i_say_scissors_then_we_draw_and_get_6_point()
    {
        AdventDay2 adventDay2 = new();

        Assert.Equal(6, adventDay2.Calculate("C", "Z"));
    }
}

public class AdventDay2
{
    private const string OppRock = "A";
    private const string OppPaper = "B";
    private const string OppScissors = "C";
    private const string Paper = "Y";
    private const string Rock = "X";
    private const string Scissors = "Z";

    public int Calculate(string opponentSelection, string mySelection)
    {
        var result = 0;
        const int WinPoint = 6;
        const int PaperPoint = 2;
        const int RockPoint = 1;
        const int ScissorsPoint = 3;
        bool won = false;

        if (opponentSelection == OppRock && mySelection == Paper)
        {
            won = true;
            result = PaperPoint;
        }

        if (opponentSelection == OppPaper && mySelection == Rock)
        {
            return RockPoint;
        }

        if (opponentSelection == OppScissors && mySelection == Scissors)
        {
            return ScissorsPoint + ScissorsPoint;
        }

        if (won) result += WinPoint;

        return result;
    }
}