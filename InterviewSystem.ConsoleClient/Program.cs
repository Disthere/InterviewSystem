using InterviewSystem.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = new PollBuilder("Ключевое слово для переопределения методов в классе:")
            .AddAnswer(1, "remove")
            .AddAnswer(2, "static")
            .AddAnswer(3, "trow")
            .AddAnswer(4, "ovveride");

        var poll = builder.Build();

        poll.VoteTo(2);
        poll.VoteTo(3);
        poll.VoteTo(3);
        poll.VoteTo(2);
        poll.VoteTo(4);
        poll.VoteTo(3);
        poll.VoteTo(1);
        poll.VoteTo(1);
        poll.VoteTo(3);
        poll.VoteTo(3, 10);

        var result = builder.GetResults(poll);

        Console.WriteLine(result.GetView());

        var poll2 = new Poll("Последняя рабочая версия .NET?")
        {
            Answers = new List<PollAnswer>
            {
                new(1,".NET 6"),
                new(2,".NET 5"),
                new(3,".NET 7"),
                new(4,".NET Core 3.1")
            }
        };

        poll2.VoteTo(2);
        poll2.VoteTo(3);
        poll2.VoteTo(3);
        poll2.VoteTo(2);
        poll2.VoteTo(4);
        poll2.VoteTo(3);
        poll2.VoteTo(1);
        poll2.VoteTo(1);
        poll2.VoteTo(3);
        poll2.VoteTo(3, 12);

        result = builder.GetResults(poll2);

        Console.WriteLine(result.GetView());
    }
}
