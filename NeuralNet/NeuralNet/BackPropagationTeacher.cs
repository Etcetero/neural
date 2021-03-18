using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNet
{
    class BackPropagationTeacher
    {
        double learningRate;
        double momentParameter;

        MultiLayerPerceptron perceptron;
        int layerCount;
        //Здесь хранятся производные от выходов нейронов
        List<Vector> Derivatives;
        void getDerivativesSigmoidal()
        {
            for (int i = 0; i < Derivatives.Count; i++)
            {
                Derivatives.Add(perceptron.Outputs[i]);
                for(int j = 0; j < Derivatives[i].M; j++)
                {
                    Derivatives[i][j] = Derivatives[i][j] * (1 - Derivatives[i][j] );
                }
            }
        }

        Vector getErrors(Vector Y)
        {
            Vector outPut = new Vector(Y.M);
            for(int i = 0; i < Y.M; i++)
            {
                outPut[i] = Y[i] - perceptron.Outputs[perceptron.Outputs.Count][i];
            }
            return outPut;

        }

        List<Vector> GetLocalGradients(Vector err)
        {
            Vector last = new Vector(err.M);
            //Вычисление локаьных градиентов последнего слоя
            last = err * Derivatives[Derivatives.Count - 1];

            List<Vector> localGradients = new List<Vector>();
            localGradients.Add(last);

            for(int i = Derivatives.Count - 2; i > 0; i--)
            {
                Vector temp = new Vector(Derivatives[i].M);
                for(int j = 0; j < temp.M; j++)
                {

                    temp[j] = Derivatives[i][j] * getMultiplySum(localGradients[Derivatives.Count - 2 - i], perceptron.layerArr[i + 1].WeightMatrix.getColumn(j));
                }
                localGradients.Add(temp);
            }
            return localGradients;

        }
        double getMultiplySum(Vector x, Vector y)
        {
            Vector temp = x * y;
            double sum = 0;
            for(int i = 0; i < temp.M; i++)
            {
                sum += temp[i];
            }
            return sum;
        }


        public void Teach(Dictionary<Vector, Vector> teachDictionary)
        {
            //сначала находим ошибки
            
            foreach(var VectorPair in teachDictionary)
            {
                //прямой проход
                perceptron.Step(VectorPair.Key);
                //Вычисляем ошибку сети для одной пары X:Y
                Vector errors = getErrors(VectorPair.Value);



                
            }

        }


        public BackPropagationTeacher()
        {
            Derivatives = new List<Vector>();
        }
    }
}
