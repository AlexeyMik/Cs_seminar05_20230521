//Задача 38: Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементом массива.

//Задача 36: Задайте одномерный массив, заполненный случайными числами. 
//Найдите сумму элементов, стоящих на нечётных позициях.

void Task38()
{
    int ArrayLen = ReadInt("Задайте желаемую длину массива чисел: ");
    double DLeftBorder = Convert.ToDouble(ReadInt("Задайте левую границу значений генерируемых чисел: "));
    double DRightBorder = Convert.ToDouble(ReadInt("Задайте правую границу значений генерируемых чисел: "));
    if (DLeftBorder >= DRightBorder || ArrayLen <= 0)
    {
        System.Console.WriteLine("Недопустимые параметры {DLeftBorder} >= {DRightBorder} или {ArrayLen}<0");
    }
    else
    {
        double[] RandArray = new double[ArrayLen];
        System.Console.WriteLine($"заполняем, генерируя случайные числа от {DLeftBorder} до {DRightBorder}: ");
        RandArray = GenerateRandomDArray(ArrayLen, DLeftBorder, DRightBorder);
        PrintDArrayInLine(RandArray, 4);

        double a =GapOfArrayValues( RandArray, out int indOfMax, out int indOfMin);
        System.Console.WriteLine($" Амплитуда значений массива = {Math.Round(a,4)}");
        System.Console.WriteLine($"миним значение массива {Math.Round(RandArray[indOfMin],4)} при индексе {indOfMin}");
        System.Console.WriteLine($"макс  значение массива {Math.Round(RandArray[indOfMax],4)} при индексе {indOfMax}");

    }
}
int ReadInt(string text) // запрашивает целое число для ввода с консоли и возвращает его после проглатывания с консоли
{
    System.Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

void PrintDArrayInLine(double[] ArrayToPrint, int figAfterPoint) 
//печатает на консоль округленные до figAfterPoin значения элементов массива в строку с разделителями "; "
{
    for (int i = 0; i < ArrayToPrint.Length; i++)
    {
        System.Console.Write($" {Math.Round(ArrayToPrint[i], figAfterPoint)}; ");
    };
    System.Console.WriteLine();
}

double GapOfArrayValues(double[] dArray, out int indexOfMaxValue, out int indexOfMinValue)
// ищет в действительно значном массиве элементы с мин и макс значениями, 
// функция возвращает значение разницы между максимальным и минимальным значениями
// и попутно запоминает и возвращает в доп параметрах индексы минимального и максимального элементов
{
    int iOfMin = 0;
    int iOfMax = 0;
    for (int i = 0; i < dArray.Length; i++)
    {
        if (dArray[i] > dArray[iOfMax])
        {
            iOfMax = i;
        }
        else
        if (dArray[i] < dArray[iOfMin])
        {
            iOfMin = i;
        };
    };
    indexOfMaxValue = iOfMax;
    indexOfMinValue = iOfMin;
    return (dArray[iOfMax] - dArray[iOfMin]);
}

double[] GenerateRandomDArray(int size, double DleftRange, double DrightRange)
{
    double[] tempArray = new double[size];
    Random rand = new Random();
    double Amplitude = DrightRange - DleftRange;
    if (Math.Abs(Amplitude) > 0)
        for (int i = 0; i < size; i++)
        {
            tempArray[i] = DleftRange + rand.NextDouble() * Amplitude;
        }
    return tempArray;
}

Task38();