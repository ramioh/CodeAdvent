using CodeAdvent;

var clues = new Clue[]
{
    new("682", 1, 0),
    new("614", 0, 1),
    new("206", 0, 2),
    new("738", 0, 0),
    new("780", 0, 1),
};

var candidates = Enumerable
    .Range(0, 1000)
    .Select(x => $"{x:D3}");

var solutions = candidates
    .Where(input => clues.All(clue => clue.Matches(input)));

Console.WriteLine("Solution(s): {0}", string.Join(", ", solutions));
