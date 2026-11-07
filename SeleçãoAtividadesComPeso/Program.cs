using System.Diagnostics;
using scheduledInterval;
using searchingMethods;

public class Solution
{
    SearchingMethods searchingMethods = new SearchingMethods();
    public int WeightedIntervalScheduling(List<ScheduledInterval> activityList)
    {
        activityList.Sort((x, y) => x.finishTime - y.finishTime);

        for (int i = activityList.Count() - 1; i > 0; i--)
        {
            activityList[i].lastCompatibleIndex = searchingMethods.BinarySearch(activityList, i, 0, i - 1, -1);
        }

        activityList[0].bestYetSolution = activityList[0].weight;

        for (int i = 1; i < activityList.Count(); i++)
        {
            int lcs = activityList[i].lastCompatibleIndex == -1 ? 0 : activityList[activityList[i].lastCompatibleIndex].bestYetSolution;
            int bys = activityList[i - 1].bestYetSolution;

            activityList[i].bestYetSolution = Math.Max(activityList[i].weight + lcs, bys);

            if (activityList[i].bestYetSolution != activityList[i - 1].bestYetSolution)
            {
                Console.WriteLine($"Novo melhor resultado:{activityList[i].bestYetSolution}");
            }
            else
            {
                Console.WriteLine($"Resultado anterior mantido:{activityList[i - 1].bestYetSolution}");
            }
        }

        return activityList[activityList.Count() - 1].bestYetSolution;

    }
    public static void Main(string[] Args)
    {

        Stopwatch stopwatch = new Stopwatch();
        Solution solution = new Solution();
        List<ScheduledInterval> activityList20 = new List<ScheduledInterval>
        {
            new() { startTime = 8, finishTime = 12, weight = 15, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 1, finishTime = 4, weight = 8, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 3, finishTime = 9, weight = 20, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 5, finishTime = 7, weight = 6, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 12, finishTime = 16, weight = 18, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 2, finishTime = 6, weight = 11, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 15, finishTime = 19, weight = 25, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 7, finishTime = 11, weight = 13, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 4, finishTime = 13, weight = 22, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 18, finishTime = 23, weight = 17, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 10, finishTime = 14, weight = 9, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 20, finishTime = 25, weight = 30, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 6, finishTime = 10, weight = 14, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 13, finishTime = 18, weight = 21, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 22, finishTime = 27, weight = 19, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 9, finishTime = 15, weight = 28, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 24, finishTime = 29, weight = 16, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 16, finishTime = 21, weight = 12, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 26, finishTime = 31, weight = 24, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 30, finishTime = 35, weight = 35, bestYetSolution = 0, lastCompatibleIndex = -1 }
        };

        List<ScheduledInterval> activityList50 = new List<ScheduledInterval>
        {
            new() { startTime = 12, finishTime = 18, weight = 25, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 2, finishTime = 5, weight = 10, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 7, finishTime = 14, weight = 18, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 1, finishTime = 8, weight = 22, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 20, finishTime = 24, weight = 16, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 4, finishTime = 9, weight = 13, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 15, finishTime = 21, weight = 30, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 9, finishTime = 12, weight = 11, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 25, finishTime = 30, weight = 27, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 3, finishTime = 11, weight = 19, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 18, finishTime = 26, weight = 23, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 11, finishTime = 16, weight = 14, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 28, finishTime = 34, weight = 35, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 6, finishTime = 10, weight = 8, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 22, finishTime = 28, weight = 20, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 13, finishTime = 17, weight = 17, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 31, finishTime = 37, weight = 29, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 8, finishTime = 15, weight = 26, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 35, finishTime = 41, weight = 32, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 16, finishTime = 20, weight = 12, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 5, finishTime = 13, weight = 24, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 39, finishTime = 45, weight = 21, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 24, finishTime = 29, weight = 15, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 10, finishTime = 19, weight = 28, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 42, finishTime = 48, weight = 38, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 19, finishTime = 23, weight = 9, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 27, finishTime = 33, weight = 31, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 14, finishTime = 22, weight = 16, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 33, finishTime = 39, weight = 34, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 21, finishTime = 27, weight = 18, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 45, finishTime = 51, weight = 40, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 30, finishTime = 36, weight = 22, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 17, finishTime = 25, weight = 27, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 48, finishTime = 54, weight = 33, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 26, finishTime = 32, weight = 19, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 37, finishTime = 43, weight = 36, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 23, finishTime = 31, weight = 25, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 41, finishTime = 47, weight = 30, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 34, finishTime = 40, weight = 17, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 29, finishTime = 38, weight = 28, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 46, finishTime = 53, weight = 26, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 38, finishTime = 44, weight = 23, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 50, finishTime = 57, weight = 42, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 32, finishTime = 42, weight = 37, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 44, finishTime = 50, weight = 29, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 52, finishTime = 59, weight = 45, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 40, finishTime = 49, weight = 24, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 55, finishTime = 62, weight = 39, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 49, finishTime = 56, weight = 20, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 58, finishTime = 65, weight = 48, bestYetSolution = 0, lastCompatibleIndex = -1 },
            new() { startTime = 54, finishTime = 61, weight = 35, bestYetSolution = 0, lastCompatibleIndex = -1 }
        };

        Random rand = new Random();

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
                bestYetSolution = 0,
                lastCompatibleIndex = -1,
            });
        }

        stopwatch.Start();
        Console.WriteLine(solution.WeightedIntervalScheduling(activityList20));
        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds);
    }
}