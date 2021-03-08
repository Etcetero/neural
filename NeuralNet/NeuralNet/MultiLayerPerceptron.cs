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

        //Один прямой проход 
        public void Step(Vector inputSygnals)
        {
            layerArr[0].SigmoidalActivate(inputSygnals);
            for (int i = 1; i < layerArr.Length; i++)
            {
                layerArr[i].SigmoidalActivate(layerArr[i - 1].OutputSygnals);
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
