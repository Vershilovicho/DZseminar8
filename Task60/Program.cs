// Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, 
// добавляя индексы каждого элемента.
// Например, задан массив размером 2 x 2 x 2.
// Результат:
// 66(0,0,0) 27(0,0,1) 25(0,1,0) 90(0,1,1)
// 34(1,0,0) 26(1,0,1) 41(1,1,0) 55(1,1,1)

int[,,] CreateMatrixRndInt(int rows, int columns, int depth, int min, int max)
{
    var matrix = new int[rows, columns, depth];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int k = 0;
            while (k < matrix.GetLength(2))
            {
                int element = new Random().Next(min, max + 1);
                if (FindElement(matrix, element)) continue;
                matrix[i, j, k] = element;
                k++;
            }
        }
    }
    return matrix;
}


bool FindElement(int[,,] array3D, int el)
{
    for (int i = 0; i < array3D.GetLength(0); i++)
    {
        for (int j = 0; j < array3D.GetLength(1); j++)
        {
            for (int k = 0; k < array3D.GetLength(2); k++)
            {
                if (array3D[i, j, k] == el) return true;
            }
        }
    }
    return false;
}


void PrintMatrix(int[,,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write("|");
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                if (j < matrix.GetLength(1) - 1) Console.Write($"{matrix[i, j, k],4} ({i},{j},{k}) ");
                else Console.Write($"{matrix[i, j, k],4} ({i},{j},{k}) ");
            }
        }
        Console.WriteLine("|");
    }
}

int[,,] array3D = CreateMatrixRndInt(2, 2, 2, 10, 100);

PrintMatrix(array3D);
Console.WriteLine();