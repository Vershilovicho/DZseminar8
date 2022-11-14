// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

int[,] CreateMatrixRndInt(int rows, int columns, int min, int max)
{
    var matrix = new int[rows, columns];
    var rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(min, max + 1);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write("|");
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (j < matrix.GetLength(1) - 1) Console.Write($"{matrix[i, j],4}, ");
            else Console.Write($"{matrix[i, j],4} ");
        }
        Console.WriteLine("|");
    }
}

int[,] ResolvingMatrix(int[,] matrixA, int[,] matrixB)
{
    int[,] matrixC = new int[matrixA.GetLength(0), matrixB.GetLength(1)];
    for (int i = 0; i < matrixA.GetLength(0); i++)
    {
        for (int j = 0; j < matrixB.GetLength(1); j++)
        {
            matrixC[i, j] = 0;
            for (int k = 0; k < matrixA.GetLength(0); k++)
            {
                matrixC[i, j] = matrixC[i, j] + matrixA[i, k] * matrixB[k, j];
            }
        }
    }
    return matrixC;


}



int[,] array2D = CreateMatrixRndInt(2, 3, 1, 5);
PrintMatrix(array2D);
Console.WriteLine();
int[,] array2D1 = CreateMatrixRndInt(3, 2, 1, 5);
PrintMatrix(array2D1);
Console.WriteLine();

if (array2D.GetLength(1) != array2D1.GetLength(0))
{
    Console.WriteLine("Умножение невозможно! Количество столбцов первой матрицы не равно количеству строк второй матрицы");
}
else
{
    int[,] resolvingMatrix = ResolvingMatrix(array2D, array2D1);
    PrintMatrix(resolvingMatrix);   
}
