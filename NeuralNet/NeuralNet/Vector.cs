using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNet
{
    class Vector
    {
        double[] data;
        int m;
        public int M { get => this.m; }
        public double this[int x]
        {
            get
            {
                return this.data[x];
            }
            set
            {
                this.data[x] = value;
            }
        }
        public void ProcessFunctionOverData(Action<int> func)
        {

            for (var i = 0; i < this.M; i++)
            {
                func(i);
            }

        }


        

        public Vector(int m)
        {
            this.m = m;
           
            this.data = new double[m];
        }
    }
}
