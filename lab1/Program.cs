class Program
{
    static void Main()
    {
        Sorter sorter = new Sorter();

        while (true)
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1 - Додати пацієнта.");
            Console.WriteLine("2 - Видалити пацієнта.");
            Console.WriteLine("3 - Друк.");
            Console.WriteLine("4 - Сортування.");
            Console.WriteLine("5 - Знайти за літерою.");
            Console.WriteLine("6 - Порахувати за районами.");
            Console.WriteLine("7 - Статистика.");
            Console.WriteLine("0 - Вихід.");

            Console.Write("Виберіть: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    sorter.inputRecord();   
                    break;

                case "2":
                    Console.Write("Введіть номер картки: ");
                    int num;
                    if (int.TryParse(Console.ReadLine(), out num))
                        sorter.removeRecord(num);   
                    else
                        Console.WriteLine("Invalid input.");
                    break;

                case "3":
                    sorter.printCollection();   
                    break;

                case "4":
                    sorter.sortCollection();    
                    break;

                case "5":
                    Console.Write("Літера: ");
                    char letter = Console.ReadLine()[0];
                    sorter.findByLetter(letter);
                    break;

                case "6":
                    sorter.printDistrictStats();
                    break;

                case "7":
                    sorter.printStatistics();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }
    }
}