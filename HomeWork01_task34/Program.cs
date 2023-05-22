//Задача 34: Задайте массив заполненный случайными положительными трёхзначными числами. 
//Напишите программу, которая покажет количество чётных чисел в массиве.

void Task34()
{
    int ArrayLen = ReadInt("Задайте длину массива (целых) чисел: ");
    int[] IntArray = new int[ArrayLen];

    //     заполняем с использованием генерации случайных чисел
    System.Console.WriteLine($"заполняем, использованием генерации случайных чисел от 100 до 999: ");
    IntArray = GenerateRandonIntArray(ArrayLen, 100, 999);
    PrintIArray(IntArray);
    System.Console.WriteLine($" в массиве имеется {CountDivisable(IntArray, 2, 0)} четных чисел");
    System.Console.WriteLine($" в массиве имеется {CountDivisable(IntArray, 2, 1)} нечетных чисел");
    int iDiv = ReadInt("Задайте делитель (целое положительное) число: ");
    System.Console.WriteLine($" в массиве имеется {CountDivisable(IntArray, iDiv, 0)} чисел, кратных {iDiv}");
}
int ReadInt(string text) // запрашивает число для ввода с консоли и возвращает его после проглатывания с консоли
{
    System.Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

void PrintIArray(int[] iArrayToPrint) //печатает на консоль элементы массива в строку с разделителями ", "
{
    System.Console.WriteLine("[" + String.Join(", ", iArrayToPrint) + "]");
}

int CountDivisable(int[] iArray, int divider, int remainder)
{
    int count = 0;
    if (divider > 0 && remainder >= 0)
    {
        for (int i = 0; i < iArray.Length; i++)
        {
            if (iArray[i] % divider == remainder)
            {
                count++;
            };
        }
    }
    else
    {
        count = -1;
    };
    return count;
}

int[] GenerateRandonIntArray(int size, int leftRange, int rightRange)
{
    int[] tempArray = new int[size];
    Random rand = new Random();

    for (int i = 0; i < size; i++)
    {
        tempArray[i] = rand.Next(leftRange, rightRange + 1);
    }
    return tempArray;
}

Task34();