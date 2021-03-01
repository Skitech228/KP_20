using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp47
{
    class Test
    {
        public double Progress;
        public double Sum;
        public Test()
        {
            Progress = 0;
            Sum = 0;
        }

        public Test(double progress, int sum)
        {
            Progress = progress;
            Sum = sum;
        }
    }
}
