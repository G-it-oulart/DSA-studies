using System.Diagnostics;

public class Solution
{
    public static int ChooseTheMostActivities(List<(int startTime, int finishTime)> activities)
    {
        int activitiesAttended = 1; //Lista de atividades atendidas começa com um pois considera-se que pelo menos uma sempre vai ser pega.
        activities.Sort((act1, act2) => act1.finishTime.CompareTo(act2.finishTime)); //Ordenação crescente por tempo de término de cada atividade
        (int startTime, int finishTime) selectedActivity = activities[0];
        for (int i = 1; i < activities.Count; i++)
        {
            (int startTime, int finishTime) currentActivity = activities[i];

            if (currentActivity.startTime >= selectedActivity.finishTime) //Tempo de início da próxima atividade deve ser maior que o término da atividade atual para evitar conflitos.
            {
                activitiesAttended++;
                selectedActivity = activities[i];
            }
        }

        return activitiesAttended;
    }

    public static void ShowResults(List<(int starTime, int finishTime)> activities)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        int activitiesAttended = ChooseTheMostActivities(activities);
        stopwatch.Stop();
        Console.WriteLine($"The number of activities attended in the test was {activitiesAttended}");
        Console.WriteLine($"The first test ran for ${stopwatch.Elapsed.TotalMilliseconds} ms");
    }

    public static void Main(string[] args)
    {
        //Teste 1
        List<(int startTime, int finishTime)> activityList1 = new List<(int startTime, int finishTime)>
        {
            (8, 10), (1, 4), (5, 9), (3, 6), (10, 12)
        };
        //Teste 2
        List<(int startTime, int finishTime)> activityList2 = new List<(int startTime, int finishTime)>
        {
            (12, 16), (1, 3), (8, 11), (4, 9), (15, 18),
            (2, 6), (10, 13), (6, 8), (17, 21), (3, 5),
            (13, 17), (0, 2), (9, 14), (5, 7), (19, 22),
            (7, 12), (14, 15), (11, 16), (18, 20), (2, 4)
        };
        //Teste 3
        List<(int startTime, int finishTime)> activityList3 = new List<(int startTime, int finishTime)>();

        Random random = new Random();

        for (int i = 0; i < 1000000; i++)
        {
            int startTime = random.Next(0, 1000000);
            int duration = random.Next(1, 101);
            activityList3.Add((startTime, startTime + duration));
        }
        ShowResults(activityList1);
        ShowResults(activityList2);
        ShowResults(activityList3);
    }
}