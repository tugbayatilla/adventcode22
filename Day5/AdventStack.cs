namespace AdventOfCode22.Day5;

public class AdventStack : List<string>
{
    public int Id { get; set; } = 1;
    
    public AdventStack AddCrates(params string[] crates)
    {
        crates.ToList().ForEach(Add);

        return this;
    }

}