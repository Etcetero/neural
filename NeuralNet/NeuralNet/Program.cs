using System;

namespace NeuralNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.WriteLine("Hello World!");
            Matrix matrix = new Matrix(3, 2);
            for(int i = 0; i < matrix.M; i++)
            {
                for(int j = 0; j < matrix.N; j++)
                {
                    matrix[i, j] = rand.NextDouble();
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Matrix transposed = matrix.Transposed();
            for (int i = 0; i < transposed.M; i++)
            {
                for (int j = 0; j < transposed.N; j++)
                {
                    Console.Write($"{transposed[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Vector vector = new Vector(2);
            vector[0] = rand.NextDouble();
            vector[1] = rand.NextDouble();

            Vector result = matrix * vector;
            for(int i = 0; i < result.M; i++)
            {
                Console.WriteLine($"{result[i]}");
            }
        }
    }
}
