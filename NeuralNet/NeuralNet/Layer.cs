using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNet
{
    class Layer
    {
        Matrix WeightMatrix; //Матрица входных весов
        Vector OutputSygnals; //Выходные сигналы текущего слоя
        //Функция активации
        void SigmoidalActivate(Vector inputSygnals)
        {
            OutputSygnals = WeightMatrix * inputSygnals;
            for (int i = 0; i < OutputSygnals.M; i++)
            {
                OutputSygnals[i] = 1 / (1 + Math.Exp(-OutputSygnals[i]));
            }
        }



        public void FillRandomly()
        {
            Random random = new Random();
            for (int i = 0; i < WeightMatrix.M; i++)
            {
                for (int k = 0; k < WeightMatrix.N; k++)
                {
                    WeightMatrix[i, k] = random.NextDouble();
                }
            }
        }

        public Layer(int NeuronCount, int prevCount)
        {
            OutputSygnals = new Vector(NeuronCount);
            WeightMatrix = new Matrix(NeuronCount, prevCount);
        }
    }
}
