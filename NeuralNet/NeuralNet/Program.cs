using System;
using System.Collections.Generic;

namespace NeuralNet
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiLayerPerceptron perc = new MultiLayerPerceptron(2, 2, 2, 3);
            perc.Print();
            perc.PrintResult();
            perc.Step(new Vector(2));
            perc.PrintResult();
            BackPropagationTeacher teacher = new BackPropagationTeacher(perc);
            Dictionary<Vector, Vector> learnTable = new Dictionary<Vector, Vector>();
            Vector X = new Vector(2);
            Vector Y = new Vector(2);
            X[0] = X[1] = 0.3f;
            Y[0] = 0.1f;
            Y[1] = 0.9f;

            learnTable.Add(X, Y);

            teacher.Teach(learnTable, 0.5f, 0.5f, 2000);
            perc.Print();
            perc.PrintResult();
        }
    }
}
