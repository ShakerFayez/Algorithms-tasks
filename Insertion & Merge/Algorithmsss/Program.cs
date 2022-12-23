internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter number 1 to use Insertion sorting \nOr number 2 to use Merge sorting");
        char algo = char.Parse(Console.ReadLine());
        if (algo == '1')
        {
            static int InsertionSorting()
            {

                Console.Write("\n\nEnter number of elements to be sorted: ");
                int max = Convert.ToInt32(Console.ReadLine());
                int[] numarray = new int[max];
                for (int i = 0; i < max; i++)
                {
                    Console.Write("\nEnter [" + (i + 1).ToString() + "] element: ");
                    numarray[i] = Convert.ToInt32(Console.ReadLine());
                }
                Console.Write("\nInput int array  : \n");
                for (int k = 0; k < max; k++)
                    Console.Write(numarray[k] + " ");
                Console.Write("\n");
                for (int i = 1; i < max; i++)
                {
                    int j = i;
                    while (j > 0)
                    {
                        if (numarray[j - 1] > numarray[j])
                        {
                            int temp = numarray[j - 1];
                            numarray[j - 1] = numarray[j];
                            numarray[j] = temp;
                            j--;
                        }
                        else
                            break;
                    }

                }
                Console.Write("\n\nThe sorted aray:\n");
                for (int i = 0; i < max; i++)
                {
                    Console.Write(numarray[i] + " ");
                }
                return 0;
            }
            InsertionSorting();
        }
        else if(algo == '2')
        {
            Console.WriteLine("Enter size of the array: ");
            int size = int.Parse(Console.ReadLine());
            int[] arr = new int[size];
            for (int i = 0;i<size; i++)
            {
                Console.WriteLine("Enter element " + i);
                arr[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("\nGiven Array");
            MergeSort.printArray(arr);
            MergeSort ob = new MergeSort();
            ob.sort(arr, 0, arr.Length - 1);
            Console.WriteLine("\nSorted array");
            MergeSort.printArray(arr);
        }
   
        else
        {
            Console.WriteLine("Invalid input");
        }
        Console.ReadKey();
    }

    class MergeSort
    {

        void merge(int[] arr, int l, int m, int r)
        {

            int n1 = m - l + 1;
            int n2 = r - m;

            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];


            i = 0;
            j = 0;

            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        public void sort(int[] arr, int l, int r)
        {
            if (l < r)
            {

                int m = l + (r - l) / 2;

                sort(arr, l, m);
                sort(arr, m + 1, r);

                merge(arr, l, m, r);
            }
        }

        public static void printArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}
