using CodeAdvent;

foreach (var (clues, candidates) in new[] { NumberExample(), ColorExample() })
{
    var solutions = candidates
        .Where(x => clues.All(clue => clue.Matches(x)));

    Console.WriteLine("Solution(s): {0}", string.Join(", ", solutions));
}

(Clue[], IEnumerable<string>) NumberExample()
{
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

    return (clues, candidates);
}

(Clue[], IEnumerable<string>) ColorExample()
{
    var clues = new Clue[]
    {
        new("RBGY", 1, 1),
        new("POGY", 1, 0),
        new("GYGY", 0, 0),
        new("RBPP", 1, 1),
        new("ROBO", 2, 2),
    };

    const string colors = "RBGYPO";
    var candidates =
        from c1 in colors
        from c2 in colors
        from c3 in colors
        from c4 in colors
        select $"{c1}{c2}{c3}{c4}";

    return (clues, candidates);
}
