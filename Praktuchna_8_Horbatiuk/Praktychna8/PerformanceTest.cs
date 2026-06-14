using System;
using System.Diagnostics;
using System.Linq;

namespace Praktychna8;

public class PerformanceTest
{
    public void Run(int count = 100000)
    {
        Console.WriteLine($"Порівняння продуктивності struct vs class ({count} елементів)");
        Console.WriteLine();

        // === Структури (StudentRecord) ===
        long memBeforeStruct = GC.GetTotalMemory(true);
        var sw = Stopwatch.StartNew();
        var structs = new StudentRecord[count];
        for (int i = 0; i < count; i++)
            structs[i] = new StudentRecord($"Студент Номер {i}", i.ToString("D8"), i % 100);
        sw.Stop();
        long structFill = sw.ElapsedMilliseconds;
        long memAfterStruct = GC.GetTotalMemory(false);
        long structMem = (memAfterStruct - memBeforeStruct) / 1024;

        sw.Restart();
        var sortedStructs = structs.OrderBy(s => s.AverageGrade).ToArray();
        sw.Stop();
        long structSort = sw.ElapsedMilliseconds;

        sw.Restart();
        int structFound = 0;
        for (int i = 0; i < count; i++)
            if (structs[i].AverageGrade > 50) structFound++;
        sw.Stop();
        long structSearch = sw.ElapsedMilliseconds;

        // === Класи (Student) ===
        long memBeforeClass = GC.GetTotalMemory(true);
        sw.Restart();
        var classes = new Student[count];
        for (int i = 0; i < count; i++)
        {
            classes[i] = new Student($"Студент Номер {i}", new DateTime(2005, 1, 1), i.ToString("D8"));
            classes[i].UpdateAverageGrade(i % 100);
        }
        sw.Stop();
        long classFill = sw.ElapsedMilliseconds;
        long memAfterClass = GC.GetTotalMemory(false);
        long classMem = (memAfterClass - memBeforeClass) / 1024;

        sw.Restart();
        var sortedClasses = classes.OrderBy(s => s.AverageGrade).ToArray();
        sw.Stop();
        long classSort = sw.ElapsedMilliseconds;

        sw.Restart();
        int classFound = 0;
        for (int i = 0; i < count; i++)
            if (classes[i].AverageGrade > 50) classFound++;
        sw.Stop();
        long classSearch = sw.ElapsedMilliseconds;

        // === Таблиця ===
        Console.WriteLine($"{"Операція",-22}{"struct",-14}{"class",-14}");
        Console.WriteLine(new string('-', 50));
        Console.WriteLine($"{"Заповнення (мс)",-22}{structFill,-14}{classFill,-14}");
        Console.WriteLine($"{"Сортування (мс)",-22}{structSort,-14}{classSort,-14}");
        Console.WriteLine($"{"Пошук (мс)",-22}{structSearch,-14}{classSearch,-14}");
        Console.WriteLine($"{"Пам'ять (КБ)",-22}{structMem,-14}{classMem,-14}");
        Console.WriteLine();
        Console.WriteLine("Структури зберігаються в одному масиві без окремих об'єктів у купі,");
        Console.WriteLine("тому зазвичай швидше заповнюються і менше навантажують збирач сміття.");
    }
}
