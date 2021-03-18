using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNet
{
    class MultiLayerPerceptron : IPrintable
    {
        int inputCount;
        int outputCount;
        int hiddenNeuronsCount;        
        Layer[] layerArr;
        //Здесь должны храниться производные
        List<Vector> Derivatives;

        //Один прямой проход 
        public void Step(Vector inputSygnals)
        {            
            Derivatives.Add( layerArr[0].SigmoidalActivate(inputSygnals) );
            for (int i = 1; i < layerArr.Length; i++)
            {
                Derivatives.Add( layerArr[i].SigmoidalActivate(layerArr[i - 1].OutputSygnals) );
            }
        }

        void getDerivativesSigmoidal()
        {
            for(int i = 0; i < Derivatives.Count; i++)
            {
                for(int j = 0; j< Derivatives[i].M; j++)
                {
                    Derivatives[i][j] = Derivatives[i][j] * (1 - Derivatives[i][j]);
                }
            }
        }

        public void Print()
        {
            foreach (var x in layerArr)
            {
                x.WeightMatrix.Print();
            }
        }

        public MultiLayerPerceptron(int inCount, int outCount, int hiddenLayersCount, int neuronCount)
        {
            inputCount = inCount;
            outputCount = outCount;
            hiddenNeuronsCount = neuronCount;
            layerArr = new Layer[++hiddenLayersCount]; //Выходной слой не является скрытым(вроде)
            layerArr[0] = new Layer(neuronCount, inCount);
            Derivatives = new List<Vector>();
            for (int i = 1; i < hiddenLayersCount - 1; i++)
            {
                layerArr[i] = new Layer(neuronCount, neuronCount);
            }
            layerArr[hiddenLayersCount - 1] = new Layer(outCount, neuronCount);
            for (int i = 0; i < hiddenLayersCount; i++)
            {
                layerArr[i].FillRandomly();
            }
        }
    }
}
