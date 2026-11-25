using System.Diagnostics;
using scheduledInterval;

public class Solution
{
    public static List<List<ScheduledInterval>> returnMax(List<ScheduledInterval> activityList, int leftLimit, int rightLimit, ref int divisions)
    {
        if (rightLimit - leftLimit == 1)
        {
            return new List<List<ScheduledInterval>>
            {
                new List<ScheduledInterval> { activityList[leftLimit] }
            };
        }
        divisions++;
        int middleIndex = leftLimit + (rightLimit - leftLimit) / 2;
        List<List<ScheduledInterval>> leftList = returnMax(activityList, leftLimit, middleIndex, ref divisions);
        List<List<ScheduledInterval>> rightList = returnMax(activityList, middleIndex, rightLimit, ref divisions);

        List<List<ScheduledInterval>> mergedList = new List<List<ScheduledInterval>>();
        mergedList.AddRange(leftList);
        mergedList.AddRange(rightList);

        foreach (var scheduleLeft in leftList)
        {
            foreach (var scheduleRight in rightList)
            {
                bool isCompatible = true;
                foreach (var leftInterval in scheduleLeft)
                {
                    foreach (var rightInterval in scheduleRight)
                    {

                        if (leftInterval.finishTime > rightInterval.startTime)
                        {
                            isCompatible = false;
                            break;
                        }
                    }
                    if (!isCompatible)
                    {
                        break;
                    }
                }
                if (isCompatible)
                {
                    List<ScheduledInterval> newValidSchedule = new List<ScheduledInterval>(scheduleRight);
                    newValidSchedule.AddRange(scheduleLeft);
                    mergedList.Add(newValidSchedule);
                }
            }
        }
        return mergedList;
    }

    public static void Main(string[] args)
    {
        List<ScheduledInterval> activityList20 = new List<ScheduledInterval>
        {
            new() { startTime = 8, finishTime = 12, weight = 15},
            new() { startTime = 1, finishTime = 4, weight = 8},
            new() { startTime = 3, finishTime = 9, weight = 20},
            new() { startTime = 5, finishTime = 7, weight = 6},
            new() { startTime = 12, finishTime = 16, weight = 18 },
            new() { startTime = 2, finishTime = 6, weight = 11 },
            new() { startTime = 15, finishTime = 19, weight = 25 },
            new() { startTime = 7, finishTime = 11, weight = 13 },
            new() { startTime = 4, finishTime = 13, weight = 22 },
            new() { startTime = 18, finishTime = 23, weight = 17 },
            new() { startTime = 10, finishTime = 14, weight = 9},
            new() { startTime = 20, finishTime = 25, weight = 30 },
            new() { startTime = 6, finishTime = 10, weight = 14 },
            new() { startTime = 13, finishTime = 18, weight = 21 },
            new() { startTime = 22, finishTime = 27, weight = 19 },
            new() { startTime = 9, finishTime = 15, weight = 28},
            new() { startTime = 24, finishTime = 29, weight = 16},
            new() { startTime = 16, finishTime = 21, weight = 12},
            new() { startTime = 26, finishTime = 31, weight = 24 },
            new() { startTime = 30, finishTime = 35, weight = 35},
        };

        List<ScheduledInterval> activityList50 = new List<ScheduledInterval>
        {
            new() { startTime = 12, finishTime = 18, weight = 25},
            new() { startTime = 2, finishTime = 5, weight = 10},
            new() { startTime = 7, finishTime = 14, weight = 18 },
            new() { startTime = 1, finishTime = 8, weight = 22 },
            new() { startTime = 20, finishTime = 24, weight = 16 },
            new() { startTime = 4, finishTime = 9, weight = 13 },
            new() { startTime = 15, finishTime = 21, weight = 30 },
            new() { startTime = 9, finishTime = 12, weight = 11},
            new() { startTime = 25, finishTime = 30, weight = 27 },
            new() { startTime = 3, finishTime = 11, weight = 19},
            new() { startTime = 18, finishTime = 26, weight = 23},
            new() { startTime = 11, finishTime = 16, weight = 14 },
            new() { startTime = 28, finishTime = 34, weight = 35 },
            new() { startTime = 6, finishTime = 10, weight = 8 },
            new() { startTime = 22, finishTime = 28, weight = 20},
            new() { startTime = 13, finishTime = 17, weight = 17},
            new() { startTime = 31, finishTime = 37, weight = 29},
            new() { startTime = 8, finishTime = 15, weight = 26},
            new() { startTime = 35, finishTime = 41, weight = 32},
            new() { startTime = 16, finishTime = 20, weight = 12 },
            new() { startTime = 5, finishTime = 13, weight = 24 },
            new() { startTime = 39, finishTime = 45, weight = 21 },
            new() { startTime = 24, finishTime = 29, weight = 15 },
            new() { startTime = 10, finishTime = 19, weight = 28 },
            new() { startTime = 42, finishTime = 48, weight = 38 },
            new() { startTime = 19, finishTime = 23, weight = 9},
            new() { startTime = 27, finishTime = 33, weight = 31 },
            new() { startTime = 14, finishTime = 22, weight = 16},
            new() { startTime = 33, finishTime = 39, weight = 34 },
            new() { startTime = 21, finishTime = 27, weight = 18 },
            new() { startTime = 45, finishTime = 51, weight = 40},
            new() { startTime = 30, finishTime = 36, weight = 22 },
            new() { startTime = 17, finishTime = 25, weight = 27},
            new() { startTime = 48, finishTime = 54, weight = 33},
            new() { startTime = 26, finishTime = 32, weight = 19},
            new() { startTime = 37, finishTime = 43, weight = 36 },
            new() { startTime = 23, finishTime = 31, weight = 25 },
            new() { startTime = 41, finishTime = 47, weight = 30},
            new() { startTime = 34, finishTime = 40, weight = 17 },
            new() { startTime = 29, finishTime = 38, weight = 28 },
            new() { startTime = 46, finishTime = 53, weight = 26},
            new() { startTime = 38, finishTime = 44, weight = 23},
            new() { startTime = 50, finishTime = 57, weight = 42 },
            new() { startTime = 32, finishTime = 42, weight = 37},
            new() { startTime = 44, finishTime = 50, weight = 29},
            new() { startTime = 52, finishTime = 59, weight = 45},
            new() { startTime = 40, finishTime = 49, weight = 24 },
            new() { startTime = 55, finishTime = 62, weight = 39 },
            new() { startTime = 49, finishTime = 56, weight = 20 },
            new() { startTime = 58, finishTime = 65, weight = 48 }
        };

        Random rand = new Random();
        Stopwatch stopwatch = new Stopwatch();

        List<ScheduledInterval> activityList1million = new List<ScheduledInterval>(1_000_000);

        for (int i = 0; i < 1_000_000; i++)
        {
            int startTime = rand.Next(0, 10_000_000);
            int finishTime = startTime + rand.Next(1, 1000);

            activityList1million.Add(new ScheduledInterval
            {
                startTime = startTime,
                finishTime = finishTime,
                weight = rand.Next(1, 1000),
            });
        }

        activityList50.Sort((x, y) => x.finishTime.CompareTo(y.finishTime));

        int divisions = 1;
        stopwatch.Start();

        List<List<ScheduledInterval>> answer = returnMax(activityList50, 0, activityList50.Count, ref divisions);
        int maxWeight = answer.Max(schedule => schedule.Sum(interval => interval.weight));

        stopwatch.Stop();

        Console.WriteLine($"Máximo peso encontrado: {maxWeight}");
        Console.WriteLine($"Divisões realizadas e nível máximo de recursão: {divisions}");
        Console.WriteLine($"Chamadas recursivas realizadas: {divisions * 2}");
        Console.WriteLine($"Tempo decorrido: {stopwatch.Elapsed.TotalMilliseconds}");
    }
}