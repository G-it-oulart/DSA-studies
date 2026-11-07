using scheduledInterval;

namespace searchingMethods;

public class SearchingMethods
{
    public int BinarySearch(List<ScheduledInterval> activityList, int target, int left, int right, int current)
    {
        if (left > right)
        {
            return current;
        }

        int middle = left + (right - left) / 2;
        if (activityList[middle].finishTime <= activityList[target].startTime)
        {
            current = middle;
            return BinarySearch(activityList, target, middle + 1, right, current);
        }
        else
        {
            return BinarySearch(activityList, target, left, middle - 1, current);
        }
    }
}