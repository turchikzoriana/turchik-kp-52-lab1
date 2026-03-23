using System.Diagnostics;

class SortStatistics
{
    public int Comparisons;
    public int Copies;
    public int Recursions;
    public Stopwatch Timer = new Stopwatch();

    public void Print()
    {
        Console.WriteLine("Порівняння: " + Comparisons);
        Console.WriteLine("Копії: " + Copies);
        Console.WriteLine("Рекурсії: " + Recursions);
        Console.WriteLine("Час: " + Timer.ElapsedMilliseconds + " мс");
    }
}