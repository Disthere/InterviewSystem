using InterviewSystem.Application;
using InterviewSystem.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = new PollBuilder("Ключевое слово для переопределения методов в классе:")
            .AddAnswer(Guid.Parse("50b04c62-e1f6-472a-8faa-e0fc8606df8a"), "remove")
            .AddAnswer(Guid.Parse("d6799df1-0e4c-43a6-b708-5a212668a11c"), "static")
            .AddAnswer(Guid.Parse("1d74fa2f-d17f-422b-82ea-d0ae3d92afc8"), "trow")
            .AddAnswer(Guid.Parse("e9aba12e-f700-4515-b432-6a5491874121"), "ovveride");

        var poll = builder.Build();

        poll.VoteTo(Guid.Parse("50b04c62-e1f6-472a-8faa-e0fc8606df8a"));
        poll.VoteTo(Guid.Parse("1d74fa2f-d17f-422b-82ea-d0ae3d92afc8"));
        poll.VoteTo(Guid.Parse("e9aba12e-f700-4515-b432-6a5491874121"));
        poll.VoteTo(Guid.Parse("1d74fa2f-d17f-422b-82ea-d0ae3d92afc8"));
        poll.VoteTo(Guid.Parse("e9aba12e-f700-4515-b432-6a5491874121"));
        poll.VoteTo(Guid.Parse("1d74fa2f-d17f-422b-82ea-d0ae3d92afc8"));
        poll.VoteTo(Guid.Parse("d6799df1-0e4c-43a6-b708-5a212668a11c"));
        poll.VoteTo(Guid.Parse("d6799df1-0e4c-43a6-b708-5a212668a11c"));
        poll.VoteTo(Guid.Parse("d6799df1-0e4c-43a6-b708-5a212668a11c"));
        poll.VoteTo(Guid.Parse("d6799df1-0e4c-43a6-b708-5a212668a11c"), 10);

        var result = builder.GetResults(poll);

        Console.WriteLine(result.GetView());

        var poll2 = new Poll("Последняя рабочая версия .NET?")
        {
            Answers = new List<Answer>
            {
                new(Guid.Parse("694ddd5e-cdcf-4a70-af88-37904df4c987"),".NET 6"),
                new(Guid.Parse("4f035d94-2a5c-4060-917f-f829c4d90035"),".NET 5"),
                new(Guid.Parse("6ec33492-22b6-45ce-a3eb-95f3693c54ab"),".NET 7"),
                new(Guid.Parse("a629386d-dc49-4186-a1d0-0c995b1992fe"),".NET Core 3.1")
            }
        };

        poll2.VoteTo(Guid.Parse("694ddd5e-cdcf-4a70-af88-37904df4c987"));
        poll2.VoteTo(Guid.Parse("6ec33492-22b6-45ce-a3eb-95f3693c54ab"));
        poll2.VoteTo(Guid.Parse("4f035d94-2a5c-4060-917f-f829c4d90035"));
        poll2.VoteTo(Guid.Parse("4f035d94-2a5c-4060-917f-f829c4d90035"));
        poll2.VoteTo(Guid.Parse("694ddd5e-cdcf-4a70-af88-37904df4c987"));
        poll2.VoteTo(Guid.Parse("6ec33492-22b6-45ce-a3eb-95f3693c54ab"));
        poll2.VoteTo(Guid.Parse("694ddd5e-cdcf-4a70-af88-37904df4c987"));
        poll2.VoteTo(Guid.Parse("6ec33492-22b6-45ce-a3eb-95f3693c54ab"));
        poll2.VoteTo(Guid.Parse("4f035d94-2a5c-4060-917f-f829c4d90035"));
        poll2.VoteTo(Guid.Parse("a629386d-dc49-4186-a1d0-0c995b1992fe"), 12);

        result = builder.GetResults(poll2);

        using (var context = new ApplicationDbContext())
        {
            context.Polls.Add(poll2);
            context.SaveChanges();
        }

        using (var context = new ApplicationDbContext())
        {
            foreach (var answer in context.Answers)
            {
                Console.WriteLine(answer.Version);
            }
        }

        Console.WriteLine(result.GetView());
    }
}
