using System.Diagnostics;

namespace AdventOfCode22.Day2;

public class AdventDay2UnitTests
{
    private const string OppRock = "A";
    private const string MePaper = "Y";
    private const string OppPaper = "B";
    private const string MeRock = "X";
    private const string OppScissors = "C";
    private const string MeScissors = "Z";

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

        Assert.Equal(8, adventDay2.Calculate(OppRock, MePaper));
    }

    [Fact]
    public void _004_opponents_says_Paper_and_i_say_Rock_then_i_lost_and_get_1_point()
    {
        AdventDay2 adventDay2 = new();

        Assert.Equal(1, adventDay2.Calculate(OppPaper, MeRock));
    }

    [Fact]
    public void _005_opponents_says_Scissors_and_i_say_scissors_then_we_draw_and_get_6_point()
    {
        AdventDay2 adventDay2 = new();

        Assert.Equal(6, adventDay2.Calculate(OppScissors, MeScissors));
    }
}

public class AdventDay2
{
    private const string Rock = "rock";
    private const string Paper = "paper";
    private const string Scissors = "scissors";

    public int Calculate(string opponentSelection, string mySelection)
    {
        var result = 0;
        const int WinPoint = 6;
        const int PaperPoint = 2;
        const int RockPoint = 1;
        const int ScissorsPoint = 3;
        bool won = false;

        opponentSelection = opponentSelection switch
        {
            "A" => Rock,
            "B" => Paper,
            "C" => Scissors,
            _ => ""
        };
        
        mySelection = mySelection switch
        {
            "X" => Rock,
            "Y" => Paper,
            "Z" => Scissors,
            _ => ""
        };
        

        if (opponentSelection == Rock && mySelection == Paper)
        {
            won = true;
            result = PaperPoint;
        }

        if (opponentSelection == Paper && mySelection == Rock)
        {
            return RockPoint;
        }

        if (opponentSelection == Scissors && mySelection == Scissors)
        {
            return ScissorsPoint + ScissorsPoint;
        }

        if (won) result += WinPoint;

        return result;
    }
}