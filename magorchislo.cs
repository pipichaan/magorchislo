using System;
// программировании и алгоритмах термин "мажоритарное число" (или "мажоритарный элемент")
// обычно относится к числу, которое встречается в массиве или списке более половины раз.
// Иными словами, если у вас есть массив из n элементов, то мажоритарное число — это число,
// которое появляется более чем n/2 раз.

class Program
{
    static void Main()
    {
        const int size = 10000;
        Random random = new Random();
        int[] numbers = prikl(size, random, 0, 1001);//заполняет рандомными числами

        int pop = nashel(numbers);

        if (pop != -1)
        {
            Console.WriteLine($"Мажоритарное число: {pop}");
        }
        else
        {
            Console.WriteLine("Мажоритарного числа нет.");
        }
    }

    static int[] prikl(int size, Random random, int min, int max)
    {
        int[] numbers = new int[size];
        for (int i = 0; i < size; i++)
        {
            numbers[i] = random.Next(min, max);
        }
        return numbers;
    }

    static int nashel(int[] nums)
    {
        int candidate = -1;
        int count = 0;

        // нахождение кандидата
        foreach (var num in nums)
        {
            if (count == 0)
            {
                candidate = num;
                count = 1;
            }
            else if (num == candidate)
            {
                count++;
            }
            else
            {
                count--;
            }
        }

        // проверка, является ли кандидат мажоритарным числом
        count = 0;
        foreach (var num in nums)
        {
            if (num == candidate)
            {
                count++;
            }
        }

        return count > nums.Length / 2 ? candidate : -1;
    }
}
