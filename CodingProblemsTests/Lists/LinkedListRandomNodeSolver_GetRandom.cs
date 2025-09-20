namespace CodingProblemsTests.Lists;

public class LinkedListRandomNodeSolver_GetRandom
{
    [Theory]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(10000)]
    [InlineData(5000)]
    public void Works(int numberOfItems)
    {
        ListNode head = DebugLinkedListFactory.Create<ListNode>(Enumerable.Range(0, numberOfItems).ToArray());
        LinkedListRandomNodeSolver solver = new(head);

        int samplesAmount = numberOfItems * 20;
        int[] samples = new int[samplesAmount];

        for (int attemptIdx = 0; attemptIdx < 3; attemptIdx++)
        {
            for (int i = 0; i < samplesAmount; i++)
                samples[i] = solver.GetRandom();

            if (samples.IsRandom(numberOfItems))
                return;
        }

        throw new InvalidOperationException("Not random at all");
    }
}
