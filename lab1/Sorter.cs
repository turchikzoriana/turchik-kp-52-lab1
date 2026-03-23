class Sorter
{
    private Record[] records = new Record[100];
    private int size = 0;

    private SortStatistics stats = new SortStatistics();

    public void initCollection()
    {
        size = 0;
    }

    public void addRecord(Record r)
    {
        records[size++] = r;
    }

    public void printCollection()
    {
        for (int i = 0; i < size; i++)
            Console.WriteLine(records[i]);
    }

    public void sortCollection()
    {
        stats = new SortStatistics();   
        stats.Timer.Start();            

        MergeSort(0, size - 1);

        stats.Timer.Stop();             
    }

    private void MergeSort(int left, int right)
    {
        stats.Recursions++;

        if (left >= right)
            return;

        int mid = (left + right) / 2;

        MergeSort(left, mid);
        MergeSort(mid + 1, right);

        Merge(left, mid, right);
    }

    private void Merge(int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        Record[] L = new Record[n1];
        Record[] R = new Record[n2];

        for (int i = 0; i < n1; i++)
        {
            L[i] = records[left + i];
            stats.Copies++;
        }

        for (int j = 0; j < n2; j++)
        {
            R[j] = records[mid + 1 + j];
            stats.Copies++;
        }

        int a = 0, b = 0, k = left;

        while (a < n1 && b < n2)
        {
            stats.Comparisons++;

            if (Compare(L[a], R[b]) <= 0)
                records[k++] = L[a++];
            else
                records[k++] = R[b++];

            stats.Copies++;
        }

        while (a < n1)
        {
            records[k++] = L[a++];
            stats.Copies++;
        }

        while (b < n2)
        {
            records[k++] = R[b++];
            stats.Copies++;
        }

        printIntermediateSteps(left, right);
    }

    private int Compare(Record x, Record y)
    {
        int last = x.LastName.CompareTo(y.LastName);
        if (last != 0) return last;

        return x.FirstName.CompareTo(y.FirstName);
    }

    public void printIntermediateSteps(int left, int right)
    {
        Console.WriteLine("Проміжне злиття:");
        for (int i = left; i <= right; i++)
            Console.WriteLine(records[i]);
    }

    public void findByLetter(char letter)
    {
        for (int i = 0; i < size; i++)
        {
            if (records[i].LastName.StartsWith(letter.ToString()))
                Console.WriteLine(records[i]);
        }
    }

    public void printDistrictStats()
    {
        string[] districts = new string[100];
        int[] counts = new int[100];
        int dSize = 0;

        for (int i = 0; i < size; i++)
        {
            int index = -1;

            for (int j = 0; j < dSize; j++)
            {
                if (districts[j] == records[i].District)
                {
                    index = j;
                    break;
                }
            }

            if (index == -1)
            {
                districts[dSize] = records[i].District;
                counts[dSize] = 1;
                dSize++;
            }
            else
            {
                counts[index]++;
            }
        }

        for (int i = 0; i < dSize; i++)
            Console.WriteLine($"{districts[i]}: {counts[i]}");
    }

    public void printStatistics()
    {
        stats.Print();
    }

    public void inputRecord()
    {
        try
        {
            Console.Write("Номер картки: ");
            int card = int.Parse(Console.ReadLine());

            Console.Write("Прізвище: ");
            string last = Console.ReadLine();

            Console.Write("Ім'я: ");
            string first = Console.ReadLine();

            Console.Write("Район: ");
            string district = Console.ReadLine();

            addRecord(new Record(card, last, first, district));
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    public void removeRecord(int cardNumber)
    {
        int index = -1;

        for (int i = 0; i < size; i++)
        {
            if (records[i].CardNumber == cardNumber)
            {
                index = i;
                break;
            }
        }

        if (index == -1)
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        for (int i = index; i < size - 1; i++)
        {
            records[i] = records[i + 1];
        }

        size--;
        Console.WriteLine("Видалено.");
    }
}