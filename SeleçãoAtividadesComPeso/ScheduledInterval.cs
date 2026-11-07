namespace scheduledInterval;

public class ScheduledInterval
{
    public int startTime { get; set; }

    public int finishTime { get; set; }

    public int weight { get; set; }

    public int bestYetSolution { get; set; }

    public int lastCompatibleIndex { get; set; }
}