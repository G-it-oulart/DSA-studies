public class Solution
{
    public int[] GenerateRandomArray()
    {
        int[] numsArray = new int[10000];

        Random randomGenerator = new Random();

        for (int i = 0; i < numsArray.Length; i++)
        {
            numsArray[i] = randomGenerator.Next(0, 15000);
        }

        return numsArray;
    }

    public void QuickSort(int[] unsortedArray, int start, int end)
    {
        if (start >= end)
        {
            return;
        }
        int partition = HoarePartition(unsortedArray, start, end);
        QuickSort(unsortedArray, start, partition);
        QuickSort(unsortedArray, partition + 1, end);

    }

    public int HoarePartition(int[] unsortedArray, int start, int end)
    {
        int pivot = unsortedArray[start + (end - start) / 2];
        int holdNum;
        while (true)
        {
            while (unsortedArray[start] < pivot)
            {
                start++;
            }
            while (unsortedArray[end] > pivot)
            {
                end--;
            }
            if (start >= end)
            {
                return end;
            }
            holdNum = unsortedArray[start];
            unsortedArray[start] = unsortedArray[end];
            unsortedArray[end] = holdNum;
            start++;
            end--;
        }
    }

    public void ShowPrimes(int[] array)
    {
        int max = array.Max();

        bool[] isPrime = new bool[max + 1];

        for (int i = 0; i <= max; i++)
        {
            isPrime[i] = true;
        }

        for (int i = 2; i * i <= max; i++)
        {
            if (isPrime[i])
            {
                for (int c = i * i; c <= max; c += i)
                {
                    isPrime[c] = false;
                }
            }
        }

        for (int i = 0; i < isPrime.Length; i++)
        {
            if (isPrime[i])
            {
                Console.WriteLine(i);
            }
        }
    }
}

