using System.Security.Cryptography;

public class Program
{

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] array = solution.GenerateRandomArray();
        while (true)
        {
            Console.WriteLine("Escolha uma das três opções: \n 1 para gerar um novo array \n 2 para ordenar o array atual \n e \n 3 para mostrar os números primos contidos no array atual");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                array = solution.GenerateRandomArray();
            }
            if (choice == "2")
            {
                solution.QuickSort(array, 0, array.Length - 1);
                foreach (int n in array)
                {
                    Console.WriteLine(n);
                }
            }
            if (choice == "3")
            {
                solution.ShowPrimes(array);
            }
        }
        ;
    }
}