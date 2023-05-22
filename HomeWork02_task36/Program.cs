//Задача 36: Задайте одномерный массив, заполненный случайными числами. 
//Найдите сумму элементов, стоящих на нечётных позициях.

void Task36()
{
    int ArrayLen = ReadInt("Задайте длину массива (целых) чисел: ");
    int LeftBorder = ReadInt("Задайте левую границу значений генерируемых чисел: ");
    int RightBorder = ReadInt("Задайте правую границу значений генерируемых чисел: ");
    if (LeftBorder >= RightBorder || ArrayLen <= 0)
    {
        System.Console.WriteLine("Недопустимые параметры {LeftBorder} >= {RightBorder} или {ArrayLen}<0");
    }
    else
    {
        int[] IntArray = new int[ArrayLen];
        //     заполняем с использованием генерации целых случайных чисел
        System.Console.WriteLine($"заполняем, генерируя случайные числа от {LeftBorder} до {RightBorder}: ");
        IntArray = GenerateRandonIntArray(ArrayLen, LeftBorder, RightBorder);
        PrintIArray(IntArray);
        int NumberOfAdditives = 0;
        //int iDiv = ReadInt("Задайте делитель (целое положительное) число: ");
        //int iRem = ReadInt("Задайте остаток (целое положительное) число: ");
        int iDiv=2;  // делитель выбираем 2
        int iRem=1; //суммируем только нечетные  === с остаткомЮ равным 1
        System.Console.WriteLine($" сумма = {SummOfDivisableIndexes(IntArray, iDiv, iRem, out NumberOfAdditives)}");
        System.Console.WriteLine($" просуммировано {NumberOfAdditives} элементов");
        
    }
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

int SummOfDivisableIndexes(int[] iArray, int divider, int remainder, out int count)
// вычисляет сумму тех элементов массива, индексы которых дают остаток remainder при делении divider
// попутно подсчитывает и возвращает число count таких элементов
{
    int Res = 0;
    count = 0;
    if (divider > 0 && remainder >= 0)
    {
        for (int i = 0; i < iArray.Length; i++)
        {
            if (i % divider == remainder)
            {
                //System.Console.Write($"a[{i}]={iArray[i]};  ");//контрольная печать для отладки
                Res += iArray[i];
                count++;
            };
        }
    }
    return Res;
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

Task36();