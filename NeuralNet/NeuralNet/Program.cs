using System;

namespace NeuralNet
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiLayerPerceptron perc = new MultiLayerPerceptron(2, 2, 2, 3);
            perc.Print();
        }
    }
}
