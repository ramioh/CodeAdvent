using CodeAdvent;

var clues = new Clue[]
{
    new("682", 1, true),
    new("614", 1, false),
    new("206", 2, false),
    new("738", 0, false),
    new("780", 1, false),
};

var candidates = Enumerable
    .Range(0, 1000)
    .Select(x => $"{x:D3}");

var solutions = candidates
    .Where(input => clues.All(clue => clue.Matches(input)));

Console.WriteLine("Solution(s): {0}", string.Join(", ", solutions));
