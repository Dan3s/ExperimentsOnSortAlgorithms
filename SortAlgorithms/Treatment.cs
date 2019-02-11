using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
    class Treatment
    {


        private int size;
        private string order;

        public Treatment(string order, int size)
        {
            Order = order;
            Size = size;
        }

        public string Order { get => order; set => order = value; }
        public int Size { get => size; set => size = value; }


    }
}
